using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ModLoader.Core.Abstract
{
    public interface IXunkGroupLoader<T>
        where T : Xunk<T>
    {
        Task LoadAsync(XunkGroup<T> group, CancellationToken token);
    }

    public class XunkGroup<T> : Module, IGroup<T>
        where T : Xunk<T>
    {
        public IXunkGroupLoader<T> Loader { get; }

        public HashSet<IResolvable<T>> Members { get; }

        public XunkGroup(Pack parent, string name, Guid id, IXunkGroupLoader<T> loader) : base(parent, name, id)
        {
            Loader = loader;
            Members = new HashSet<IResolvable<T>>();
        }

        public XunkGroup(Pack parent, string name, IXunkGroupLoader<T> loader, HashSet<IResolvable<T>> xunks) : base(parent, name, Guid.Empty)
        {
            Loader = loader;
            Members = xunks;
        }

        public override IResolvable<Module> MergeWith(HashSet<Module> others)
        {
            if (others.All(m => m is XunkGroup<T>))
            {
                var groups = new HashSet<XunkGroup<T>>(others
                    .Cast<XunkGroup<T>>());

                groups.Add(this);

                return new XunkMerger<T>(Parent, Name, Loader, groups);
            }
            else
            {
                return base.MergeWith(others);
            }
        }

        public override Task LoadSelfAsync(CancellationToken token)
        {
            return Loader.LoadAsync(this, token);
        }
    }
}
