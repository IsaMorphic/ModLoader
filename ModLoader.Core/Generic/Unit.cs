using System.Collections.Generic;
using System.Threading.Tasks;

namespace ModLoader.Core
{
    public abstract class Unit<T>
        where T : Unit<T>
    {
        public string Name { get; }

        public virtual Unit<T> Fallback { get; set; }
        public virtual bool Enabled { get; set; } = true;

        public Unit(string name)
        {
            Name = name;
        }

        public T Resolve() => Enabled ? ResolveSelf() : Fallback?.Resolve();
        public T ResolveAsIfDisabled() => Fallback?.Resolve();

        public List<Unit<T>> ResolveFull() => ResolveFull(new List<Unit<T>>());
        private List<Unit<T>> ResolveFull(List<Unit<T>> list)
        {
            var next = ResolveAsIfDisabled();
            list.Add(next);
            return Fallback?.ResolveFull(list) ?? list;
        }

        public Task LoadAsync() => Resolve()?.LoadSelfAsync();

        public abstract bool ConflictsWith(T other);

        protected abstract T ResolveSelf();
        protected abstract Task LoadSelfAsync();

        public override string ToString() => Name;
    }
}
