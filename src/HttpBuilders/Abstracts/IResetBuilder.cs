namespace Genbox.HttpBuilders.Abstracts
{
    /// <summary>
    /// Use this interface in a builder to indicate that it supports being reset. This is useful for object pooling scenarios.
    /// </summary>
    public interface IResetBuilder
    {
        void Reset();
    }
}
