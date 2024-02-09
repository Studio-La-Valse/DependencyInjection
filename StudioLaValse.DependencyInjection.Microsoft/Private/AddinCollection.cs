using Microsoft.Extensions.DependencyInjection;
using System.Collections;

namespace StudioLaValse.DependencyInjection.Microsoft.Private
{
    internal class AddinCollection<TAddin> : IAddinCollection<TAddin>
    {
        private readonly IServiceProvider serviceProvider;

        public AddinCollection(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IEnumerator<TAddin> GetEnumerator()
        {
            return serviceProvider.GetServices<TAddin>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
