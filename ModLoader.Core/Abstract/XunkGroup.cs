namespace ModLoader.Core.Abstract
{
    public interface IXunkLoader<T>
        where T : Xunk<T>
    {
        Task LoadAsync(XunkGroup<T> group);
    }

    public static class XunkLoader
    {
        private static Dictionary<Type, object> _loaders;

        static XunkLoader()
        {
            _loaders = new Dictionary<Type, object>();
        }

        public static bool Register<T>(IXunkLoader<T> loader) 
            where T : Xunk<T>
        {
            return _loaders.TryAdd(typeof(T), loader);
        }

        public static IXunkLoader<T> Get<T>()
            where T : Xunk<T>
        {
            _loaders.TryGetValue(typeof(T), out object loader);
            return loader as IXunkLoader<T>;
        }
    }

    public class XunkGroup<T> : Module, IGroup<IPotential<T>>, IExceptional
        where T : Xunk<T>
    {
        public Module Base { get; }
        public HashSet<IPotential<T>> Xunks { get; }

        private HashSet<Exception> Errors { get; }

        HashSet<Exception> IExceptional.Errors => Xunks
            .SelectMany(m => (m as IExceptional)?.Errors ?? [])
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
                var groups = new HashSet<IPotential<Module>>(others) { this };
                return new XunkMerger<T>(Parent, Base, groups);
            }
            else
            {
                return base.MergeWith(others);
            }
        }

        public override Task LoadSelfAsync()
        {
            return XunkLoader.Get<T>()?.LoadAsync(this) ?? Task.CompletedTask;
        }

        public override string ToString()
        {
            return (HasErrors ? "[ERROR] " : "") + base.ToString();
        }
    }
}
