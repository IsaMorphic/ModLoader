using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModLoader
{
    public class Conflict<T> : Merger<T>
        where T : Unit<T>
    {
        public T Instigator { get; }

        public override Unit<T> Fallback
        {
            get => Instigator;
            set => throw new NotSupportedException();
        }

        public override bool Enabled { get; set; }

        public Conflict(string name, T instigator, HashSet<T> mergers) : base(name, mergers)
        {
            Instigator = instigator;
        }

        public Conflict(string name, T instigator) : this(name, instigator, new HashSet<T>())
        {
        }

        public override bool ConflictsWith(T other) => throw new NotSupportedException();

        protected override T ResolveSelf()
        {
            return Mergers
                .Select(m => m.Resolve())
                .Where(m => m != null)
                .SingleOrDefault();
        }

        protected override Task LoadSelfAsync() => throw new NotSupportedException();
    }
}