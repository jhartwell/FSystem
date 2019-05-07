using System;
using System.Collections.Generic;
using System.IO;

namespace FSystem.Common.Interfaces
{
    public interface IInputService
    {
        IEnumerable<IRecord> GetPipeDelimitedRecords(string input);
        IEnumerable<IRecord> GetSpaceDelimitedRecords(string input);
        IEnumerable<IRecord> GetCommaDelimitedRecords(string input);
    }
}
