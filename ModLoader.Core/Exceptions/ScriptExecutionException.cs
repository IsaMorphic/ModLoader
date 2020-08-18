using System;
using System.Runtime.Serialization;

namespace ModLoader.Core.Exceptions
{
    public class ScriptExecutionException : Exception
    {
        public int StopCode { get; }

        public ScriptExecutionException()
        {
        }

        public ScriptExecutionException(string message) : base(message)
        {
        }

        public ScriptExecutionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ScriptExecutionException(string message, int stopCode) : this(message)
        {
            StopCode = stopCode;
        }

        public ScriptExecutionException(string message, Exception innerException, int stopCode) : this(message, innerException)
        {
            StopCode = stopCode;
        }
    }
}
