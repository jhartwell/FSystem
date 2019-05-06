using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FSystem.Common.Interfaces;

namespace FSystem.Common
{
    public class OutputService : IOutputService
    {
        private IEnumerable<IRecord> savedRecords;
        private IFormat outputFormatter;

        public OutputService(IEnumerable<IRecord> records, IFormat formatter)
        {
            savedRecords = records;
            outputFormatter = formatter;
        }

        public void Save(Stream stream)
        {
            using (var writer = new StreamWriter(stream))
            {
                writer.Write(outputFormatter.Format(savedRecords));
            }
        }

        public void SortBy(string fieldName)
        {
            throw new NotImplementedException();
        }
    }
}
