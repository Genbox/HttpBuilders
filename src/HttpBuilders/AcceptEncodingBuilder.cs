using System;
using System.Text;
using EnumsNET;
using Genbox.HttpBuilders.Abstracts;
using Genbox.HttpBuilders.Enums;
using Genbox.HttpBuilders.Internal.Collections;
using Genbox.HttpBuilders.Options;
using Microsoft.Extensions.Options;

namespace Genbox.HttpBuilders
{
    /// <summary>
    /// For weight, see https://developer.mozilla.org/en-US/docs/Glossary/Quality_values
    /// </summary>
    public class AcceptEncodingBuilder : IHttpHeaderBuilder
    {
        private ConstantGrowArray<(AcceptEncodingType, float)> _encodings;

        public AcceptEncodingBuilder()
        {
            Options = Microsoft.Extensions.Options.Options.Create(new AcceptEncodingBuilderOptions());
        }

        public AcceptEncodingBuilder(IOptions<AcceptEncodingBuilderOptions> options)
        {
            Options = options;
        }

        public IOptions<AcceptEncodingBuilderOptions> Options { get; }

        public AcceptEncodingBuilder Add(AcceptEncodingType encoding, float weight = 1.0f)
        {
            if (_encodings == null)
                _encodings = new ConstantGrowArray<(AcceptEncodingType, float)>(1);

            _encodings.Add((encoding, weight));

            return this;
        }

        public string Build()
        {
            if (_encodings == null)
                return null;

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < _encodings.Count; i++)
            {
                (AcceptEncodingType type, float weight) = _encodings[i];

                sb.Append(type.AsString(EnumFormat.DisplayName));

                if (!Options.Value.OmitDefaultWeight || Math.Abs(weight - 1.0f) > 0.00001f)
                    sb.Append(";q=").Append(weight);

                if (i < _encodings.Count - 1)
                    sb.Append(", ");
            }

            return sb.ToString();
        }
    }
}