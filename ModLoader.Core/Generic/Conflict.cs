using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModLoader.Core
{
    using Exceptions;

    public class Conflict<T> : Merger<T>
        where T : Unit<T>
    {
        public T Instigator { get; }

        public override Unit<T> Fallback
        {
            get => null;
            set => throw new NotSupportedException();
        }

        public Conflict(T instigator, HashSet<T> mergers) : base("_none_", mergers)
        {
            Instigator = instigator;
        }

        public Conflict(T instigator) : this(instigator, new HashSet<T>())
        {
        }

        public override bool ConflictsWith(T other) => throw new NotSupportedException();

        protected override T ResolveSelf()
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
                throw new ConflictException<T>("Execution halted because a module instigated a conflict.\nPlease resolve the conflict before trying again.", this);
            }
        }

        protected override Task LoadSelfAsync() => throw new NotSupportedException();

        public override string ToString()
        {
            return $"(CONFLICT) {Instigator.Name}";
        }
    }
}