using System.Security.Cryptography;

namespace ModLoader.Core.Utilities.Hashing
{
    public class SHA256Stream : Stream
    {
        private readonly Stream _innerStream;
        private readonly SHA256 _sha256;
        private readonly CryptoStream _cryptoStream;
        private bool _isDisposed;

        public SHA256Stream(Stream innerStream, bool leaveOpen = false)
        {
            _innerStream = innerStream ?? throw new ArgumentNullException(nameof(innerStream));
            _sha256 = SHA256.Create();

            _cryptoStream = new CryptoStream(
                _innerStream,
                _sha256,
                CryptoStreamMode.Write,
                leaveOpen);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            _cryptoStream.Write(buffer, offset, count);
        }

        public override void Write(ReadOnlySpan<byte> buffer)
        {
            _cryptoStream.Write(buffer);
        }

        public override void Flush()
        {
            _cryptoStream.Flush();
            _innerStream.Flush();
        }

        public HashId GetHash()
        {
            _cryptoStream.FlushFinalBlock();
            return new HashId(_sha256.Hash ?? Array.Empty<byte>());
        }

        public override bool CanRead => false;
        public override bool CanSeek => false;
        public override bool CanWrite => _innerStream.CanWrite;
        public override long Length => _innerStream.Length;
        public override long Position
        {
            get => _innerStream.Position;
            set => throw new NotSupportedException();
        }

        public override int Read(byte[] buffer, int offset, int count) => throw new NotSupportedException();
        public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();
        public override void SetLength(long value) => throw new NotSupportedException();

        protected override void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    _cryptoStream.Dispose();
                    _sha256.Dispose();
                }
                _isDisposed = true;
            }

            base.Dispose(disposing);
        }
    }
}
