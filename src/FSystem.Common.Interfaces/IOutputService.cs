using System;
using System.Collections.Generic;

namespace FSystem.Common.Interfaces
{
    public interface IOutputService
    {
        IEnumerable<IRecord> Records { get; }
        void SortBy(string fieldName);
    }
}
