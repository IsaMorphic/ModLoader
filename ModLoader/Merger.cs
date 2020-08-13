using System.Collections.Generic;
using System.Linq;

namespace ModLoader
{
    public abstract class Merger<T> : Unit<T> 
        where T : Unit<T>
    {
        public HashSet<T> Mergers { get; }

        public Merger(string name, HashSet<T> mergers) : base(name)
        {
            Mergers = mergers;
        }

        public bool Empty() => Mergers.Any();
    }
}
