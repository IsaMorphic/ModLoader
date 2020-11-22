using System.Collections.Generic;
using System.Linq;

namespace ModLoader.Core.Abstract
{
    public class GroupMerger<T> : IPotential<IGroup<T>>
        where T : class
    {
        public HashSet<IPotential<IGroup<T>>> Mergers { get; }

        public GroupMerger(HashSet<IPotential<IGroup<T>>> mergers)
        {
            Mergers = mergers;
        }

        public GroupMerger()
        {
            Mergers = new HashSet<IPotential<IGroup<T>>>();
        }

        public IGroup<T> ResolveSelf()
        {
            return new Group<T>(Mergers.SelectMany(m => m.ResolveSelf().Members));
        }
    }
}
