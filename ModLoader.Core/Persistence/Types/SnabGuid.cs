using CFS.SnabNet;

namespace ModLoader.Core.Persistence.Types
{
    public class SnabGuid : ISnabType<Guid>
    {
        public const byte TypeId = 0x80;
        
        public HashSet<byte> TypeIds { get; } = [TypeId];

        public Guid ReadFromInstance(SnabReader instance, byte typeId)
        {
            Span<byte> bytes = stackalloc byte[16];
            instance.BaseStream.ReadExactly(bytes);
            return new Guid(bytes, instance.Flags.HasFlag(SnabFlags.BigEndian));
        }

        public void WriteToInstance(SnabWriter instance, byte typeId, object obj)
        {
            Span<byte> bytes = stackalloc byte[16];
            ((Guid)obj).TryWriteBytes(bytes, instance.Flags.HasFlag(SnabFlags.BigEndian), out int _);
            instance.BaseStream.Write(bytes);
        }
    }
}
