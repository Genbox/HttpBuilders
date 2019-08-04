using System;
using Genbox.HttpBuilders.Enums;
using Genbox.HttpBuilders.Options;
using Xunit;

namespace Genbox.HttpBuilders.Tests.Builders
{
    public class ContentDispositionBuilderTests
    {
        [Fact]
        public void UseExtendedFilename()
        {
            ContentDispositionBuilder b = CreateBuilder();
            b.Set(ContentDispositionType.Attachment, "myfile.exe");
            Assert.Equal("attachment; filename=\"myfile.exe\"", b.Build());

            b.Options.Value.UseExtendedFilename = true;
            Assert.Equal("attachment; filename*=\"myfile.exe\"", b.Build());
        }

        [Fact]
        public void AttachmentNoFilename()
        {
            ContentDispositionBuilder b = CreateBuilder();
            Assert.Throws<ArgumentException>(() => b.Set(ContentDispositionType.Attachment));
        }

        [Fact]
        public void InlineWithArgument()
        {
            ContentDispositionBuilder b = CreateBuilder();
            Assert.Throws<ArgumentException>(() => b.Set(ContentDispositionType.Inline, "somearg"));
        }

        [Fact]
        public void OmitDefaultDisposition()
        {
            ContentDispositionBuilder b = CreateBuilder();
            b.Set(ContentDispositionType.Inline);
            Assert.Equal("inline", b.Build());

            b.Options.Value.OmitDefaultDisposition = true;
            Assert.Null(b.Build());
        }

        private ContentDispositionBuilder CreateBuilder()
        {
            return new ContentDispositionBuilder(Microsoft.Extensions.Options.Options.Create(new ContentDispositionBuilderOptions
            {
                UseExtendedFilename = false,
                OmitDefaultDisposition = false
            }));
        }
    }
}
