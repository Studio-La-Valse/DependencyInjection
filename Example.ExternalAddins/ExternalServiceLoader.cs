using Microsoft.Extensions.DependencyInjection;
using StudioLaValse.DependencyInjection;

namespace Example.ExternalAddins
{
    public class ExternalServiceLoader : IExternalServiceProvider<IServiceCollection>
    {
        public void AddTo(IServiceCollection container)
        {
            container.AddTransient<ISomeExternalService, SomeExternalService>();
        }
    }
}
