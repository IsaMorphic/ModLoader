namespace ModLoader.Core
{
    public class Burn : Module
    {
        public Burn(Pack parent, string name, Guid id) : base(parent, name, id)
        {
        }

        public override async Task LoadSelfAsync()
        {
            if (Root.Graph.Entries[Name] == Id) return;

            await Root.BasePack.CopyModuleAsync(Name);

            await Root.Files.RemoveFileAsync(Name);

            Root.Graph.Entries[Name] = Id;
        }

        public override string ToString()
        {
            return $"({Parent.Name}) [BURN] {Name}";
        }
    }
}
