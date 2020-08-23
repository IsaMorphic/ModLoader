using System;

namespace ModLoader.Core.Exceptions
{
    public class GhostedModuleException : Exception
    {
        public GhostModule Module { get; }

        public GhostedModuleException()
        {
        }

        public GhostedModuleException(string message) : base(message)
        {
        }

        public GhostedModuleException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public GhostedModuleException(string message, GhostModule module) : this(message)
        {
            Module = module;
        }

        public GhostedModuleException(string message, Exception innerException, GhostModule module) : this(message, innerException)
        {
            Module = module;
        }
    }
}
