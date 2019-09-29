using Xunit;

namespace Genbox.HttpBuilders.Tests.Builders
{
    public class ContentTypeBuilderTests
    {
        [Fact]
        public void Charset()
        {
            ContentTypeBuilder b = new ContentTypeBuilder();
            b.Set("text/html", "utf-8");
            Assert.Equal("text/html; charset=utf-8", b.Build());
        }

        [Fact]
        public void SingleContentType()
        {
            ContentTypeBuilder b = new ContentTypeBuilder();
            b.Set("text/html");
            Assert.Equal("text/html", b.Build());
        }
    }
}