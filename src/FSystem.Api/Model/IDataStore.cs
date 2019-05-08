using System;
using System.Collections.Generic;
using FSystem.Common.Interfaces;

namespace FSystem.Api.Model
{
    public interface IDataStore
    {
        void Add(string key, IRecord record);
        void Add(string key, IEnumerable<IRecord> records);
        IEnumerable<IRecord> GetData(string key);
    }
}
