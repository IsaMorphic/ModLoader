using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModLoader.Core.Abstract
{
    public interface IXunkLoader<T>
        where T : Xunk<T>
    {
        Task LoadAsync(XunkGroup<T> group);
    }

    public static class XunkLoader
    {
        public static Dictionary<Type, object> Loaders { get; }
        static XunkLoader()
        {
            Loaders = new Dictionary<Type, object>();
        }
    }

    public class XunkGroup<T> : Module, IGroup<IPotential<T>>
        where T : Xunk<T>
    {
        public Module Base { get; }
        public HashSet<IPotential<T>> Xunks { get; }

        IEnumerable<IPotential<T>> IGroup<IPotential<T>>.Members => Xunks;

        public XunkGroup(Pack parent, string name, Guid id) : base(parent, name, id)
        {
            Xunks = new HashSet<IPotential<T>>();
            Base = this.ResolveFull().First(r => r.GetType() == typeof(Module)).ResolveSelf();
        }

        public XunkGroup(Pack parent, string name, Module @base, HashSet<IPotential<T>> xunks) : base(parent, name, Guid.NewGuid())
        {
            Xunks = xunks;
            Base = @base;
        }

        public override IPotential<Module> MergeWith(HashSet<IResolvable<Module>> others)
        {
            if (others.All(m => m is XunkGroup<T>))
            {
                var groups = new HashSet<IPotential<Module>>(others);
                groups.Add(this);

                return new XunkMerger<T>(Parent, Base, groups);
            }
            else
            {
                return base.MergeWith(others);
            }
        }

        public override Task LoadSelfAsync()
        {
            return (XunkLoader.Loaders[typeof(T)] as IXunkLoader<T>).LoadAsync(this);
        }
    }
}
