using System;
using System.Text;
using Genbox.HttpBuilders.Abstracts;
using Genbox.HttpBuilders.Enums;
using Genbox.HttpBuilders.Extensions;

namespace Genbox.HttpBuilders
{
    /// <summary>
    /// The "Cache-Control" header field is used to specify directives for caches along the request/response chain.
    /// For more info, see https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Cache-Control
    /// </summary>
    public class CacheControlBuilder : IHttpHeaderBuilder
    {
        private int _seconds;
        private CacheControlType _type;
        private StringBuilder _sb;

        public string HeaderName => "Cache-Control";

        public string Build()
        {
            if (_type == CacheControlType.Unknown)
                return null;

            if (_sb == null)
                _sb = new StringBuilder(25);
            else
                _sb.Clear();

            _sb.Append(_type.GetMemberValue());

            if (_seconds > -1)
                _sb.Append('=').Append(_seconds);

            return _sb.ToString();
        }

        public void Set(CacheControlType type, int seconds = -1)
        {
            CheckOptionalArgument(type, seconds);

            _type = type;
            _seconds = seconds;
        }

        private void CheckOptionalArgument(CacheControlType type, int seconds)
        {
            if (seconds <= -1)
                switch (type)
                {
                    case CacheControlType.MaxAge:
                    case CacheControlType.MaxStale:
                    case CacheControlType.MinFresh:
                        throw new ArgumentException("You must supply an argument in seconds", nameof(type));
                }
            else
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
}