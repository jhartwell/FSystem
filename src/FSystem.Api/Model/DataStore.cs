using System;
using System.Collections.Generic;

namespace FSystem.Api.Model
{
    public class DataStore : IDataStore
    {
        private IEnumerable<string> rawRecords;

        public DataStore()
        {
            rawRecords = new List<string>();
        }

        public void Add(string line)
        {
            rawRecords.Add(line);
        }

        public IEnumerable<string> GetAll()
        {
            return rawRecords;
        }
    }
}
