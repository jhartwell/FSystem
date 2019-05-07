using System;
using System.Collections.Generic;
using System.IO;

namespace FSystem.Common.Interfaces
{
    public interface IOutputService
    {
        void SortBy(string fieldName);
        void Save(IEnumerable<IRecord> records, Stream stream);
    }
}
