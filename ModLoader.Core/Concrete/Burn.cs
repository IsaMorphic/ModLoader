using System;
using System.Threading.Tasks;

namespace ModLoader.Core
{
    public class Burn : Module
    {
        public Burn(Pack parent, string name, Guid id) : base(parent, name, id)
        {
        }

        public override async Task LoadSelfAsync()
        {
            if (Root.Graph.Table[Name] == Id) return;

            await Root.Files.RemoveFileAsync(Name);

            Root.Graph.Table[Name] = Id;
        }

        public override string ToString()
        {
            return $"({Parent.Name}) [BURN] {Name}";
        }
    }
}
