using CFS.SnabNet;
using System;
using System.Collections.Generic;

namespace ModLoader.Core.Persistence.Types
{
    public class SnabGuid : ISnabType<Guid>
    {
        public const byte TYPE_ID = 0x80;
        
        public HashSet<byte> TypeIds { get; } = [TYPE_ID];

        public Guid ReadFromInstance(SnabReader instance, byte typeId)
        {
            Span<byte> bytes = stackalloc byte[16];
            instance.BaseStream.ReadExactly(bytes);
            return new Guid(bytes);
        }

        public void WriteToInstance(SnabWriter instance, byte typeId, object obj)
        {
            Span<byte> bytes = stackalloc byte[16];
            ((Guid)obj).TryWriteBytes(bytes);
            instance.BaseStream.Write(bytes);
        }
    }
}
