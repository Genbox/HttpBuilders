using System.Linq;
using System.Text;
using Genbox.HttpBuilders.Abstracts;
using Genbox.HttpBuilders.Enums;
using Genbox.HttpBuilders.Extensions;
using Genbox.HttpBuilders.Internal.Collections;
using Genbox.HttpBuilders.Internal.Extensions;

namespace Genbox.HttpBuilders
{
    /// <summary>
    /// The Content-Encoding entity header is used to compress the media-type. When present, its value indicates which
    /// encodings were applied to the entity-body. It lets the client know how to decode in order to obtain the media-type
    /// referenced by the Content-Type header.
    /// For more info, see https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Encoding
    /// </summary>
    public class ContentEncodingBuilder : IHttpHeaderBuilder
    {
        private ConstantGrowArray<ContentEncodingType> _encodings;

        public string HeaderName => "Content-Encoding";

        public string Build()
        {
            if (_encodings == null)
                return null;

            StringBuilder sb = new StringBuilder();
            sb.AppendJoin(", ", _encodings.Select(x => x.GetMemberValue()));
            return sb.ToString();
        }

        public ContentEncodingBuilder Add(ContentEncodingType encoding)
        {
            if (_encodings == null)
                _encodings = new ConstantGrowArray<ContentEncodingType>(1);

            _encodings.Add(encoding);

            return this;
        }
    }
}