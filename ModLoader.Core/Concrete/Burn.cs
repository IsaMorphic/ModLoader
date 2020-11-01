using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ModLoader.Core
{
    public class Burn : Module
    {
        public Burn(Pack parent, string name, Guid id) : base(parent, name, id)
        {
        }

        public override async Task LoadSelfAsync(CancellationToken token)
        {
            try
            {
                if (Root.Graph.Table[Name].Single() == Id) return;
            }
            catch (InvalidOperationException) { }

            await Root.Files.RemoveFileAsync(Name);

            Root.Graph.Table[Name] = new HashSet<Guid> { Id };
        }

        public override string ToString()
        {
            return $"({Parent.Name}) [BURN] {Name}";
        }
    }
}
