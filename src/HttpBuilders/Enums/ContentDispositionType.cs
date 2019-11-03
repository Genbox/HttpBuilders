namespace Genbox.HttpBuilders.Enums
{
    public enum ContentDispositionType
    {
        Unknown = 0,

        /// <summary>Indicate that the content can be displayed inside a web page</summary>
        Inline,

        /// <summary>Indicates that the content should be downloaded</summary>
        Attachment
    }
}