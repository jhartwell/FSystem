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

        /// <summary>
        /// Save the specified records to a given stream
        /// </summary>
        /// <param name="records">An <see cref="IEnumerable{IRecord}"/> containing the records
        /// to be saved.</param>
        /// <param name="stream">A <see cref="Stream"/> that will be written too</param>
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
