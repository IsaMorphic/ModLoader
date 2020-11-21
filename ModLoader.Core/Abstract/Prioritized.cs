using System.Collections.Generic;
using System.Linq;

namespace ModLoader.Core.Abstract
{
    public class Prioritized<T> : IMergeable<IResolvable<T>>
        where T : class
    {
        public int Priority { get; }
        public IMergeable<T> Inner { get; }

        public Prioritized(IMergeable<T> inner, int priority)
        {
            Priority = priority;
            Inner = inner;
        }

        public IResolvable<IResolvable<T>> Fallback => Inner.Fallback == null ? null : new Prioritized<T>(Inner.Fallback as IMergeable<T>, Priority + 1);
        public bool Enabled => Inner.Enabled;

        public IResolvable<T> ResolveSelf()
        {
            return Inner;
        }

        public virtual bool CanMergeWith(IResolvable<IResolvable<T>> other)
        {
            return Inner.CanMergeWith((other as Prioritized<T>).Inner);
        }

        public IPotential<IResolvable<T>> MergeWith(HashSet<IResolvable<IResolvable<T>>> others)
        {
            others.Add(this);
            var resolved = others.Cast<Prioritized<T>>()
                .GroupBy(o => o.Priority)
                .OrderBy(g => g.Key)
                .First()
                .Select(m => m.ResolveSelf());

            return new PrioritizedConflict<T>(new HashSet<IResolvable<T>>(resolved), Priority);
        }
    }
}
