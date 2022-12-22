namespace Genbox.HttpBuilders.BuilderOptions;

public class RangeOptions
{
    /// <summary>
    /// As specified in RFC7233, a server may reject a request if there are overlapping ranges. This option ensure that ranges that overlap are
    /// merged.
    /// </summary>
    public bool MergeOverlappingRanges { get; set; } = true;

    /// <summary>As specified in RFC7233, ranges should be sorted in ascending order to make it easier for the server to satisfy the request.</summary>
    public bool SortRanges { get; set; } = true;

    /// <summary>
    /// Shorten ranges. Usually ranges are in the format "Start-End", but we can shave off some bytes by omitting the start or end values. This only
    /// works when the size of data is supplied.
    /// </summary>
    public bool ShortenRanges { get; set; } = true;

    /// <summary>Remove ranges that are less than 0 or larger than the size of the data. This only works when the size of data is supplied.</summary>
    public bool DiscardInvalidRanges { get; set; } = true;
}