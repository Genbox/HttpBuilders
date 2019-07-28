using System.ComponentModel.DataAnnotations;

namespace HttpBuilders.Enums
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