using System;
using System.Collections.Generic;
using System.IO;
using FSystem.Common.Interfaces;

namespace FSystem.Common
{
    /// <summary>
    /// Concrete implementation of <see cref="IInputService"/>
    /// </summary>
    public class InputService : IInputService
    {
        private IReader inputReader;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:FSystem.Common.InputService"/> class.
        /// </summary>
        /// <param name="reader">An implementation of <see cref="IReader"/> that
        /// is used to read any input given</param>
        public InputService(IReader reader)
        {
            inputReader = reader;
        }

        /// <summary>
        /// Converts the records from string format into a <see cref="IRecord"/>
        /// by using a comma as the delimiter
        /// </summary>
        /// <returns>An <see cref="IEnumerable{IRecord}"/> that contains
        /// a <see cref="IRecord"/> for each line on the read stream.</returns>
        /// <param name="input">A <see cref="string"/> that contains the 
        /// underlying input data with each record separated by a newline</param>
        public IEnumerable<IRecord> GetCommaDelimitedRecords(string input)
        {
            return inputReader.Read(input.Trim().Split('\n'), ',');
        }

        /// <summary>
        /// Converts the records from string format into a <see cref="IRecord"/> by
        /// using a pipe as a delimiter
        /// </summary>
        /// <returns>An <see cref="IEnumerable{IRecord}"/> that contains
        /// a <see cref="IRecord"/> for each line on the read stream.</returns>
        /// <param name="input">A <see cref="string"/> that contains the 
        /// underlying input data with each record separated by a newline
        public IEnumerable<IRecord> GetPipeDelimitedRecords(string input)
        {
            return inputReader.Read(input.Trim().Split('\n'), '|');
        }

        /// <summary>
        /// Converts the records from string format into a <see cref="IRecord"/> by
        /// using a whitespace as the delimiter
        /// </summary>
        /// <returns>An <see cref="IEnumerable{IRecord}"/> that contains
        /// a <see cref="IRecord"/> for each line on the read stream.</returns>
        /// <param name="input">A <see cref="string"/> that contains the 
        /// underlying input data with each record separated by a newline</param> 
        public IEnumerable<IRecord> GetSpaceDelimitedRecords(string input)
        {
            return inputReader.Read(input.Trim().Split('\n'), ' ');
        }
    }
}
