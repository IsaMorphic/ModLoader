using System.Collections.Generic;

namespace ModLoader.Core.Abstract
{
    public class PrioritizedConflict<T> : IResolvable<IResolvable<T>>, IGroup<IResolvable<T>>
        where T : class
    {
        public IResolvable<IResolvable<T>> Fallback => null;
        public bool Enabled => true;

        public int Priority { get; }
        public HashSet<IResolvable<T>> Members { get; }

        public PrioritizedConflict(HashSet<IResolvable<T>> members, int priority)
        {
            Members = members;
            Priority = priority;
        }

        public IResolvable<T> ResolveSelf() => null;
    }
}
