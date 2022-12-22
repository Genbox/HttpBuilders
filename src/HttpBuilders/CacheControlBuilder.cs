using System.Text;
using Genbox.HttpBuilders.Abstracts;
using Genbox.HttpBuilders.Enums;
using Genbox.HttpBuilders.Extensions;
using Genbox.HttpBuilders.Internal.Collections;

namespace Genbox.HttpBuilders;

/// <summary>
/// The "Cache-Control" header field is used to specify directives for caches along the request/response chain. For more info, see
/// https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Cache-Control
/// </summary>
public class CacheControlBuilder : IHttpHeaderBuilder
{
    private StringBuilder? _sb;
    private ConstantGrowArray<CacheTuple>? _cacheTuples;

    public string HeaderName => "Cache-Control";

    public string? Build()
    {
        if (!HasData())
            return null;

        if (_sb == null)
            _sb = new StringBuilder(25);
        else
            _sb.Clear();

        for (int i = 0; i < _cacheTuples!.Count; i++)
        {
            CacheTuple tuple = _cacheTuples[i];
            _sb.Append(tuple.Type.GetMemberValue());

            if (tuple.Seconds > -1)
                _sb.Append('=').Append(tuple.Seconds);

            if (i < _cacheTuples.Count - 1)
                _sb.Append(',');
        }

        return _sb.ToString();
    }

    public void Reset()
    {
        _cacheTuples?.Clear();
    }

    public bool HasData()
    {
        return _cacheTuples != null && _cacheTuples.Count > 0;
    }

    public void Add(CacheControlType type, int seconds = -1)
    {
        CheckOptionalArgument(type, seconds);

        _cacheTuples ??= new ConstantGrowArray<CacheTuple>(1);
        _cacheTuples.Add(new CacheTuple(type, seconds));
    }

    private static void CheckOptionalArgument(CacheControlType type, int seconds)
    {
        if (seconds <= -1)
        {
            switch (type)
            {
                case CacheControlType.MaxAge:
                case CacheControlType.MaxStale:
                case CacheControlType.MinFresh:
                    throw new ArgumentException("You must supply an argument in seconds", nameof(type));
            }
        }
        else
        {
            switch (type)
            {
                case CacheControlType.NoCache:
                case CacheControlType.NoStore:
                case CacheControlType.NoTransform:
                case CacheControlType.OnlyIfCached:
                    throw new ArgumentException("You supplied seconds to a cache type that does not support it", nameof(type));
            }
        }
    }

    private record struct CacheTuple(CacheControlType Type, int Seconds) : IComparable<CacheTuple>
    {
        public int CompareTo(CacheTuple other)
        {
            int typeComparison = Type.CompareTo(other.Type);

            if (typeComparison != 0)
                return typeComparison;

            return Seconds.CompareTo(other.Seconds);
        }
    }
}