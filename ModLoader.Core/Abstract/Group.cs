using System.Collections.Generic;

namespace ModLoader.Core.Abstract
{
    public interface IGroup<out T>
        where T : class
    {
        IEnumerable<T> Members { get; }
    }

    public class Group<T> : IGroup<T>
        where T : class
    {
        public IEnumerable<T> Members { get; }

        public Group(IEnumerable<T> members)
        {
            Members = members;
        }
    }
}
