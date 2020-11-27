using System;
using System.Collections.Generic;

namespace ModLoader.Core.Abstract
{
    public interface IExceptional
    {
        HashSet<Exception> Errors { get; }
    }
}
