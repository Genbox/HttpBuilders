using Genbox.HttpBuilders.Enums;

namespace Genbox.HttpBuilders.BuilderOptions;

public class ContentDispositionOptions
{
    /// <summary>Set this to true if you want to use filename characters outside of ISO-8859-1</summary>
    public bool UseExtendedFilename { get; set; } = true;

    /// <summary>If the <see cref="ContentDispositionType" /> is set to Inline, then we can omit the header completely as it is the default header value.</summary>
    public bool OmitDefaultDisposition { get; set; } = true;
}