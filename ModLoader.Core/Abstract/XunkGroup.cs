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

    public class XunkGroup<T> : Module, IGroup<IPotential<T>>, IExceptional
        where T : Xunk<T>
    {
        public Module Base { get; }
        public HashSet<IPotential<T>> Xunks { get; }

        private HashSet<Exception> Errors { get; }

        HashSet<Exception> IExceptional.Errors => Xunks
            .SelectMany(m => (m as IExceptional)?.Errors ?? new HashSet<Exception>())
            .Concat(Errors)
            .ToHashSet();

        public bool HasErrors => (this as IExceptional).Errors.Any();

        IEnumerable<IPotential<T>> IGroup<IPotential<T>>.Members => Xunks;

        public XunkGroup(IPackBase parent, string name, Guid id) : base(parent, name, id)
        {
            Xunks = new HashSet<IPotential<T>>();
            Base = this.ResolveFull().FirstOrDefault(r => r.GetType() == typeof(Module)) as Module;

            Errors = new HashSet<Exception>();
            if (Base == null)
                Errors.Add(new InvalidOperationException($"Attempted to initialize a xunk group with no viable base.\nOffending module: {this}"));
        }

        public XunkGroup(IPackBase parent, string name, Module @base, HashSet<IPotential<T>> xunks) : base(parent, name, Guid.NewGuid())
        {
            Xunks = xunks;
            Base = @base;

            Errors = new HashSet<Exception>();
            if (Base == null)
                Errors.Add(new InvalidOperationException($"This xunk group has an unresolved base.\nOffending pack: {Parent}"));
        }

        public override IPotential<Module> MergeWith(HashSet<IResolvable<Module>> others)
        {
            if (others.All(m => m is XunkGroup<T>))
            {
                var groups = new HashSet<IPotential<Module>>(others);
                groups.Add(this);

                return new XunkMerger<T>(Parent as Pack, Base, groups);
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

        public override string ToString()
        {
            return (HasErrors ? "[ERROR] " : "") + base.ToString();
        }
    }
}
