using System.Collections.Generic;

namespace ModLoader.Core.Abstract
{
    public interface IGroup<T>
        where T : class
    {
        HashSet<T> Members { get; }
    }

    public class Group<T> : IGroup<T>
        where T : class
    {
        public HashSet<T> Members { get; }

        public Group(HashSet<T> members)
        {
            Members = members;
        }

        public Group()
        {
            Members = new HashSet<T>();
        }
    }
}
