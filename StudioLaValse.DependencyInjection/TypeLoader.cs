using StudioLaValse.DependencyInjection.Private;
using System.Reflection;

namespace StudioLaValse.DependencyInjection
{
    /// <summary>
    /// A static class to provide default impelementations of the <see cref="ITypeLoader"/> interface.
    /// </summary>
    public static class TypeLoader
    {
        /// <summary>
        /// Load types from a directory. Does not support recursive searching.
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        public static ITypeLoader FromDirectory(string directory)
        {
            return new TypeLoaderFromDirectory(directory);
        }

        /// <summary>
        /// Load types from a single file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static ITypeLoader FromFile(string filePath)
        {
            return new TypeLoaderFromFile(filePath);
        }

        /// <summary>
        /// Load types from an assembly.
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static ITypeLoader FromAssembly(Assembly assembly)
        {
            return new TypeLoaderFromAssembly(assembly);
        }
    }
}
