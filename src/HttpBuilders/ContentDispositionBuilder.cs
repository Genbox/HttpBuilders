using System;
using System.Text;
using Genbox.HttpBuilders.Abstracts;
using Genbox.HttpBuilders.BuilderOptions;
using Genbox.HttpBuilders.Enums;
using Genbox.HttpBuilders.Extensions;
using Microsoft.Extensions.Options;

namespace Genbox.HttpBuilders;

/// <summary>
/// In a regular HTTP response, the Content-Disposition response header is a header indicating if the content is expected to be displayed inline
/// in the browser, that is, as a Web page or as part of a Web page, or as an attachment, that is downloaded and saved locally. In a multipart/form-data
/// body, the HTTP Content-Disposition general header is a header that can be used on the subpart of a multipart body to give information about the field
/// it applies to. The subpart is delimited by the boundary defined in the Content-Type header. Used on the body itself, Content-Disposition has no
/// effect. For more info, see https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Disposition
/// </summary>
public class ContentDispositionBuilder : IHttpHeaderBuilder
{
    private string? _filename;
    private StringBuilder? _sb;
    private ContentDispositionType _type;

    public ContentDispositionBuilder()
    {
        Options = Microsoft.Extensions.Options.Options.Create(new ContentDispositionOptions());
    }

    public ContentDispositionBuilder(IOptions<ContentDispositionOptions> options)
    {
        Options = options;
    }

    public IOptions<ContentDispositionOptions> Options { get; }

    public string HeaderName => "Content-Disposition";

    public string? Build()
    {
        if (!HasData())
            return null;

        if (Options.Value.OmitDefaultDisposition && _type == ContentDispositionType.Inline)
            return null;

        if (_sb == null)
            _sb = new StringBuilder(25);
        else
            _sb.Clear();

        _sb.Append(_type.GetMemberValue());

        if (_filename != null)
            _sb.Append("; filename").Append(Options.Value.UseExtendedFilename ? "*" : null).Append("=\"").Append(_filename).Append('"');

        return _sb.ToString();
    }

    public void Reset()
    {
        _filename = null;
        _type = ContentDispositionType.Unknown;
    }

    public bool HasData()
    {
        return _type != ContentDispositionType.Unknown;
    }

    public void Set(ContentDispositionType type, string? filename = null)
    {
        if (type == ContentDispositionType.Attachment && filename == null)
            throw new ArgumentException("You have to supply a filename", nameof(filename));

        if (type == ContentDispositionType.Inline && filename != null)
            throw new ArgumentException("You supplied a filename to Inline. That is not permitted", nameof(filename));

        _type = type;
        _filename = filename;
    }
}