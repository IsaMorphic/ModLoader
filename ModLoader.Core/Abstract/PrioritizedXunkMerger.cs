using System.Collections.Generic;
using System.Linq;

namespace ModLoader.Core.Abstract
{
    using Filters;

    public class PrioritizedXunkMerger<T> : IPotential<Module>
        where T : Xunk<T>
    {
        private class PrioritizedXunk : Prioritized<T, XunkKey>
        {
            public PrioritizedXunk(IMergeable<T, XunkKey> inner) : base(inner)
            {
            }

            protected override Prioritized<T, XunkKey> GetFallbackCore()
            {
                return Inner.Fallback == null ? null : new PrioritizedXunk(Inner.Fallback.ResolveSelf());
            }

            public override int GetPriorityOver(Prioritized<T, XunkKey> other)
            {
                var thisParent = new PrioritizedModule(Inner.ResolveSelf().Parent);
                var otherParent = new PrioritizedModule(other.Inner.ResolveSelf().Parent);
                return thisParent.GetPriorityOver(otherParent);
            }
        }

        public Module Base { get; }
        public IPackBase Parent { get; }

        public HashSet<Prioritized<Module, string>> Mergers { get; }

        public PrioritizedXunkMerger(IPackBase parent, Module @base, HashSet<Prioritized<Module, string>> mergers)
        {
            Base = @base;
            Parent = parent;

            Mergers = mergers;
        }

        public Module ResolveSelf()
        {
            var group = Mergers
                .SelectMany(m => (m.ResolveSelf() as XunkGroup<T>).Xunks
                    .Select(x => new PrioritizedXunk(x.ResolveSelf()))
                    );

            var resolver =
                new PotentialFilter<T>(
                    new PriorityFilter<T>(
                        new MergeFilter<IResolvable<T>, XunkKey>(
                            new TrivialPotential<IGroup<Prioritized<T, XunkKey>>>(
                                new Group<Prioritized<T, XunkKey>>(group)
                                )
                            )
                        )
                    );
            var resolved = resolver.ResolveSelf().Members;

            return new XunkGroup<T>(Parent, Base?.Name ?? "[ERROR: UNRESOLVED]", Base, new HashSet<IPotential<T>>(resolved));
        }
    }
}
