using CFS.SnabNet;
using System.Runtime.InteropServices;

namespace ModLoader.Core.Persistence.Types
{
    public class SnabHashId : ISnabType<HashId>
    {
        public const byte TypeId = 0xC0;

        public HashSet<byte> TypeIds => [TypeId];

        public HashId ReadFromInstance(SnabReader instance, byte typeId)
        {
            if (typeId != TypeId)
            {
                throw new ArgumentException("Invalid type ID", nameof(typeId));
            }

            Span<byte> hashBytes = stackalloc byte[32];
            instance.BaseStream.ReadExactly(hashBytes);
            return new HashId(hashBytes);
        }

        public void WriteToInstance(SnabWriter instance, byte typeId, object obj)
        {
            if (obj is HashId hash && typeId == TypeId) 
            {
                Span<byte> hashBytes = MemoryMarshal.AsBytes(new Span<HashId>(ref hash));
                instance.BaseStream.Write(hashBytes);
            }
            else if (typeId != TypeId)
            {
                throw new ArgumentException("Invalid type ID", nameof(typeId));
            }
            else
            {
                throw new ArgumentException("Object is not of type HashId", nameof(obj));
            }
        }

        public byte GetTypeIdForValue(object value)
        {
            return value is HashId ? TypeId : SnabType.None;
        }
    }
}
