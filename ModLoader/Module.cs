using System.IO;

namespace ModLoader
{
    public abstract class Module : Unit
    {
        public new Pack Parent => base.Parent as Pack;

        public PackList PackList => Parent.Parent;

        public Module(Pack parent, string name) : base(parent, name)
        {
            Data = Parent.Archive.GetEntry(name).Open();
        }

        public Stream Data { get; }

        public virtual bool ConflictsWith(Module module)
        {
            return Name == module.Name;
        }
    }
}
