using System;
using System.Threading.Tasks;

namespace ModLoader
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
        public Task LoadAsync() => Resolve()?.LoadSelfAsync();

        public abstract bool ConflictsWith(T other);

        protected abstract T ResolveSelf();
        protected abstract Task LoadSelfAsync();

        public override string ToString() => Name;
    }
}
