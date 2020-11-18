using System;
using System.Collections.Generic;
using System.Linq;

namespace ModLoader.Core.Abstract
{
    using Filters;

    public class XunkMerger<T> : XunkGroup<T>
        where T : Xunk<T>
    {
        public HashSet<XunkGroup<T>> Mergers { get; }

        public IPotential<IGroup<IPotential<T>>> Resolver { get; }

        public XunkMerger(Pack parent, string name, IXunkGroupLoader<T> loader, HashSet<XunkGroup<T>> mergers) : base(parent, name, Guid.Empty, loader)
        {
            Mergers = mergers;

            var groups = new HashSet<IGroup<IPotential<T>>>(
                Mergers.Cast<IGroup<IPotential<T>>>());

            Resolver = new MergeFilter<T>(
                new CastFilter<IPotential<T>, T>(
                    new GroupMerger<IPotential<T>>(groups)
                    )
                );
        }

        public override Module ResolveSelf()
        {
            var resolved = Resolver.ResolveSelf().Members;
            return new XunkGroup<T>(Parent, Name, Loader, new HashSet<IPotential<T>>(resolved));
        }

        public override string ToString()
        {
            return $"(MERGER) {Name}";
        }
    }
}
