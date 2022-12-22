namespace Genbox.HttpBuilders.Enums;

public enum CacheControlType
{
    Unknown = 0,

    /// <summary>The "max-age" request directive indicates that the client is unwilling to accept a response whose age is greater than the specified number of seconds.</summary>
    MaxAge,

    /// <summary>The "max-stale" request directive indicates that the client is willing to accept a response that has exceeded its freshness lifetime. If max-stale is assigned a value,
    /// then the client is willing to accept a response that has exceeded its freshness lifetime by no more than the specified number of seconds.</summary>
    MaxStale,

    /// <summary>The "min-fresh" request directive indicates that the client is willing to accept a response whose freshness lifetime is no less than its current age plus the specified
    /// time in seconds. That is, the client wants a response that will still be fresh for at least the specified number of seconds.</summary>
    MinFresh,

    /// <summary>The "s-maxage" response directive indicates how long the response is fresh for (similar to max-age) — but it is specific to shared caches, and they will ignore max-age
    /// when it is present.</summary>
    SMaxAge,

    /// <summary>The "no-cache" request directive indicates that a cache MUST NOT use a stored response to satisfy the request without successful validation on the origin server.</summary>
    NoCache,

    /// <summary>The "no-store" request directive indicates that a cache MUST NOT store any part of either this request or any response to it. "MUST NOT store" in this context means that
    /// the cache MUST NOT intentionally store the information in non-volatile storage, and MUST make a best-effort attempt to remove the information from volatile storage as promptly as
    /// possible after forwarding it.</summary>
    NoStore,

    /// <summary>The "no-transform" request directive indicates that an intermediary (whether or not it implements a cache) MUST NOT transform the payload.</summary>
    NoTransform,

    /// <summary>The "only-if-cached" request directive indicates that the client only wishes to obtain a stored response.</summary>
    OnlyIfCached,

    /// <summary>The must-revalidate response directive indicates that the response can be stored in caches and can be reused while fresh. If the response becomes stale, it must be
    /// validated with the origin server before reuse.</summary>
    MustRevalidate,

    /// <summary>The proxy-revalidate response directive is the equivalent of must-revalidate, but specifically for shared caches only.</summary>
    ProxyRevalidate,

    /// <summary>The must-understand response directive indicates that a cache should store the response only if it understands the requirements for caching based on status code.</summary>
    MustUnderstand,

    /// <summary>The private response directive indicates that the response can be stored only in a private cache (e.g. local caches in browsers).</summary>
    Private,

    /// <summary>The public response directive indicates that the response can be stored in a shared cache. Responses for requests with Authorization header fields must not be stored in a
    /// shared cache; however, the public directive will cause such responses to be stored in a shared cache.</summary>
    Public,

    /// <summary>The immutable response directive indicates that the response will not be updated while it's fresh.</summary>
    Immutable,

    /// <summary>The stale-while-revalidate response directive indicates that the cache could reuse a stale response while it revalidates it to a cache.</summary>
    StaleWhileRevalidate,

    /// <summary>The stale-if-error response directive indicates that the cache can reuse a stale response when an upstream server generates an error, or when the error is generated
    /// locally. Here, an error is considered any response with a status code of 500, 502, 503, or 504.</summary>
    StaleIfError
}