using System.Collections.Generic;
using System.Linq;

namespace ModLoader.Core.Abstract
{
    public class GroupMerger<T> : IResolvable<IGroup<IResolvable<T>>>
        where T : class
    {
        public HashSet<IGroup<IResolvable<T>>> Mergers { get; }

        public IResolvable<IGroup<IResolvable<T>>> Fallback { get; set; }
        public bool Enabled { get; set; }

        public GroupMerger(HashSet<IGroup<IResolvable<T>>> mergers)
        {
            Mergers = mergers;
            Enabled = true;
        }

        public GroupMerger()
        {
            Mergers = new HashSet<IGroup<IResolvable<T>>>();
            Enabled = true;
        }

        public IGroup<IResolvable<T>> ResolveSelf()
        {
            return new Group<IResolvable<T>>(
                new HashSet<IResolvable<T>>(Mergers
                .SelectMany(m => m.Members)));
        }
    }
}
