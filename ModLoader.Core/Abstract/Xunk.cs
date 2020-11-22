using System.Collections.Generic;

namespace ModLoader.Core.Abstract
{
    public abstract class Xunk<T> : IMergeable<T>
        where T : Xunk<T>
    {
        public Xunk(XunkGroup<T> parent)
        {
            Parent = parent;

            Enabled = true;
        }

        public XunkGroup<T> Parent { get; }

        public IResolvable<T> Fallback => null;

        public bool Enabled { get; set; }
        bool IResolvable<T>.Enabled => Enabled && (Parent as IResolvable<Module>).Enabled;

        public abstract long Offset { get; }
        public abstract long Length { get; }

        public bool CanMergeWith(IResolvable<T> other)
        {
            var xunk = other as Xunk<T>;
            return Offset >= xunk.Offset && xunk.Offset + xunk.Length >= Offset;
        }

        public IPotential<T> MergeWith(HashSet<IResolvable<T>> others)
        {
            return new Conflict<T>(ToString(), ResolveSelf(), others);
        }

        public abstract T ResolveSelf();

        public abstract string[] GetDisplayText();
    }
}
