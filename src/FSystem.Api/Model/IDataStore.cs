using System;
using System.Collections.Generic;

namespace FSystem.Api.Model
{
    public interface IDataStore
    {
        void Add(string line);
        IEnumerable<string> GetAll();
    }
}
