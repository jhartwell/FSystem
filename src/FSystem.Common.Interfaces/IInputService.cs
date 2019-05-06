using System;
using System.Collections.Generic;
using System.IO;

namespace FSystem.Common.Interfaces
{
    public interface IInputService
    {
        IEnumerable<IRecord> GetPipeDelimitedRecords();
        IEnumerable<IRecord> GetSpaceDelimitedRecords();
        IEnumerable<IRecord> GetCommaDelimitedRecords();
    }
}
