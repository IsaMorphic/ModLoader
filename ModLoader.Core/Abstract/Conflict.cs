using System;
using System.Collections.Generic;
using System.Linq;

namespace ModLoader.Core.Abstract
{
    using Exceptions;

    public class Conflict<T> : IResolvable<T>
        where T : class, IResolvable<T>
    {
        public IResolvable<T> Fallback => null;
        public bool Enabled => true;

        public string Name { get; }

        public T Instigator { get; }

        public HashSet<T> Conflictors { get; }

        public Conflict(string name, T instigator, HashSet<T> conflictors)
        {
            Name = name;

            Instigator = instigator;
            Conflictors = conflictors;
        }

        public Conflict(string name, T instigator) : this(name, instigator, new HashSet<T>())
        {
        }

        public T ResolveSelf()
        {
            try
            {
                return Conflictors
                    .Union(new HashSet<T> { Instigator })
                    .Select(m => m.Resolve())
                    .Where(m => m != null)
                    .Single();
            }
            catch (InvalidOperationException)
            {
                throw new ConflictException<T>("Execution halted because a mergable instigated a conflict.\nPlease resolve the conflict before trying again.", this);
            }
        }

        public override string ToString()
        {
            return $"(CONFLICT) {Name}";
        }
    }
}