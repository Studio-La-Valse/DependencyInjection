namespace StudioLaValse.DependencyInjection
{
    /// <summary>
    /// A generic type loader interface to load Types implementing the specified addin type.
    /// </summary>
    public interface ITypeLoader
    {
        /// <summary>
        /// Load the types.
        /// </summary>
        /// <typeparam name="TAddin"></typeparam>
        /// <returns></returns>
        IEnumerable<Type> Load<TAddin>() where TAddin : class;
    }
}
