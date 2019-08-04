using System.Linq;
using System.Text;
using EnumsNET;
using Genbox.HttpBuilders.Abstracts;
using Genbox.HttpBuilders.Enums;
using Genbox.HttpBuilders.Internal.Collections;

namespace Genbox.HttpBuilders
{
    /// <summary>
    /// For weight, see https://developer.mozilla.org/en-US/docs/Glossary/Quality_values
    /// </summary>
    public class ContentEncodingBuilder : IHttpHeaderBuilder
    {
        private ConstantGrowArray<ContentEncodingType> _encodings;

        public ContentEncodingBuilder Add(ContentEncodingType encoding)
        {
            if (_encodings == null)
                _encodings = new ConstantGrowArray<ContentEncodingType>(1);

            _encodings.Add(encoding);

            return this;
        }

        public string Build()
        {
            if (_encodings == null)
                return null;

            StringBuilder sb = new StringBuilder();
            sb.AppendJoin(", ", _encodings.Select(x => x.AsString(EnumFormat.DisplayName)));
            return sb.ToString();
        }
    }
}