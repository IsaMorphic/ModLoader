using System.Collections.Generic;

namespace ModLoader
{
    public class PackGroup : GroupMerger<Pack, Module>
    {
        public PackGroup(string name, HashSet<Pack> packs) : base(name, packs)
        {
        }
    }
}
