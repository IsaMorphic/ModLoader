using System;

namespace ModLoader.Core.Exceptions
{
    using Abstract;

    public class ConflictException<T> : Exception
        where T : class
    {
        public Conflict<T> Conflict { get; }

        public ConflictException()
        {
        }

        public ConflictException(string message) : base(message)
        {
        }

        public ConflictException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ConflictException(string message, Conflict<T> conflict) : this(message)
        {
            Conflict = conflict;
        }

        public ConflictException(string message, Exception innerException, Conflict<T> conflict) : this(message, innerException)
        {
            Conflict = conflict;
        }
    }
}
