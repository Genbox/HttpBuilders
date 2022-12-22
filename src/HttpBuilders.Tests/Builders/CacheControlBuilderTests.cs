using Genbox.HttpBuilders.Enums;
using Xunit;

namespace Genbox.HttpBuilders.Tests.Builders;

public class CacheControlBuilderTests
{
    [Fact]
    public void WithArgument()
    {
        CacheControlBuilder b = new CacheControlBuilder();
        b.Add(CacheControlType.MaxAge, 42);

        Assert.Equal("max-age=42", b.Build());

        b.Reset();
        Assert.Null(b.Build());
    }

    [Fact]
    public void WithoutArgument()
    {
        CacheControlBuilder b = new CacheControlBuilder();
        b.Add(CacheControlType.NoCache);

        Assert.Equal("no-cache", b.Build());
    }

    [Fact]
    public void MultipleArguments()
    {
        CacheControlBuilder b = new CacheControlBuilder();
        b.Add(CacheControlType.MaxAge, 604800);
        b.Add(CacheControlType.StaleWhileRevalidate, 86400);

        Assert.Equal("max-age=604800,stale-while-revalidate=86400", b.Build());
    }

    [Fact]
    public void WithoutArgumentFail()
    {
        CacheControlBuilder b = new CacheControlBuilder();
        Assert.Throws<ArgumentException>(() => b.Add(CacheControlType.NoCache, 42));
    }
}