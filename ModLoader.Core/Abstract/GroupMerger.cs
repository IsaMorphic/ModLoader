using System.Collections.Generic;
using System.Linq;

namespace ModLoader.Core.Abstract
{
    public class GroupMerger<T> : IPotential<IGroup<T>>
        where T : class
    {
        public HashSet<IGroup<T>> Mergers { get; }

        public GroupMerger(HashSet<IGroup<T>> mergers)
        {
            Mergers = mergers;
        }

        public GroupMerger()
        {
            Mergers = new HashSet<IGroup<T>>();
        }

        public IGroup<T> ResolveSelf()
        {
            return new Group<T>(
                new HashSet<T>(Mergers
                .SelectMany(m => m.Members)
                ));
        }
    }
}
