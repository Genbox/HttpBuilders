using System;
using Genbox.HttpBuilders.Enums;
using Xunit;

namespace Genbox.HttpBuilders.Tests.Builders
{
    public class CacheControlBuilderTests
    {
        [Fact]
        public void WithArgument()
        {
            CacheControlBuilder b = new CacheControlBuilder();
            b.Set(CacheControlType.MaxAge, 42);

            Assert.Equal("max-age=42", b.Build());

            b.Reset();
            Assert.Null(b.Build());
        }

        [Fact]
        public void WithoutArgument()
        {
            CacheControlBuilder b = new CacheControlBuilder();
            b.Set(CacheControlType.NoCache);

            Assert.Equal("no-cache", b.Build());
        }

        [Fact]
        public void WithoutArgumentFail()
        {
            CacheControlBuilder b = new CacheControlBuilder();
            Assert.Throws<ArgumentException>(() => b.Set(CacheControlType.NoCache, 42));
        }
    }
}