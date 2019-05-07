using System;
using System.Collections.Generic;
using System.IO;

namespace FSystem.Common.Interfaces
{
    public interface IReader
    {
        IEnumerable<IRecord> Read(IEnumerable<string> input, char deliminter);
    }
}
