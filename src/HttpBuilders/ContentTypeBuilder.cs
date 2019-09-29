using System.Text;
using Genbox.HttpBuilders.Abstracts;

namespace Genbox.HttpBuilders
{
    /// <summary>
    /// The Content-Type entity header is used to indicate the media type of the resource. In responses, a Content-Type header
    /// tells the client what the content type of the returned content actually is. Browsers will do MIME sniffing in some
    /// cases and will not necessarily follow the value of this header; to prevent this behavior, the header
    /// X-Content-Type-Options can be set to nosniff.
    /// For more info, see https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Type
    /// </summary>
    public class ContentTypeBuilder : IHttpHeaderBuilder
    {
        private string _boundary;
        private string _charset;
        private string _mediaType;

        public string HeaderName => "Content-Type";

        public string Build()
        {
            if (_mediaType == null)
                return null;

            StringBuilder sb = new StringBuilder();
            sb.Append(_mediaType);

            if (_charset != null)
                sb.Append("; charset=").Append(_charset);

            if (_boundary != null)
                sb.Append("; boundary=").Append(_boundary);

            return sb.ToString();
        }

        public void Set(string mediaType, string charset = null, string boundary = null)
        {
            _mediaType = mediaType;
            _charset = charset;
            _boundary = boundary;
        }
    }
}