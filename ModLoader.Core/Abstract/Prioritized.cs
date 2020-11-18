using System.Collections.Generic;
using System.Linq;

namespace ModLoader.Core.Abstract
{
    public class Prioritized<T> : IMergeable<IResolvable<T>>
        where T : class
    {
        public int Priority { get; }
        public IResolvable<T> Inner { get; }

        public Prioritized(IResolvable<T> inner, int priority)
        {
            Priority = priority;
            Inner = inner;
        }

        public IResolvable<IResolvable<T>> Fallback => Inner.Fallback == null ? null : new Prioritized<T>(Inner.Fallback, Priority + 1);
        public bool Enabled => Inner.Enabled;

        public IResolvable<T> ResolveSelf()
        {
            return Inner;
        }

        public bool CanMergeWith(IResolvable<IResolvable<T>> other)
        {
            return (other as Prioritized<T>).Priority == Priority;
        }

        public IResolvable<IResolvable<T>> MergeWith(HashSet<IResolvable<IResolvable<T>>> others)
        {
            var resolved = others.Select(o => o.ResolveSelf());
            return new PrioritizedConflict<T>(new HashSet<IResolvable<T>>(resolved), Priority);
        }
    }
}
