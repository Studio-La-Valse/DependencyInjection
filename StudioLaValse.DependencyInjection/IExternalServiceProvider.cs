namespace StudioLaValse.DependencyInjection
{
    /// <summary>
    /// Interface to be implemented by the end user addin. Provides the <see cref="AddTo(TServiceCollection)"/> method to add user-specified external services into the target service collection during startup of the application.
    /// </summary>
    /// <typeparam name="TServiceCollection"></typeparam>
    public interface IExternalServiceProvider<TServiceCollection>
    {
        /// <summary>
        /// Override this method to specify which services to add to the provided service collection.
        /// </summary>
        /// <param name="container"></param>
        void AddTo(TServiceCollection container);
    }
}
