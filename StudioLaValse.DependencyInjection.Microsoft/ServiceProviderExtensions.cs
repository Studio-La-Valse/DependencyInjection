using Microsoft.Extensions.DependencyInjection;

namespace StudioLaValse.DependencyInjection.Microsoft
{
    /// <summary>
    /// Extensions to Microsoft's <see cref="IServiceProvider"/> from the Dependency Injection package.
    /// </summary>
    public static class ServiceProviderExtensions
    {
        /// <summary>
        /// Returns the loaded addins.
        /// </summary>
        /// <typeparam name="TAddin"></typeparam>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public static IAddinCollection<TAddin> GetAddins<TAddin>(this IServiceProvider serviceProvider) where TAddin : class
        {
            return serviceProvider.GetRequiredService<IAddinCollection<TAddin>>();
        }
    }
}
