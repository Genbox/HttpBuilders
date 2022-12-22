using Genbox.HttpBuilders.Enums;

namespace Genbox.HttpBuilders.Extensions;

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
            CacheControlType.SMaxAge => "s-max-age",
            CacheControlType.MustRevalidate => "must-revalidate",
            CacheControlType.ProxyRevalidate => "proxy-revalidate",
            CacheControlType.MustUnderstand => "must-understand",
            CacheControlType.Private => "private",
            CacheControlType.Public => "public",
            CacheControlType.Immutable => "immutable",
            CacheControlType.StaleWhileRevalidate => "stale-while-revalidate",
            CacheControlType.StaleIfError => "stable-if-error",
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }
}