using System;
using System.Collections.Generic;

namespace ModLoader.Core.Abstract
{
    public struct XunkKey : IEquatable<XunkKey>
    {
        private long Offset { get; }
        private long Length { get; }

        public XunkKey(long offset, long length)
        {
            Offset = offset;
            Length = length;
        }

        public bool Equals(XunkKey other)
        {
            return Offset >= other.Offset && other.Offset + other.Length >= Offset;
        }

        public override bool Equals(object obj)
        {
            if (obj != null && obj is XunkKey) return Equals((XunkKey)obj);
            else return false;
        }

        public static bool operator ==(XunkKey left, XunkKey right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(XunkKey left, XunkKey right)
        {
            return !(left == right);
        }
    }

    public abstract class Xunk<T> : IMergeable<T, XunkKey>
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

        public XunkKey MergeKey => new XunkKey(Offset, Length);

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
