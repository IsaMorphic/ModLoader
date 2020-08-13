using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace ModLoader
{
    public class Pack : Group<Pack, Module>
    {
        public PackGroup Parent { get; }

        public ZipArchive Archive { get; }

        public Pack() : this("_none_", new HashSet<Unit<Module>>(), null)
        {
        }

        public Pack(string name, HashSet<Unit<Module>> modules, PackGroup parent) : base(name, modules)
        {
        }

        protected override Pack ResolveSelf() => this;
    }
}
