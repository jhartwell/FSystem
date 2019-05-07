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
        /// <returns>A <see cref="string"/> that contains the saved, formatted records</returns>
        /// <param name="records">An <see cref="IEnumerable{IRecord}"/> containing the records
        /// to be saved.</param>
        public string Save(IEnumerable<IRecord> records)
        {
            return outputFormatter.Format(records);
        }
    }
}
