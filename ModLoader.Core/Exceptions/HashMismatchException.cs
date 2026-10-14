namespace ModLoader.Core.Exceptions
{
    [Serializable]
    internal class HashMismatchException : Exception
    {
        public HashMismatchException()
        {
        }

        public HashMismatchException(string message) : base(message)
        {
        }

        public HashMismatchException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}