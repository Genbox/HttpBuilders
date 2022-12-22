using System;
using System.Collections;
using System.Text;
using Genbox.HttpBuilders.Abstracts;
using Genbox.HttpBuilders.BuilderOptions;
using Genbox.HttpBuilders.Internal;
using Genbox.HttpBuilders.Internal.Collections;
using Microsoft.Extensions.Options;

namespace Genbox.HttpBuilders;

/// <summary>
/// The Range HTTP request header indicates the part of a document that the server should return. Several parts can be requested with one Range
/// header at once, and the server may send back these ranges in a multipart document. If the server sends back ranges, it uses the 206 Partial Content
/// for the response. If the ranges are invalid, the server returns the 416 Range Not Satisfiable error. The server can also ignore the Range header and
/// return the whole document with a 200 status code. This builder creates a range according to RFC 7233, see
/// https://tools.ietf.org/html/rfc7233#section-3.1 For more info, see https://developer.mozilla.org/en-US/docs/Web/HTTP/Range_requests and
/// https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Range
/// </summary>
public class RangeBuilder : IHttpHeaderBuilder
{
    private int _invalidCount;
    private BitArray? _invalidIndex;
    private ConstantGrowArray<Range>? _ranges;
    private StringBuilder? _sb;

    public RangeBuilder()
    {
        Options = Microsoft.Extensions.Options.Options.Create(new RangeOptions());
    }

    public RangeBuilder(IOptions<RangeOptions> options)
    {
        Options = options;
    }

    public IOptions<RangeOptions> Options { get; }

    public string HeaderName => "Range";

    public string? Build()
    {
        return Build("bytes");
    }

    public string? Build(string unit, long dataSize = -1)
    {
        //RFC7233: A server that supports range requests MAY ignore or reject a Range header field that consists of more than two overlapping ranges
        //RFC7233: A client that is requesting multiple ranges SHOULD list those ranges in ascending order

        //We do a couple of things here:
        //1. We merge ranges that overlap
        //2. We sort the ranges in ascending order to ease the work for the server
        //3. We shorten the range 
        //4. We skip (and log) invalid ranges

        if (!HasData())
            return null;

        //Reset state
        _invalidCount = 0;

        //We need an invalid index if we are going to report invalid ranges
        if (Options.Value.MergeOverlappingRanges || Options.Value.DiscardInvalidRanges)
            _invalidIndex = new BitArray(_ranges!.Count);

        if (_ranges!.Count > 1)
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
                    {
                        pointer++;
                    }
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

        if (_sb == null)
            _sb = new StringBuilder(25);
        else
            _sb.Clear();

        //bytes=
        _sb.Append(unit).Append('=');

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
                    _sb.Append(range.Start).Append('-');
                else
                    _sb.Append(range.Start).Append('-').Append(range.End);
            }
            else
            {
                _sb.Append(range.Start).Append('-').Append(range.End);
            }

            if (i < _ranges.Count - 1 - _invalidCount)
                _sb.Append(',');
        }

        return _sb.ToString();
    }

    public void Reset()
    {
        _ranges?.Clear();
        _invalidIndex?.SetAll(false);
    }

    public bool HasData()
    {
        return _ranges != null && _ranges.Count > 0;
    }

    public RangeBuilder Add(long start, long end)
    {
        _ranges ??= new ConstantGrowArray<Range>(1, Range.Comparer);
        _ranges.Add(new Range(start, end));

        return this;
    }

    /// <summary>Only increase the invalid counter if we haven't already reported it.</summary>
    private void ReportInvalid(int index)
    {
        if (_invalidIndex![index])
            return;

        _invalidIndex[index] = true;
        _invalidCount++;
    }
}