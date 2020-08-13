namespace ModLoader
{
    public abstract class Unit<T>
        where T : Unit<T>
    {
        public string Name { get; }

        public abstract T Fallback { get; set; }
        public abstract bool Enabled { get; set; }

        public Unit(string name)
        {
            Name = name;
        }

        public virtual bool ConflictsWith(T other) => Name == other.Name;

        public virtual T Resolve() => Enabled ? this as T : Fallback.Resolve();
    }
}
