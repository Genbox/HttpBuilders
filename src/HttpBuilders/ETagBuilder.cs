using System.Text;
using HttpBuilders.Abstracts;

namespace HttpBuilders
{
    /// <summary>
    /// Builds an ETag according to RFC7232. See https://tools.ietf.org/html/rfc7232#section-2.3
    /// </summary>
    public class ETagBuilder : IHttpHeaderBuilder
    {
        private string _value;
        private bool _weak;

        public void Set(string value, bool weak = false)
        {
            _value = value;
            _weak = weak;
        }

        public string Build()
        {
            if (_value == null)
                return null;

            StringBuilder sb = new StringBuilder();

            if (_weak)
                sb.Append("W/");

            sb.Append(_value);

            return sb.ToString();
        }
    }
}