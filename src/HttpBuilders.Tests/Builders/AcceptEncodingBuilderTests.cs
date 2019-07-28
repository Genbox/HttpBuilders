using HttpBuilders.Enums;
using HttpBuilders.Options;
using Xunit;

namespace HttpBuilders.Tests.Builders
{
    public class AcceptEncodingBuilderTests
    {
        [Fact]
        public void SingleEncoding()
        {
            AcceptEncodingBuilder b = CreateBuilder();
            b.Add(AcceptEncodingType.Gzip);
            Assert.Equal("gzip;q=1", b.Build());
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
        public void EncodingsWithWeight()
        {
            AcceptEncodingBuilder b = CreateBuilder();
            b.Add(AcceptEncodingType.Gzip, 0.1f);
            b.Add(AcceptEncodingType.Deflate, 0.2f);
            Assert.Equal("gzip;q=0.1, deflate;q=0.2", b.Build());
        }

        private AcceptEncodingBuilder CreateBuilder()
        {
            return new AcceptEncodingBuilder(Microsoft.Extensions.Options.Options.Create(new AcceptEncodingBuilderOptions
            {
                OmitDefaultWeight = false
            }));
        }
    }
}
