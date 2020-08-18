using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ModLoader.Core.Exceptions
{
    public class ConflictException<T> : Exception
        where T : Unit<T>
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
