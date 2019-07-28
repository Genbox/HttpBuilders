using System;
using System.Collections;
using System.Text;
using HttpBuilders.Abstracts;
using HttpBuilders.Internal;
using HttpBuilders.Internal.Collections;
using HttpBuilders.Options;
using Microsoft.Extensions.Options;

namespace HttpBuilders
{
    /// <summary>
    /// Builder for HTTP Range.
    /// RFC: https://tools.ietf.org/html/rfc7233#section-3.1
    /// See https://developer.mozilla.org/en-US/docs/Web/HTTP/Range_requests and https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Range
    /// </summary>
    public class RangeBuilder : IHttpHeaderBuilder
    {
        private ConstantGrowArray<Range> _ranges;
        private BitArray _invalidIndex;
        private int _invalidCount;

        public RangeBuilder()
        {
            Options = Microsoft.Extensions.Options.Options.Create(new RangeBuilderOptions());
        }

        public RangeBuilder(IOptions<RangeBuilderOptions> options)
        {
            Options = options;
        }

        public IOptions<RangeBuilderOptions> Options { get; }

        public RangeBuilder Add(long start, long end)
        {
            if (_ranges == null)
                _ranges = new ConstantGrowArray<Range>(1, Range.Comparer);

            _ranges.Add(new Range(start, end));

            return this;
        }

        public string Build()
        {
            return Build("bytes");
        }

        public string Build(string unit = "bytes", long dataSize = -1)
        {
            //RFC7233: A server that supports range requests MAY ignore or reject a Range header field that consists of more than two overlapping ranges
            //RFC7233: A client that is requesting multiple ranges SHOULD list those ranges in ascending order

            //We do a couple of things here:
            //1. We merge ranges that overlap
            //2. We sort the ranges in ascending order to ease the work for the server
            //3. We shorten the range 
            //4. We skip (and log) invalid ranges

            if (_ranges == null)
                return null;

            //Reset state
            _invalidCount = 0;

            //We need an invalid index if we are going to report invalid ranges
            if (Options.Value.MergeOverlappingRanges || Options.Value.DiscardInvalidRanges)
                _invalidIndex = new BitArray(_ranges.Count);

            if (_ranges.Count > 1)
            {
                if (Options.Value.SortRanges || Options.Value.MergeOverlappingRanges)
                    _ranges.Sort();

                if (Options.Value.MergeOverlappingRanges)
                {
                    int pointer = 0;
                    ref Range previous = ref _ranges[pointer];

                    for (int i = 1; i < _ranges.Count; i++)
                    {
                        Range current = _ranges[i];

                        if (current.Start <= previous.End)
                        {
                            previous.End = Math.Max(previous.End, current.End);
                            ReportInvalid(i);
                        }
                        else
                            pointer++;
                    }
                }
            }

            if (Options.Value.DiscardInvalidRanges)
            {
                for (int i = 0; i < _ranges.Count; i++)
                {
                    ref Range range = ref _ranges[i];

                    if (range.Start < 0)
                        ReportInvalid(i);

                    if (dataSize > 0 && range.End > dataSize)
                        ReportInvalid(i);
                }
            }

            //All the ranges where invalid
            if (_ranges.Count == _invalidCount)
                return null;

            StringBuilder sb = new StringBuilder();

            //bytes=
            sb.Append(unit).Append('=');

            //start-end, start-end
            for (int i = 0; i < _ranges.Count; i++)
            {
                ref Range range = ref _ranges[i];

                //Skip if it is invalid
                if (_invalidIndex != null && _invalidIndex[i])
                    continue;

                if (Options.Value.ShortenRanges && dataSize > 0)
                {
                    //We might be able to omit the end. Only possible if data size is supplied
                    if (range.End == dataSize)
                        sb.Append(range.Start).Append('-');
                    else
                        sb.Append(range.Start).Append('-').Append(range.End);
                }
                else
                {
                    sb.Append(range.Start).Append('-').Append(range.End);
                }

                if (i < _ranges.Count - 1 - _invalidCount)
                    sb.Append(',');
            }

            return sb.ToString();
        }

        /// <summary>
        /// Only increase the invalid counter if we haven't already reported it.
        /// </summary>
        private void ReportInvalid(int index)
        {
            if (_invalidIndex[index])
                return;

            _invalidIndex[index] = true;
            _invalidCount++;
        }
    }
}