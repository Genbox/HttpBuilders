using Genbox.HttpBuilders.Internal;
using Genbox.HttpBuilders.Internal.Collections;
using Xunit;

namespace Genbox.HttpBuilders.Tests.Internal;

public class ConstantGrowArrayTests
{
    [Fact]
    public void Enumerator()
    {
        ConstantGrowArray<int> a = new ConstantGrowArray<int>(1) { 1, 2, 3 };

        Assert.Contains(a, i => i == 1 || i == 2 || i == 3);
    }

    [Fact]
    public void General()
    {
        ConstantGrowArray<Range> a = new ConstantGrowArray<Range>(1, Range.Comparer) { new Range(1, 2), new Range(3, 6), new Range(2, 4) };

        Assert.Equal(3, a.Count);

        a.Sort();

        Assert.Equal(1, a[0].Start);
        Assert.Equal(2, a[1].Start);
        Assert.Equal(3, a[2].Start);

        Assert.True(a.Sorted);

        a.Add(new Range(4, 19));

        //Since we added a larger range, it should still be sorted.
        Assert.True(a.Sorted);

        a.Add(new Range(3, 20));

        Assert.False(a.Sorted);
    }
}