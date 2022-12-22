using System;
using System.Collections.Generic;

namespace Genbox.HttpBuilders.Internal;

internal struct Range : IEquatable<Range>
{
    private sealed class StartRelationalComparer : IComparer<Range>
    {
        public int Compare(Range x, Range y)
        {
            return x.Start.CompareTo(y.Start);
        }
    }

    public static IComparer<Range> Comparer { get; } = new StartRelationalComparer();

    public Range(long start, long end)
    {
        Start = start;
        End = end;
    }

    public bool Equals(Range other)
    {
        return Start == other.Start && End == other.End;
    }

    public override bool Equals(object obj)
    {
        return obj is Range other && Equals(other);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return (Start.GetHashCode() * 397) ^ End.GetHashCode();
        }
    }

    public long Start { get; }
    public long End { get; set; }

    public override string ToString()
    {
        return $"{Start}-{End}";
    }
}