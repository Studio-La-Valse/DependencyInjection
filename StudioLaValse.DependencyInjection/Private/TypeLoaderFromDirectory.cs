using System.Reflection;

namespace StudioLaValse.DependencyInjection.Private
{
    internal class TypeLoaderFromDirectory : ITypeLoader
    {
        private readonly string source;

        public TypeLoaderFromDirectory(string source)
        {
            this.source = source;
        }

        public IEnumerable<Type> Load<TAddin>() where TAddin : class
        {
            foreach (var file in Directory.GetFiles(source))
            {
                var loader = TypeLoader.FromFile(file);
                var types = loader.Load<TAddin>();
                foreach (var type in types)
                {
                    yield return type;
                }
            }
        }
    }

    internal class TypeLoaderFromFile : ITypeLoader
    {
        private readonly string filePath;

        public TypeLoaderFromFile(string filePath)
        {
            this.filePath = filePath;
        }

        public IEnumerable<Type> Load<TAddin>() where TAddin : class
        {
            var assembly = Assembly.LoadFrom(filePath);
            var loader = TypeLoader.FromAssembly(assembly);
            foreach (var type in loader.Load<TAddin>())
            {
                yield return type;
            }
        }
    }
}
