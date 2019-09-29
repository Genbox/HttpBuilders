using System;
using System.Text;
using EnumsNET;
using Genbox.HttpBuilders.Abstracts;
using Genbox.HttpBuilders.Enums;

namespace Genbox.HttpBuilders
{
    /// <summary>
    /// The "Cache-Control" header field is used to specify directives for caches along the request/response chain.
    /// </summary>
    public class CacheControlBuilder : IHttpHeaderBuilder
    {
        private int _seconds;
        private RequestCacheControlType _type;

        public string Build()
        {
            if (_type == RequestCacheControlType.Unknown)
                return null;

            StringBuilder sb = new StringBuilder();
            sb.Append(_type.AsString(EnumFormat.DisplayName));

            if (_seconds > -1)
                sb.Append('=').Append(_seconds);

            return sb.ToString();
        }

        public void Set(RequestCacheControlType type, int seconds = -1)
        {
            CheckOptionalArgument(type, seconds);

            _type = type;
            _seconds = seconds;
        }

        private void CheckOptionalArgument(RequestCacheControlType type, int seconds)
        {
            if (seconds <= -1)
                switch (type)
                {
                    case RequestCacheControlType.MaxAge:
                    case RequestCacheControlType.MaxStale:
                    case RequestCacheControlType.MinFresh:
                        throw new ArgumentException("You must supply an argument in seconds", nameof(type));
                }
            else
                switch (type)
                {
                    case RequestCacheControlType.NoCache:
                    case RequestCacheControlType.NoStore:
                    case RequestCacheControlType.NoTransform:
                    case RequestCacheControlType.OnlyIfCached:
                        throw new ArgumentException("You supplied seconds to a cache type that does not support it", nameof(type));
                }
        }
    }
}