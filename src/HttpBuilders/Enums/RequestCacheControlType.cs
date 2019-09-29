using System.ComponentModel.DataAnnotations;

namespace Genbox.HttpBuilders.Enums
{
    public enum RequestCacheControlType
    {
        Unknown = 0,

        /// <summary>
        /// The "max-age" request directive indicates that the client is unwilling to accept a response whose age is greater than
        /// the specified number of seconds.
        /// </summary>
        [Display(Name = "max-age")]
        MaxAge,

        /// <summary>
        /// The "max-stale" request directive indicates that the client is willing to accept a response that has exceeded its
        /// freshness lifetime. If max-stale is assigned a value, then the client is willing to accept a response that has exceeded
        /// its freshness lifetime by no more than the specified number of seconds.
        /// </summary>
        [Display(Name = "max-stale")]
        MaxStale,

        /// <summary>
        /// The "min-fresh" request directive indicates that the client is willing to accept a response whose freshness lifetime is
        /// no less than its current age plus the specified time in seconds. That is, the client wants a response that will still
        /// be fresh for at least the specified number of seconds.
        /// </summary>
        [Display(Name = "min-fresh")]
        MinFresh,

        /// <summary>
        /// The "no-cache" request directive indicates that a cache MUST NOT use a stored response to satisfy the request without
        /// successful validation on the origin server.
        /// </summary>
        [Display(Name = "no-cache")]
        NoCache,

        /// <summary>
        /// The "no-store" request directive indicates that a cache MUST NOT store any part of either this request or any response
        /// to it. "MUST NOT store" in this context means that the cache MUST NOT intentionally store the information in
        /// non-volatile storage, and MUST make a best-effort attempt to remove the information from volatile storage as promptly
        /// as possible after forwarding it.
        /// </summary>
        [Display(Name = "no-store")]
        NoStore,

        /// <summary>
        /// The "no-transform" request directive indicates that an intermediary (whether or not it implements a cache) MUST NOT
        /// transform the payload.
        /// </summary>
        [Display(Name = "no-transform")]
        NoTransform,

        /// <summary>
        /// The "only-if-cached" request directive indicates that the client only wishes to obtain a stored response.
        /// </summary>
        [Display(Name = "only-if-cached")]
        OnlyIfCached
    }
}