using System.Collections.Generic;

namespace ModLoader
{
    public abstract class Group<T, U> : Unit<T> 
        where T : Group<T, U>
        where U : Unit<U> 
    {
        public HashSet<U> Members { get; }

        public Group(string name, HashSet<U> members) : base(name)
        {
            Members = new HashSet<U>(members);
        }
    }
}
