namespace Genbox.HttpBuilders.Abstracts
{
    public interface IHttpHeaderBuilder
    {
        /// <summary>
        /// Contains the name of the HTTP header
        /// </summary>
        string HeaderName { get; }

        /// <summary>
        /// Builds the builder into a simple string, ready for use in a HTTP header.
        /// </summary>
        /// <returns></returns>
        string Build();
    }
}