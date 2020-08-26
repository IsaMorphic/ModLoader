using System.Collections.Generic;

namespace ModLoader.Core.Abstract
{
    public abstract class Xunk<T> : IMergeable<T>
        where T : Xunk<T>
    {
        public IResolvable<T> Fallback => null;
        public bool Enabled { get; set; }

        public abstract long Offset { get; }
        public abstract long Length { get; }

        public bool CanMergeWith(T other)
        {
            return Offset >= other.Offset && other.Offset + other.Length >= Offset;
        }

        public IResolvable<T> MergeWith(HashSet<T> others)
        {
            return new Conflict<T>(ToString(), ResolveSelf(), others);
        }

        public abstract T ResolveSelf();

        public abstract string[] GetDisplayText();
    }
}
