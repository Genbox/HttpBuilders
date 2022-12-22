using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using Genbox.HttpBuilders.Abstracts;
using Genbox.HttpBuilders.BuilderOptions;
using Genbox.HttpBuilders.Enums;
using Genbox.HttpBuilders.Extensions;
using Genbox.HttpBuilders.Internal.Collections;
using Microsoft.Extensions.Options;

namespace Genbox.HttpBuilders;

/// <summary>
/// The Accept-Encoding request HTTP header advertises which content encoding, usually a compression algorithm, the client is able to
/// understand. Using content negotiation, the server selects one of the proposals, uses it and informs the client of its choice with the
/// Content-Encoding response header. For more info, see https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Accept-Encoding For info on weights,
/// see https://developer.mozilla.org/en-US/docs/Glossary/Quality_values
/// </summary>
public class AcceptEncodingBuilder : IHttpHeaderBuilder
{
    private ConstantGrowArray<Pair>? _encodings;
    private StringBuilder? _sb;

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

    public string? Build()
    {
        if (!HasData())
            return null;

        if (_sb == null)
            _sb = new StringBuilder(25);
        else
            _sb.Clear();

        for (int i = 0; i < _encodings!.Count; i++)
        {
            Pair pair = _encodings[i];

            _sb.Append(pair.Type.GetMemberValue());

            if (!Options.Value.OmitDefaultWeight || Math.Abs(pair.Weight - 1.0f) > 0.00001f)
                _sb.Append(";q=").Append(pair.Weight.ToString(NumberFormatInfo.InvariantInfo));

            if (i < _encodings.Count - 1)
                _sb.Append(", ");
        }

        return _sb.ToString();
    }

    public void Reset()
    {
        _encodings?.Clear();
    }

    public bool HasData()
    {
        return _encodings != null && _encodings.Count > 0;
    }

    public AcceptEncodingBuilder Add(AcceptEncodingType encoding, float weight = 1.0f)
    {
        if (weight < 0 || weight > 1)
            throw new ArgumentException("Invalid value. It must be a value between 0 and 1 included.", nameof(weight));

        _encodings ??= new ConstantGrowArray<Pair>(1);
        _encodings.Add(new Pair(encoding, weight));

        return this;
    }

    [StructLayout(LayoutKind.Auto)]
    private readonly record struct Pair(AcceptEncodingType Type, float Weight) : IComparable<Pair>
    {
        public AcceptEncodingType Type { get; } = Type;
        public float Weight { get; } = Weight;

        public int CompareTo(Pair other)
        {
            int typeComparison = Type.CompareTo(other.Type);
            if (typeComparison != 0)
                return typeComparison;
            return Weight.CompareTo(other.Weight);
        }
    }
}