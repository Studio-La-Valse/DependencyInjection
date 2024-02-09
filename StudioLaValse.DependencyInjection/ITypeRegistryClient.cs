namespace StudioLaValse.DependencyInjection
{
    /// <summary>
    /// An interface to specify the way addins are loaded into the provided service collection.
    /// </summary>
    /// <typeparam name="TServiceCollection"></typeparam>
    public interface ITypeRegistryClient<TServiceCollection>
    {
        /// <summary>
        /// Register the addin type to the service collection.
        /// </summary>
        /// <param name="addin"></param>
        /// <param name="container"></param>
        void Register(Type addin, TServiceCollection container);
    }
}
