using System.Collections.Generic;

namespace ModLoader.Core.Abstract
{
    public interface IMergeable<T> : IResolvable<T>
        where T : class
    {
        bool CanMergeWith(T other);
        IResolvable<T> MergeWith(HashSet<T> others);
    }
}
