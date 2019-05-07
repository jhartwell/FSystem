using System;
using System.Collections.Generic;
using System.IO;

namespace FSystem.Common.Interfaces
{
    public interface IOutputService
    {
        string Save(IEnumerable<IRecord> records);
    }
}
