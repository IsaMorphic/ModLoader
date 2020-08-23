using System.Collections.Generic;

namespace ModLoader.Core.Abstract
{
    public interface IGroup<T>
        where T : class
    {
        HashSet<IResolvable<T>> Members { get; }
    }

    public class Group<T> : IGroup<T>
        where T : class
    {
        public HashSet<IResolvable<T>> Members { get; }

        public Group(HashSet<IResolvable<T>> members)
        {
            Members = members;
        }

        public Group()
        {
            Members = new HashSet<IResolvable<T>>();
        }
    }
}
