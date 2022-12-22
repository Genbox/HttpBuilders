using Genbox.HttpBuilders.BuilderOptions;
using Genbox.HttpBuilders.Enums;
using Microsoft.Extensions.Options;

namespace Genbox.HttpBuilders.Examples;

internal static class Program
{
    private static async Task Main()
    {
        //Create a HttpClient
        using (HttpClient client = new HttpClient())
        {
            //Create a builder to the accept-encoding header. We need this to construct which encodings we would like to accept in the response.
            AcceptEncodingBuilder acceptEncoding = new AcceptEncodingBuilder();
            acceptEncoding.Add(AcceptEncodingType.Identity, 0.5f);
            acceptEncoding.Add(AcceptEncodingType.Compress, 0.1f);

            //Add the Accept-Encoding header to the HttpClient
            client.DefaultRequestHeaders.Add(acceptEncoding.HeaderName, acceptEncoding.Build());

            //Now we create some options for the next header. These change the behavior of the builder.
            RangeOptions rangeOptions = new RangeOptions();
            rangeOptions.DiscardInvalidRanges = true;
            rangeOptions.MergeOverlappingRanges = true;
            rangeOptions.ShortenRanges = true;
            rangeOptions.SortRanges = true;

            //Create a RangeBuilder with the options we just made
            RangeBuilder range = new RangeBuilder(Options.Create(rangeOptions));
            range.Add(0, 10_000);
            range.Add(5, 100); //This range is overlapping, but that's okay since MergeOverlappingRanges is set to true.

            //We add the Range header to the HttpClient
            client.DefaultRequestHeaders.Add(range.HeaderName, range.Build());

            //We send the request to a website that echo the headers back to us in the response.
            string echo = await client.GetStringAsync(new Uri("http://scooterlabs.com/echo")).ConfigureAwait(false);

            //The response is written to the console
            Console.WriteLine(echo);
        }
    }
}