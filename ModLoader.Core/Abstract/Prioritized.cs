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
            var resolved = others.Cast<Prioritized<T, U>>()
                .Where(x => x.GetPriorityOver(this) >= 0);

            return new PrioritizedConflict<T>(resolved
                .Select(m => m.ResolveSelf())
                .ToHashSet());
        }

        public abstract int GetPriorityOver(Prioritized<T, U> other);
    }
}
