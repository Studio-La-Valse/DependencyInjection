using Example.API;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StudioLaValse.DependencyInjection;
using StudioLaValse.DependencyInjection.Microsoft;
using System.Reflection;

namespace Example.Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            var addins = host.Services.GetAddins<IAddin>();

            foreach (var addin in addins)
            {
                addin.Do();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\External Addins";
                    var typeLoader = TypeLoader.FromDirectory(directory);
                    var typeRegistryClient = new TypeRegistryClient();
                    services.RegisterExternalServices(typeLoader);
                    services.RegisterExternalAddins<IAddin>(typeLoader, typeRegistryClient);
                    services.RegisterCollection<IAddin>();
                });
        }
    }

    internal class TypeRegistryClient : ITypeRegistryClient<IServiceCollection>
    {
        public void Register(Type addin, IServiceCollection container)
        {
            container.AddScoped(typeof(IAddin), addin);
        }
    }
}
