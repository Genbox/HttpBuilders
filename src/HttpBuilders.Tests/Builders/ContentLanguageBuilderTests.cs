using HttpBuilders.Enums;
using Xunit;

namespace HttpBuilders.Tests.Builders
{
    public class ContentLanguageBuilderTests
    {
        [Fact]
        public void SingleLanguage()
        {
            ContentLanguageBuilder b = new ContentLanguageBuilder();
            b.Add("da-DK");
            Assert.Equal("da-DK", b.Build());
        }

        [Fact]
        public void MultipleLanguages()
        {
            ContentLanguageBuilder b = new ContentLanguageBuilder();
            b.Add("da-DK");
            b.Add("en-US");
            Assert.Equal("da-DK, en-US", b.Build());
        }

        [Fact]
        public void EnumLanguages()
        {
            ContentLanguageBuilder b = new ContentLanguageBuilder();
            b.Add(Language.French);
            b.Add(Language.German);
            Assert.Equal("fr, de", b.Build());
        }
    }
}
