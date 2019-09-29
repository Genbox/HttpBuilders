using System.ComponentModel.DataAnnotations;

namespace Genbox.HttpBuilders.Enums
{
    public enum ContentEncodingType
    {
        Unknown = 0,

        [Display(Name = "gzip")]
        Gzip,

        [Display(Name = "compress")]
        Compress,

        [Display(Name = "deflate")]
        Deflate,

        [Display(Name = "identity")]
        Identity,

        [Display(Name = "br")]
        Br
    }
}