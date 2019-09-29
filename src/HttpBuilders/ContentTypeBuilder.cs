using System.Text;
using Genbox.HttpBuilders.Abstracts;

namespace Genbox.HttpBuilders
{
    public class ContentTypeBuilder : IHttpHeaderBuilder
    {
        private string _boundary;
        private string _charset;
        private string _mediaType;

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