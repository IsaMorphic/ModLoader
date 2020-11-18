using System.Collections.Generic;

namespace ModLoader.Core.Abstract
{
    public class PrioritizedConflict<T> : IPotential<IResolvable<T>>, IGroup<IResolvable<T>>
        where T : class
    {
        public int Priority { get; }
        public IEnumerable<IResolvable<T>> Members { get; }

        public PrioritizedConflict(HashSet<IResolvable<T>> members, int priority)
        {
            Members = members;
            Priority = priority;
        }

        public IResolvable<T> ResolveSelf() => null;
    }
}
