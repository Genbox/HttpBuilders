namespace Genbox.HttpBuilders.Abstracts
{
    public interface IHttpHeaderBuilder
    {
        /// <summary>Contains the name of the HTTP header. If there is no single header name, it will return null</summary>
        string? HeaderName { get; }

        /// <summary>Builds the content of the builder into a simple string, ready for use in a HTTP header.</summary>
        /// <returns>The formatted content of the builder. If the builder is not set, it returns null.</returns>
        string? Build();

        /// <summary>Call this method to reset the state of the builder</summary>
        void Reset();

        /// <summary>Returns true if the builder contains data, otherwise it returns false.</summary>
        bool HasData();
    }
}