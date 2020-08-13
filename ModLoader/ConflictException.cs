using System;
using System.Collections.Generic;

namespace ModLoader
{
    public class ConflictException<T> : Exception
        where T : Unit<T>
    {
        public HashSet<Conflict<T>> Conflicts { get; }

        public ConflictException(HashSet<Conflict<T>> conflicts)
        {
            Conflicts = new HashSet<Conflict<T>>(conflicts);
        }
    }
}
