using Genbox.HttpBuilders.BuilderOptions;
using Genbox.HttpBuilders.Enums;
using Microsoft.Extensions.Options;
using Xunit;

namespace Genbox.HttpBuilders.Tests.Builders
{
    public class AcceptEncodingBuilderTests
    {
        private AcceptEncodingBuilder CreateBuilder()
        {
            return new AcceptEncodingBuilder(Options.Create(new AcceptEncodingOptions
            {
                OmitDefaultWeight = false
            }));
        }

        [Fact]
        public void EncodingsWithWeight()
        {
            AcceptEncodingBuilder b = CreateBuilder();
            b.Add(AcceptEncodingType.Gzip, 0.1f);
            b.Add(AcceptEncodingType.Deflate, 0.2f);
            Assert.Equal("gzip;q=0.1, deflate;q=0.2", b.Build());
        }

        [Fact]
        public void OmitDefaultWeight()
        {
            AcceptEncodingBuilder b = CreateBuilder();
            b.Add(AcceptEncodingType.Gzip);
            b.Add(AcceptEncodingType.Deflate);
            Assert.Equal("gzip;q=1, deflate;q=1", b.Build());

            b.Options.Value.OmitDefaultWeight = true;
            Assert.Equal("gzip, deflate", b.Build());
        }

        [Fact]
        public void SingleEncoding()
        {
            AcceptEncodingBuilder b = CreateBuilder();
            b.Add(AcceptEncodingType.Gzip);
            Assert.Equal("gzip;q=1", b.Build());
        }
    }
}