using System;
using System.Collections.Generic;
using System.Linq;

namespace ModLoader.Core.Abstract
{
    using Exceptions;

    public class Conflict<T> : IMerger<T>
        where T : class, IResolvable<T>
    {
        public IResolvable<T> Fallback => null;
        public bool Enabled => true;

        public T Instigator { get; }

        public HashSet<T> Mergers { get; }

        public Conflict(T instigator, HashSet<T> mergers)
        {
            Instigator = instigator;
            Mergers = mergers;
        }

        public Conflict(T instigator) : this(instigator, new HashSet<T>())
        {
        }

        public T ResolveSelf()
        {
            try
            {
                return Mergers
                    .Concat(new HashSet<T> { Instigator })
                    .Select(m => m.Resolve())
                    .Where(m => m != null)
                    .Single();
            }
            catch (InvalidOperationException)
            {
                throw new ConflictException<T>("Execution halted because a module instigated a conflict.\nPlease resolve the conflict before trying again.", this);
            }
        }

        public override string ToString()
        {
            return "(CONFLICT)";
        }
    }
}