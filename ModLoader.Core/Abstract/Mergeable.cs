using System.Collections.Generic;

namespace ModLoader.Core.Abstract
{
    public interface IMergeable<T, U> : IResolvable<T>
        where T : class
    {
        U MergeKey { get; }
        IPotential<T> MergeWith(HashSet<IResolvable<T>> others);
    }
}
