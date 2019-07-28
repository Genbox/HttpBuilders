namespace HttpBuilders.Options
{
    public class AcceptEncodingBuilderOptions
    {
        /// <summary>
        /// Omit weights of 1.0 as it is the default weight if not otherwise defined
        /// </summary>
        public bool OmitDefaultWeight { get; set; } = true;
    }
}