using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using FSystem.Common.Interfaces;

namespace FSystem.Api.Model
{
    public class DataStore : IDataStore
    {
        private Dictionary<string, List<IRecord>> recordMap;

        public DataStore()
        {
            recordMap = new Dictionary<string, List<IRecord>>();
        }

        public void Add(string key, IRecord line)
        {
            if (!recordMap.ContainsKey(key))
            {
                recordMap[key] = new List<IRecord>();
            }
            recordMap[key].Add(line);
        }

        public void Add(string key, IEnumerable<IRecord> lines)
        {
            if(!recordMap.ContainsKey(key))
            {
                recordMap[key] = new List<IRecord>();
            }
            recordMap[key].AddRange(lines);
        }

        public IEnumerable<IRecord> GetData(string key)
        {
            return recordMap[key] != null ? recordMap[key] : new List<IRecord>();
        }
    }
}
