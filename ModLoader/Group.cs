using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModLoader
{
    public abstract class Group<T, U> : Unit<T>
        where T : Group<T, U>
        where U : Unit<U>
    {
        public HashSet<Unit<U>> Members { get; }

        public Group(string name, HashSet<Unit<U>> members) : base(name)
        {
            Members = members;
        }

        public override bool ConflictsWith(T other)
        {
            foreach (var myMember in Members)
            {
                foreach (var theirMember in other.Members)
                {
                    if (myMember.Resolve().ConflictsWith(theirMember.Resolve()))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        protected override Task LoadSelfAsync()
        {
            return Task.WhenAll(Members.Select(m => m.Resolve().LoadAsync()));
        }
    }
}
