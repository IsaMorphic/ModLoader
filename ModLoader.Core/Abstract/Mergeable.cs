using System.Collections.Generic;

namespace ModLoader.Core.Abstract
{
    public interface IMergeable<T> : IResolvable<T>
        where T : class
    {
        bool CanMergeWith(IResolvable<T> other);
        IResolvable<T> MergeWith(HashSet<IResolvable<T>> others);
    }
}
