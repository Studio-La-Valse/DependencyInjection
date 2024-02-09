using Microsoft.Extensions.DependencyInjection;
using StudioLaValse.DependencyInjection.Microsoft.Private;

namespace StudioLaValse.DependencyInjection.Microsoft
{
    /// <summary>
    /// Extension methods to the microsoft Dependency Injection <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Register user provided external services into the provided service collection.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="typeLoader"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterExternalServices(this IServiceCollection services, ITypeLoader typeLoader)
        {
            var plugins = typeLoader.Load<IExternalServiceProvider<IServiceCollection>>();
            foreach (var plugin in plugins)
            {
                var activated = Activator.CreateInstance(plugin) as IExternalServiceProvider<IServiceCollection>;
                if (activated is not null)
                {
                    activated.AddTo(services);
                }
            }

            return services;
        }

        /// <summary>
        /// Register user created addins into the provided service collection.
        /// </summary>
        /// <typeparam name="TAddin"></typeparam>
        /// <param name="services"></param>
        /// <param name="typeLoader"></param>
        /// <param name="typeRegistryClient"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterExternalAddins<TAddin>(this IServiceCollection services, ITypeLoader typeLoader, ITypeRegistryClient<IServiceCollection> typeRegistryClient) where TAddin : class
        {
            var plugins = typeLoader.Load<TAddin>();

            foreach (var plugin in plugins)
            {
                services.RegisterType(plugin, typeRegistryClient);
            }

            return services;
        }

        /// <summary>
        /// Register a single type into the provided service collection.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="addinType"></param>
        /// <param name="typeRegistryClient"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterType(this IServiceCollection services, Type addinType, ITypeRegistryClient<IServiceCollection> typeRegistryClient)
        {
            typeRegistryClient.Register(addinType, services);
            return services;
        }

        /// <summary>
        /// Register the generic <see cref="IAddinCollection{TAddin}"/> into the provided service collection.
        /// </summary>
        /// <typeparam name="TAddin"></typeparam>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterCollection<TAddin>(this IServiceCollection services) where TAddin : class
        {
            services.AddSingleton<IAddinCollection<TAddin>>(s => new AddinCollection<TAddin>(s));
            return services;
        }
    }
}
