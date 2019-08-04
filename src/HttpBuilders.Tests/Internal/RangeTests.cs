using Genbox.HttpBuilders.Internal;
using Xunit;

namespace Genbox.HttpBuilders.Tests.Internal
{
    public class RangeTests
    {
        [Fact]
        public void Equality()
        {
            Range a = new Range(1, 2);
            Range b = new Range(1, 2);

            Assert.Equal(a, b);
        }

        [Fact]
        public void Comparer()
        {
            Range a = new Range(0, 0);
            Range b = new Range(1, 0);
            Range c = new Range(2, 0);

            Assert.Equal(0, Range.Comparer.Compare(a, a));
            Assert.Equal(-1, Range.Comparer.Compare(a, b));
            Assert.Equal(-1, Range.Comparer.Compare(a, c));
            Assert.Equal(1, Range.Comparer.Compare(b, a));
            Assert.Equal(-1, Range.Comparer.Compare(b, c));
        }

        [Fact]
        public void RangeToString()
        {
            Range a = new Range(1, 2);

            Assert.Equal("1-2", a.ToString());
        }
    }
}
