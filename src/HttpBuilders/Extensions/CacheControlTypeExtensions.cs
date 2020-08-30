using System;
using Genbox.HttpBuilders.Enums;

namespace Genbox.HttpBuilders.Extensions
{
    public static class CacheControlTypeExtensions
    {
        public static string GetMemberValue(this CacheControlType type)
        {
            return type switch
            {
                CacheControlType.MaxAge => "max-age",
                CacheControlType.MaxStale => "max-stale",
                CacheControlType.MinFresh => "min-fresh",
                CacheControlType.NoCache => "no-cache",
                CacheControlType.NoStore => "no-store",
                CacheControlType.NoTransform => "no-transform",
                CacheControlType.OnlyIfCached => "only-if-cached",
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}