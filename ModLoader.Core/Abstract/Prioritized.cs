using System;
using System.Collections.Generic;
using System.Linq;

namespace ModLoader.Core.Abstract
{
    public class Prioritized<T, U> : IMergeable<IResolvable<T>, U>
        where T : class
    {
        public int Priority => Inner.ResolveFull(inclusive: false).Count - 1;

        public IMergeable<T, U> Inner { get; }

        public Prioritized(IMergeable<T, U> inner)
        {
            Inner = inner;
        }

        public IResolvable<IResolvable<T>> Fallback => Inner.Fallback == null ? null : new Prioritized<T, U>(Inner.Fallback as IMergeable<T, U>);
        public bool Enabled => Inner.Enabled;

        public U MergeKey => Inner.MergeKey;

        public IResolvable<T> ResolveSelf()
        {
            return Inner;
        }

        public virtual bool CanMergeWith(IResolvable<IResolvable<T>> other)
        {
            return MergeKey.Equals((other as Prioritized<T, U>).MergeKey);
        }

        public IPotential<IResolvable<T>> MergeWith(HashSet<IResolvable<IResolvable<T>>> others)
        {
            others.Add(this);
            var resolved = others.Cast<Prioritized<T, U>>()
                .GroupBy(o => o.Priority)
                .OrderByDescending(g => g.Key)
                .First()
                .Select(m => m.ResolveSelf());

            return new PrioritizedConflict<T>(new HashSet<IResolvable<T>>(resolved), Priority);
        }
    }
}
