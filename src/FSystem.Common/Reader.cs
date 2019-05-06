using System;
using System.Collections.Generic;
using System.IO;
using FSystem.Common.Interfaces;

namespace FSystem.Common
{
    public class Reader : IReader
    {
        public IEnumerable<IRecord> Read(Stream input, char deliminter)
        {
            var records = new List<IRecord>();
            using (var reader = new StreamReader(input))
            {
                while (!reader.EndOfStream)
                {
                    string[] fields = reader.ReadLine().Split(deliminter);
                    records.Add(new Record(fields[0], fields[1], fields[2], fields[3]));
                }
            }
            return records;
        }
    }
}
