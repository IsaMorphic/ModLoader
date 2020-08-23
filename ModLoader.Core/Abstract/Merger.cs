using System.Collections.Generic;
using System.Linq;

namespace ModLoader.Core.Abstract
{
    public interface IMerger<T> : IResolvable<T>
        where T : class
    {
        HashSet<T> Mergers { get; }
    }

    public static class MergerExtensions
    {
        public static bool Empty<T>(this IMerger<T> merger)
            where T : class
        {
            return !merger.Mergers.Any();
        }
    }
}
