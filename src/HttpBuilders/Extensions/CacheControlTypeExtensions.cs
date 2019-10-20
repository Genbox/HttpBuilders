using System;
using Genbox.HttpBuilders.Enums;

namespace Genbox.HttpBuilders.Extensions
{
    public static class CacheControlTypeExtensions
    {
        public static string GetMemberValue(this CacheControlType type)
        {
            switch (type)
            {
                case CacheControlType.MaxAge:
                    return "max-age";
                case CacheControlType.MaxStale:
                    return "max-stale";
                case CacheControlType.MinFresh:
                    return "min-fresh";
                case CacheControlType.NoCache:
                    return "no-cache";
                case CacheControlType.NoStore:
                    return "no-store";
                case CacheControlType.NoTransform:
                    return "no-transform";
                case CacheControlType.OnlyIfCached:
                    return "only-if-cached";
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}