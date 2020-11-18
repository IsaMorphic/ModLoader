using System;
using System.Collections.Generic;
using System.Linq;

namespace ModLoader.Core.Abstract
{
    using Exceptions;

    public class Conflict<T> : IPotential<T>
        where T : class
    {

        public string Name { get; }

        public IResolvable<T> Instigator { get; }

        public HashSet<IResolvable<T>> Conflictors { get; }

        public Conflict(string name, IResolvable<T> instigator, HashSet<IResolvable<T>> conflictors)
        {
            Name = name;

            Instigator = instigator;
            Conflictors = conflictors;
        }

        public Conflict(string name, IResolvable<T> instigator) : this(name, instigator, new HashSet<IResolvable<T>>())
        {
        }

        public T ResolveSelf()
        {
            try
            {
                return Conflictors
                    .Union(new HashSet<IResolvable<T>> { Instigator })
                    .Select(m => m.Resolve())
                    .Where(m => m != null)
                    .Single();
            }
            catch (InvalidOperationException)
            {
                throw new ConflictException<T>($"Execution halted because mergable with name: \"{Name}\" instigated a conflict.\nPlease resolve the conflict before trying again.", this);
            }
        }

        public override string ToString()
        {
            return $"(CONFLICT) {Name}";
        }
    }
}