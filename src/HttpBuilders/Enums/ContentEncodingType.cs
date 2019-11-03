namespace Genbox.HttpBuilders.Enums
{
    public enum ContentEncodingType
    {
        Unknown = 0,

        /// <summary>A format using the Lempel-Ziv coding (LZ77), with a 32-bit CRC</summary>
        Gzip,

        /// <summary>A format using the Lempel-Ziv-Welch (LZW) algorithm.</summary>
        Compress,

        /// <summary>Using the zlib structure (defined in RFC 1950) with the deflate compression algorithm (defined in RFC 1951).</summary>
        Deflate,

        /// <summary>
        /// Indicates the identity function (i.e., no compression or modification). This token, except if explicitly specified, is always deemed
        /// acceptable.
        /// </summary>
        Identity,

        /// <summary>A format using the Brotli algorithm.</summary>
        Brotli
    }
}