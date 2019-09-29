using Xunit;

namespace Genbox.HttpBuilders.Tests.Builders
{
    public class EtagBuilderTests
    {
        private ETagBuilder CreateBuilder()
        {
            return new ETagBuilder();
        }

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
    }
}