using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace ModLoader.Core
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct HashId : IEquatable<HashId>
    {
        private readonly ulong _a, _b, _c, _d;

        public HashId(ReadOnlySpan<byte> hashBytes)
        {
            if (hashBytes.Length != 32)
                throw new ArgumentException("Hash bytes must be 32 bytes long.", nameof(hashBytes));

            _a = BitConverter.ToUInt64(hashBytes.Slice(0, 8));
            _b = BitConverter.ToUInt64(hashBytes.Slice(8, 8));
            _c = BitConverter.ToUInt64(hashBytes.Slice(16, 8));
            _d = BitConverter.ToUInt64(hashBytes.Slice(24, 8));
        }

        public bool Equals(HashId other)
        {
            return _a == other._a && _b == other._b && _c == other._c && _d == other._d;
        }

        public override bool Equals(object obj)
        {
            return obj is HashId && Equals((HashId)obj);
        }

        public static bool operator ==(HashId left, HashId right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(HashId left, HashId right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_a, _b, _c, _d);
        }

        public static HashId NewHashId()
        { 
            return new HashId(RandomNumberGenerator.GetBytes(32));
        }
    }
}
