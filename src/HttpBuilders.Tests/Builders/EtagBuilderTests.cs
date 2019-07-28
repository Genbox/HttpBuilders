using Xunit;

namespace HttpBuilders.Tests.Builders
{
    public class EtagBuilderTests
    {
        [Fact]
        public void SimpleEtag()
        {
            ETagBuilder b = CreateBuilder();
            b.Set("\"myetag\"");
            Assert.Equal("\"myetag\"", b.Build());
        }

        [Fact]
        public void WeakEtag()
        {
            ETagBuilder b = CreateBuilder();
            b.Set("\"myetag\"", true);
            Assert.Equal("W/\"myetag\"", b.Build());
        }

        private ETagBuilder CreateBuilder()
        {
            return new ETagBuilder();
        }
    }
}
