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

        public IResolvable<IGroup<T>> Resolver { get; }

        public XunkMerger(Pack parent, string name, IXunkGroupLoader<T> loader, HashSet<XunkGroup<T>> mergers) : base(parent, name, Guid.Empty, loader)
        {
            Mergers = mergers;

            var groups = new HashSet<IGroup<T>>(
                Mergers.Cast<IGroup<T>>());

            Resolver = new MergeFilter<T>()
            {
                Fallback = new GroupMerger<T>(groups)
            };
        }

        public override Module ResolveSelf()
        {
            return new XunkGroup<T>(Parent, Name, Loader, Resolver.Resolve().Members);
        }

        public override string ToString()
        {
            return $"(MERGER) {Name}";
        }
    }
}
