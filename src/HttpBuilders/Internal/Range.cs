using System.Runtime.InteropServices;

namespace Genbox.HttpBuilders.Internal;

[StructLayout(LayoutKind.Auto)]
internal readonly record struct Range(long Start, long End)
{
    private sealed class StartRelationalComparer : IComparer<Range>
    {
        public int Compare(Range x, Range y)
        {
            return x.Start.CompareTo(y.Start);
        }
    }

    public static IComparer<Range> Comparer { get; } = new StartRelationalComparer();

    public long Start { get; } = Start;
    public long End { get; } = End;

    public override string ToString()
    {
        return $"{Start}-{End}";
    }
}