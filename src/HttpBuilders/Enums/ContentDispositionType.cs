using System.ComponentModel.DataAnnotations;

namespace Genbox.HttpBuilders.Enums
{
    public enum ContentDispositionType
    {
        Unknown = 0,

        [Display(Name = "inline")]
        Inline,

        [Display(Name = "attachment")]
        Attachment
    }
}