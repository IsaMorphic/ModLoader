using System.Collections.Generic;

namespace ModLoader.Core.Abstract
{
    public class PrioritizedConflict<T> : IPotential<IResolvable<T>>, IGroup<IResolvable<T>>
        where T : class
    {
        public IEnumerable<IResolvable<T>> Members { get; }

        public PrioritizedConflict(HashSet<IResolvable<T>> members)
        {
            Members = members;
        }

        public IResolvable<T> ResolveSelf() => null;
    }
}
