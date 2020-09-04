using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModLoader.Core.Concrete
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

            var path = Path.Combine(Root.GamePath, Name);
            await Task.Run(() => File.Delete(path));

            Root.Graph.Table[Name] = new HashSet<Guid> { Id };
        }

        public override string ToString()
        {
            return $"({Parent.Name}) [BURN] {Name}";
        }
    }
}
