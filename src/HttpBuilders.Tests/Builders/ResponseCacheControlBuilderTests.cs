using System;
using Genbox.HttpBuilders.Enums;
using Xunit;

namespace Genbox.HttpBuilders.Tests.Builders
{
    public class ResponseCacheControlBuilderTests
    {
        [Fact]
        public void WithoutArgument()
        {
            ResponseCacheControlBuilder b = new ResponseCacheControlBuilder();
            b.Set(ResponseCacheControlType.NoCache, "fieldname");

            Assert.Equal("no-cache=fieldname", b.Build());
        }

        [Fact]
        public void WithoutArgumentFail()
        {
            ResponseCacheControlBuilder b = new ResponseCacheControlBuilder();
            Assert.Throws<ArgumentException>(() => b.Set(ResponseCacheControlType.MustRevalidate, "42"));
            Assert.Throws<ArgumentException>(() => b.Set(ResponseCacheControlType.MaxAge, "bla"));
        }

        [Fact]
        public void WithArgument()
        {
            ResponseCacheControlBuilder b = new ResponseCacheControlBuilder();
            b.Set(ResponseCacheControlType.MaxAge, "42");

            Assert.Equal("max-age=42", b.Build());
        }
    }
}
