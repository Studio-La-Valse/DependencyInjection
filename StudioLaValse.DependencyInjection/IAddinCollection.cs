namespace StudioLaValse.DependencyInjection
{
    /// <summary>
    /// Interface that can enumerate over loaded addins.
    /// </summary>
    /// <typeparam name="TAddin"></typeparam>
    public interface IAddinCollection<TAddin> : IEnumerable<TAddin>
    {

    }
}
