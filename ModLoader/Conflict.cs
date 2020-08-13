using System;
using System.Collections.Generic;
using System.Linq;

namespace ModLoader
{
    public class Conflict<T> : Merger<T>
        where T : Unit<T>
    {
        public override T Fallback { get => null; set => throw new NotImplementedException(); }
        public override bool Enabled { get => true; set => throw new NotImplementedException(); }

        public Conflict(string name, HashSet<T> mergers) : base(name, mergers)
        {
        }

        public override T Resolve()
        {
            try
            {
                return Mergers
                    .Select(m => m.Resolve())
                    .Where(m => m != null)
                    .Single();
            }
            catch (InvalidOperationException)
            {
                throw new ConflictException<T>(new HashSet<Conflict<T>> { this });
            }
        }
    }
}