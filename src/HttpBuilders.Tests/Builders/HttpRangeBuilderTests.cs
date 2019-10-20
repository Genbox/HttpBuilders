using Genbox.HttpBuilders.BuilderOptions;
using Microsoft.Extensions.Options;
using Xunit;

namespace Genbox.HttpBuilders.Tests.Builders
{
    public class HttpRangeBuilderTests
    {
        private RangeBuilder CreateBuilder()
        {
            return new RangeBuilder(Options.Create(new RangeOptions
            {
                MergeOverlappingRanges = false,
                ShortenRanges = false,
                DiscardInvalidRanges = false,
                SortRanges = false
            }));
        }

        [Fact]
        public void DiscardInvalidRanges()
        {
            RangeBuilder b = CreateBuilder();
            b.Add(-1, 10);
            b.Add(5, 110);

            Assert.Equal("bytes=-1-10,5-110", b.Build("bytes", 100));

            b.Options.Value.DiscardInvalidRanges = true;
            Assert.Null(b.Build("bytes", 100));

            b.Add(6, 10);
            Assert.Equal("bytes=6-10", b.Build("bytes", 100));
        }

        [Fact]
        public void MergeOverlappingRanges()
        {
            RangeBuilder b = CreateBuilder();
            b.Add(0, 10);
            b.Add(10, 11); //start and end is the same as other ranges
            b.Add(0, 10); //duplicate overlap
            b.Add(5, 11); //overlap that is not ordered
            b.Add(15, 20); //a non-overlapping range
            b.Add(5, 6); //small range after overlaps

            Assert.Equal("bytes=0-10,10-11,0-10,5-11,15-20,5-6", b.Build());

            b.Options.Value.MergeOverlappingRanges = true;
            Assert.Equal("bytes=0-11,15-20", b.Build());
        }

        [Fact]
        public void MultipleRanges()
        {
            RangeBuilder b = CreateBuilder();
            b.Add(0, 10);
            b.Add(100, 200);

            Assert.Equal("bytes=0-10,100-200", b.Build());
        }

        [Fact]
        public void ShortenRanges()
        {
            RangeBuilder b = CreateBuilder();
            b.Add(0, 10);
            b.Add(11, 100);

            Assert.Equal("bytes=0-10,11-100", b.Build("bytes", 100));

            b.Options.Value.ShortenRanges = true;
            Assert.Equal("bytes=0-10,11-", b.Build("bytes", 100));
        }

        [Fact]
        public void SingleRange()
        {
            RangeBuilder b = CreateBuilder();
            b.Add(0, 10);

            Assert.Equal("bytes=0-10", b.Build());
        }

        [Fact]
        public void SortRanges()
        {
            RangeBuilder b = CreateBuilder();
            b.Add(2, 3);
            b.Add(1, 2);

            Assert.Equal("bytes=2-3,1-2", b.Build());

            b.Options.Value.SortRanges = true;
            Assert.Equal("bytes=1-2,2-3", b.Build());
        }

        [Fact]
        public void ZeroRange()
        {
            RangeBuilder b = CreateBuilder();
            Assert.Null(b.Build());
        }
    }
}