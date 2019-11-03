using System.Text;
using Genbox.HttpBuilders.Abstracts;
using Genbox.HttpBuilders.Enums;
using Genbox.HttpBuilders.Extensions;

namespace Genbox.HttpBuilders
{
    /// <summary>
    /// The Content-Type entity header is used to indicate the media type of the resource. In responses, a Content-Type header tells the client what
    /// the content type of the returned content actually is. Browsers will do MIME sniffing in some cases and will not necessarily follow the value of this
    /// header; to prevent this behavior, the header X-Content-Type-Options can be set to nosniff. For more info, see
    /// https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Type
    /// </summary>
    public class ContentTypeBuilder : IHttpHeaderBuilder
    {
        private string _boundary;
        private string _charset;
        private string _mediaType;
        private StringBuilder _sb;

        public string HeaderName => "Content-Type";

        public string Build()
        {
            if (_mediaType == null)
                return null;

            if (_sb == null)
                _sb = new StringBuilder(25);
            else
                _sb.Clear();

            _sb.Append(_mediaType);

            if (_charset != null)
                _sb.Append(";charset=").Append(_charset);

            if (_boundary != null)
                _sb.Append(";boundary=").Append(_boundary);

            return _sb.ToString();
        }

        public void Reset()
        {
            _mediaType = null;
            _boundary = null;
            _mediaType = null;
        }

        public void Set(string mediaType, string charset = null, string boundary = null)
        {
            _mediaType = mediaType;
            _charset = charset;
            _boundary = boundary;
        }

        public void Set(MediaType mediaType, Charset charset = Charset.Unknown, string boundary = null)
        {
            _mediaType = mediaType.GetMemberValue();
            _charset = charset.GetMemberValue();
            _boundary = boundary;
        }
    }
}