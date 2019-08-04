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
    public class ResponseCacheControlBuilder : IHttpHeaderBuilder
    {
        private ResponseCacheControlType _type;
        private string _argument;

        public void Set(ResponseCacheControlType type, string argument = null)
        {
            CheckOptionalArgument(type, argument);

            _type = type;
            _argument = argument;
        }

        public string Build()
        {
            if (_type == ResponseCacheControlType.Unknown)
                return null;

            StringBuilder sb = new StringBuilder();
            sb.Append(_type.AsString(EnumFormat.DisplayName));

            //TODO: The specification is rather confusing on string arguments for cache control arguments. I think they need to be encased in quotes, and there can be multiple arguments

            if (_argument != null)
                sb.Append('=').Append(_argument);

            return sb.ToString();
        }

        private void CheckOptionalArgument(ResponseCacheControlType type, string argument)
        {
            if (argument == null)
            {
                switch (type)
                {
                    case ResponseCacheControlType.NoCache:
                    case ResponseCacheControlType.Private:
                    case ResponseCacheControlType.MaxAge:
                    case ResponseCacheControlType.SMaxAge:
                        throw new ArgumentException("You must supply an argument", nameof(type));
                }
            }
            else
            {
                switch (type)
                {
                    case ResponseCacheControlType.MaxAge:
                    case ResponseCacheControlType.SMaxAge:
                        {
                            if (!int.TryParse(argument, out _))
                                throw new ArgumentException("You must supply an argument in seconds", nameof(type));

                            break;
                        }
                    case ResponseCacheControlType.MustRevalidate:
                    case ResponseCacheControlType.NoStore:
                    case ResponseCacheControlType.NoTransform:
                    case ResponseCacheControlType.Public:
                    case ResponseCacheControlType.ProxyRevalidate:
                        throw new ArgumentException("You supplied an argument to a cache type that does not support it", nameof(type));
                }
            }
        }
    }
}
