using System;
using System.Text;
using Genbox.HttpBuilders.Abstracts;
using Genbox.HttpBuilders.BuilderOptions;
using Genbox.HttpBuilders.Enums;
using Genbox.HttpBuilders.Extensions;
using Genbox.HttpBuilders.Internal.Collections;
using Microsoft.Extensions.Options;

namespace Genbox.HttpBuilders
{
    /// <summary>
    /// The Accept-Encoding request HTTP header advertises which content encoding, usually a compression algorithm, the client
    /// is able to understand. Using content negotiation, the server selects one of the proposals, uses it and informs the
    /// client of its choice with the Content-Encoding response header.
    /// For more info, see https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Accept-Encoding
    /// For info on weights, see https://developer.mozilla.org/en-US/docs/Glossary/Quality_values
    /// </summary>
    public class AcceptEncodingBuilder : IHttpHeaderBuilder
    {
        private ConstantGrowArray<(AcceptEncodingType, float)> _encodings;
        private StringBuilder _sb;

        public AcceptEncodingBuilder()
        {
            Options = Microsoft.Extensions.Options.Options.Create(new AcceptEncodingOptions());
        }

        public AcceptEncodingBuilder(IOptions<AcceptEncodingOptions> options)
        {
            Options = options;
        }

        public IOptions<AcceptEncodingOptions> Options { get; }

        public string HeaderName => "Accept-Encoding";

        public string Build()
        {
            if (_encodings == null)
                return null;

            if (_sb == null)
                _sb = new StringBuilder(25);
            else
                _sb.Clear();

            for (int i = 0; i < _encodings.Count; i++)
            {
                (AcceptEncodingType type, float weight) = _encodings[i];

                _sb.Append(type.GetMemberValue());

                if (!Options.Value.OmitDefaultWeight || Math.Abs(weight - 1.0f) > 0.00001f)
                    _sb.Append(";q=").Append(weight);

                if (i < _encodings.Count - 1)
                    _sb.Append(", ");
            }

            return _sb.ToString();
        }

        public AcceptEncodingBuilder Add(AcceptEncodingType encoding, float weight = 1.0f)
        {
            if (_encodings == null)
                _encodings = new ConstantGrowArray<(AcceptEncodingType, float)>(1);

            _encodings.Add((encoding, weight));

            return this;
        }
    }
}