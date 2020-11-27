using System.Threading.Tasks;

namespace ModLoader.Core.Abstract
{
    public interface ILoadable<T> : IResolvable<T>
        where T : class
    {
        Task LoadSelfAsync();
    }

    public static class LoadableExtensions
    {
        public static Task LoadAsync<T>(this ILoadable<T> unit)
            where T : class, ILoadable<T>
        {
            return unit.Resolve()?.LoadSelfAsync();
        }
    }
}
