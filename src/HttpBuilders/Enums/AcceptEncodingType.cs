namespace Genbox.HttpBuilders.Enums
{
    public enum AcceptEncodingType
    {
        Unknown = 0,

        /// <summary>A compression format using the Lempel-Ziv coding (LZ77), with a 32-bit CRC.</summary>
        Gzip,

        /// <summary>A compression format using the Lempel-Ziv-Welch (LZW) algorithm.</summary>
        Compress,

        /// <summary>A compression format using the zlib structure, with the deflate compression algorithm.</summary>
        Deflate,

        /// <summary>Indicates the identity function (i.e. no compression, nor modification). This value is always considered as acceptable, even if not present.</summary>
        Identity,

        /// <summary>A compression format using the Brotli algorithm.</summary>
        Brotli,

        /// <summary>
        /// Matches any content encoding not already listed in the header. This is the default value if the header is not present. It doesn't mean that
        /// any algorithm is supported; merely that no preference is expressed.
        /// </summary>
        Any
    }
}