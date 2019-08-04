using System;
using Genbox.HttpBuilders.Enums;
using Xunit;

namespace Genbox.HttpBuilders.Tests.Builders
{
    public class RequestCacheControlBuilderTests
    {
        [Fact]
        public void WithoutArgument()
        {
            RequestCacheControlBuilder b = new RequestCacheControlBuilder();
            b.Set(RequestCacheControlType.NoCache);

            Assert.Equal("no-cache", b.Build());
        }

        [Fact]
        public void WithoutArgumentFail()
        {
            RequestCacheControlBuilder b = new RequestCacheControlBuilder();
            Assert.Throws<ArgumentException>(() => b.Set(RequestCacheControlType.NoCache, 42));
        }

        [Fact]
        public void WithArgument()
        {
            RequestCacheControlBuilder b = new RequestCacheControlBuilder();
            b.Set(RequestCacheControlType.MaxAge, 42);

            Assert.Equal("max-age=42", b.Build());
        }
    }
}
