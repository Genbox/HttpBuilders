using System.ComponentModel.DataAnnotations;

namespace HttpBuilders.Enums
{
    public enum ResponseCacheControlType
    {
        Unknown = 0,

        /// <summary>
        ///  The "must-revalidate" response directive indicates that once it has become stale, a cache MUST NOT use the response to satisfy subsequent requests without successful validation on the origin server.
        /// </summary>
        [Display(Name = "must-revalidate")]
        MustRevalidate,

        /// <summary>
        /// The "no-cache" response directive indicates that the response MUST NOT be used to satisfy a subsequent request without successful validation on the origin server. This allows an origin server to prevent a cache from using it to satisfy a request without contacting it, even by caches that have been configured to send stale responses.
        /// </summary>
        [Display(Name = "no-cache")]
        NoCache,

        /// <summary>
        /// The "no-store" response directive indicates that a cache MUST NOT store any part of either the immediate request or response. "MUST NOT store" in this context means that the cache MUST NOT intentionally store the information in non-volatile storage, and MUST make a best-effort attempt to remove the information from volatile storage as promptly as possible after forwarding it.
        /// </summary>
        [Display(Name = "no-store")]
        NoStore,

        /// <summary>
        /// The "no-transform" response directive indicates that an intermediary (regardless of whether it implements a cache) MUST NOT transform the payload.
        /// </summary>
        [Display(Name = "no-transform")]
        NoTransform,

        /// <summary>
        /// The "public" response directive indicates that any cache MAY store the response, even if the response would normally be non-cacheable or cacheable only within a private cache.
        /// </summary>
        [Display(Name = "public")]
        Public,

        /// <summary>
        /// The "private" response directive indicates that the response message is intended for a single user and MUST NOT be stored by a shared cache. A private cache MAY store the response and reuse it for later requests, even if the response would normally be non-cacheable.
        /// </summary>
        [Display(Name = "private")]
        Private,

        /// <summary>
        /// The "proxy-revalidate" response directive has the same meaning as the must-revalidate response directive, except that it does not apply to private caches.
        /// </summary>
        [Display(Name = "proxy-revalidate")]
        ProxyRevalidate,

        /// <summary>
        /// The "max-age" response directive indicates that the response is to be considered stale after its age is greater than the specified number of seconds.
        /// </summary>
        [Display(Name = "max-age")]
        MaxAge,

        /// <summary>
        /// The "s-maxage" response directive indicates that, in shared caches, the maximum age specified by this directive overrides the maximum age specified by either the max-age directive or the Expires header field. The s-maxage directive also implies the semantics of the proxy-revalidate response directive.
        /// </summary>
        [Display(Name = "s-maxage")]
        SMaxAge,
    }
}