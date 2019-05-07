using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FSystem.Common.Interfaces;

namespace FSystem.Common
{
    public class OutputService : IOutputService
    {
        private IFormat outputFormatter;

        public OutputService(IFormat formatter)
        {
            outputFormatter = formatter;
        }

        public void Save(IEnumerable<IRecord> records, Stream stream)
        {
            var writer = new StreamWriter(stream);
            writer.Write(outputFormatter.Format(records));
            writer.Flush();
            stream.Position = 0;
        }

        public void SortBy(string fieldName)
        {
            throw new NotImplementedException();
        }
    }
}
