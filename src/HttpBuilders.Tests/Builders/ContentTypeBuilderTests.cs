using Genbox.HttpBuilders.Enums;
using Xunit;

namespace Genbox.HttpBuilders.Tests.Builders
{
    public class ContentTypeBuilderTests
    {
        [Fact]
        public void CharsetTest()
        {
            ContentTypeBuilder b = new ContentTypeBuilder();
            b.Set("text/html", "utf-8");
            Assert.Equal("text/html;charset=utf-8", b.Build());

            b.Set(MediaType.Application_json, Charset.Utf_8);
            Assert.Equal("application/json;charset=utf-8", b.Build());

            b.Reset();
            Assert.Null(b.Build());
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