using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FSystem.Common.Interfaces;

namespace FSystem.Common
{
    /// <summary>
    /// Concrete implementation of <see cref="IOutputService"/>
    /// </summary>
    public class OutputService : IOutputService
    {
        private IFormat outputFormatter;

        /// <summary>
        /// Initializes a new instance of the <see cref="OutputService"/> class.
        /// </summary>
        /// <param name="formatter">An instance of <see cref="IFormat"/> that will
        /// be used to format the output.</param>
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
