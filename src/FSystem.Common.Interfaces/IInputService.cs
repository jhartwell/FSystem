using System;
using System.Collections.Generic;
using System.IO;

namespace FSystem.Common.Interfaces
{
    public interface IInputService
    {
        IEnumerable<IRecord> GetRecords(string input);
    }
}
