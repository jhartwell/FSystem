using System;
using System.Collections.Generic;
using System.IO;

namespace FSystem.Common.Interfaces
{
    public interface IReader
    {
        IEnumerable<IRecord> Read(Stream input, char deliminter);
    }
}
