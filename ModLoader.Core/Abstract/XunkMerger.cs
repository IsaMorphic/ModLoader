using System;
using System.Collections.Generic;
using System.Linq;

namespace ModLoader.Core.Abstract
{
    using Filters;

    public class XunkMerger<T> : IPotential<Module>
        where T : Xunk<T>
    {
        public Module Base { get; }
        public Pack Parent { get; }

        public HashSet<IPotential<Module>> Mergers { get; }

        public XunkMerger(Pack parent, Module @base, HashSet<IPotential<Module>> mergers)
        {
            Base = @base;
            Parent = parent;

            Mergers = mergers;
        }

        public Module ResolveSelf()
        {
            var groups = Mergers
                .Select(m => m.ResolveSelf() as XunkGroup<T>)
                .Select(m => new TrivialPotential<IGroup<IPotential<T>>>(m));

            var resolver = new MergeFilter<T>(
                new ResolveFilter<T>(
                    new CastFilter<IPotential<T>, IMergeable<T>>(
                        new GroupMerger<IPotential<T>>(new HashSet<IPotential<IGroup<IPotential<T>>>>(groups))
                        )
                    )
                );
            var resolved = resolver.ResolveSelf().Members;

            return new XunkGroup<T>(Parent, Base?.Name, Base, new HashSet<IPotential<T>>(resolved));
        }

        public override string ToString()
        {
            return $"(MERGER) {Base?.Name ?? "[ERROR: UNRESOLVED]"}";
        }
    }
}
