using Genbox.HttpBuilders.Enums;
using Xunit;

namespace Genbox.HttpBuilders.Tests.Builders;

public class ContentEncodingBuilderTests
{
    [Fact]
    public void MultipleEncodings()
    {
        ContentEncodingBuilder b = new ContentEncodingBuilder();
        b.Add(ContentEncodingType.Gzip);
        b.Add(ContentEncodingType.Deflate);
        Assert.Equal("gzip, deflate", b.Build());

        b.Reset();
        Assert.Null(b.Build());
    }

    [Fact]
    public void SingleEncoding()
    {
        ContentEncodingBuilder b = new ContentEncodingBuilder();
        b.Add(ContentEncodingType.Gzip);
        Assert.Equal("gzip", b.Build());
    }
}