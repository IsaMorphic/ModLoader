using System.Collections.Generic;
using System.Linq;

namespace ModLoader.Core.Abstract
{
    public abstract class Prioritized<T, U> : IMergeable<IResolvable<T>, U>
        where T : class
    {
        public IMergeable<T, U> Inner { get; }

        public Prioritized(IMergeable<T, U> inner)
        {
            Inner = inner;
        }

        public IResolvable<IResolvable<T>> Fallback => GetFallbackCore();
        public bool Enabled => Inner.Enabled;

        public U MergeKey => Inner.MergeKey;

        protected abstract Prioritized<T, U> GetFallbackCore();

        public IResolvable<T> ResolveSelf()
        {
            return Inner;
        }

        public virtual IPotential<IResolvable<T>> MergeWith(HashSet<IResolvable<IResolvable<T>>> others)
        {
            others.Add(this);
            var resolved = new SortedList<int, HashSet<Prioritized<T, U>>>(
                others.Cast<Prioritized<T, U>>()
                .GroupBy(x => x.GetPriorityOver(this))
                .ToDictionary(g => g.Key, g => g.ToHashSet())
                );

            HashSet<Prioritized<T, U>> highest = resolved
                .LastOrDefault(x => x.Key < int.MaxValue)
                .Value;
            if (highest != null && resolved.Remove(int.MaxValue, out HashSet<Prioritized<T, U>> group))
            {
                highest.UnionWith(group);
            }
            else
            {
                highest ??= resolved.GetValueAtIndex(0);
            }

            return new PrioritizedConflict<T>(highest
                .Select(m => m.ResolveSelf())
                .ToHashSet());
        }

        public abstract int GetPriorityOver(Prioritized<T, U> other);
    }
}
