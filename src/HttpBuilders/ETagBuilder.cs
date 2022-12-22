using System.Text;
using Genbox.HttpBuilders.Abstracts;

namespace Genbox.HttpBuilders;

/// <summary>
/// The ETag HTTP response header is an identifier for a specific version of a resource. It lets caches be more efficient and save bandwidth, as
/// a web server does not need to resend a full response if the content has not changed. Additionally, etags help prevent simultaneous updates of a
/// resource from overwriting each other ("mid-air collisions"). If the resource at a given URL changes, a new Etag value must be generated. A comparison
/// of them can determine whether two representations of a resource are the same. Etags are therefore similar to fingerprints, and might also be used for
/// tracking purposes by some servers. They might also be set to persist indefinitely by a tracking server. This builder creates an ETag according to
/// RFC7232. See https://tools.ietf.org/html/rfc7232#section-2.3 For more info, see https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/ETag
/// </summary>
public class ETagBuilder : IHttpHeaderBuilder
{
    private StringBuilder? _sb;
    private string? _value;
    private bool _weak;

    public string HeaderName => "ETag";

    public string? Build()
    {
        if (!HasData())
            return null;

        if (_sb == null)
            _sb = new StringBuilder(25);
        else
            _sb.Clear();

        if (_weak)
            _sb.Append("W/");

        _sb.Append(_value);

        return _sb.ToString();
    }

    public void Reset()
    {
        _value = null;
        _weak = false;
    }

    public bool HasData()
    {
        return _value != null;
    }

    public void Set(string? value, bool weak = false)
    {
        _value = value;
        _weak = weak;
    }
}