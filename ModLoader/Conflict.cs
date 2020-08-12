using System.Collections.Generic;

namespace ModLoader
{
    public class Conflict
    {
        public List<Module> Modules { get; }

        public Conflict(List<Module> modules)
        {
            Modules = new List<Module>(modules);
        }
    }
}