using System.IO;
using System.Threading.Tasks;

namespace ModLoader
{
    public class Replacement : Module
    {
        public Replacement(Pack parent, string name) : base(parent, name)
        {
        }

        public override Task Load()
        {
            string fullPath = Path.Combine(PackList.BaseDirectory, "Game", Name);
            using (var file = File.Create(fullPath))
            {
                return Data.CopyToAsync(file);
            }
        }
    }
}
