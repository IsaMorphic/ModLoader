using System.Collections.Generic;
using System.Linq;

namespace ModLoader.Core.Abstract
{
    public class GroupMerger<T> : IResolvable<IGroup<T>>
        where T : class, IResolvable<T>
    {
        public HashSet<IGroup<T>> Mergers { get; }

        public IResolvable<IGroup<T>> Fallback { get; set; }
        public bool Enabled { get; set; }

        public GroupMerger(HashSet<IGroup<T>> mergers)
        {
            Mergers = mergers;
            Enabled = true;
        }

        public GroupMerger()
        {
            Mergers = new HashSet<IGroup<T>>();
            Enabled = true;
        }

        public IGroup<T> ResolveSelf()
        {
            return new Group<T>(
                new HashSet<IResolvable<T>>(Mergers
                .SelectMany(m => m.Members)
                .Select(m => m.Resolve())
                .Where(m => m != null)
                .Distinct()));
        }
    }
}
