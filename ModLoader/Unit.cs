using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModLoader
{
    public abstract class Unit
    {
        public Guid Id { get; }
        public string Name { get; }

        public Unit Parent { get; }

        public Unit(Unit parent, string name)
        {
            Id = Guid.NewGuid();
            Name = name;

            Parent = parent;
        }

        public abstract Task Load();
    }
}
