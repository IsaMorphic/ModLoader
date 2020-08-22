using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModLoader.Core
{
    public abstract class Group<T, U> : Unit<T>
        where T : Unit<T>
        where U : Unit<U>
    {
        public HashSet<Unit<U>> Members { get; }

        public Group(string name, HashSet<Unit<U>> members) : base(name)
        {
            Members = members;
        }
    }
}
