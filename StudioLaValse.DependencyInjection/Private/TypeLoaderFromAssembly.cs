using System.Reflection;

namespace StudioLaValse.DependencyInjection.Private
{
    internal class TypeLoaderFromAssembly : ITypeLoader
    {
        private readonly Assembly assembly;

        public TypeLoaderFromAssembly(Assembly assembly)
        {
            this.assembly = assembly;
        }

        public IEnumerable<Type> Load<_Type>() where _Type : class
        {
            var types = assembly.GetTypes().Where(typeof(_Type).IsAssignableFrom);

            foreach (var type in types)
            {
                yield return type;
            }
        }
    }
}
