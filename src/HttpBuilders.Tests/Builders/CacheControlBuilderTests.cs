using System;
using Genbox.HttpBuilders.Enums;
using Xunit;

namespace Genbox.HttpBuilders.Tests.Builders
{
    public class CacheControlBuilderTests
    {
        [Fact]
        public void WithoutArgument()
        {
            CacheControlBuilder b = new CacheControlBuilder();
            b.Set(RequestCacheControlType.NoCache);

            Assert.Equal("no-cache", b.Build());
        }

        [Fact]
        public void WithoutArgumentFail()
        {
            CacheControlBuilder b = new CacheControlBuilder();
            Assert.Throws<ArgumentException>(() => b.Set(RequestCacheControlType.NoCache, 42));
        }

        [Fact]
        public void WithArgument()
        {
            CacheControlBuilder b = new CacheControlBuilder();
            b.Set(RequestCacheControlType.MaxAge, 42);

            Assert.Equal("max-age=42", b.Build());
        }
    }
}
