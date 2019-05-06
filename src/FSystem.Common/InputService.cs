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
        /// Reads the given <see cref="Stream"/> and will parse using a
        /// comma as the delimiter
        /// </summary>
        /// <returns>An <see cref="IEnumerable{IRecord}"/> that contains
        /// a <see cref="IRecord"/> for each line on the read stream.</returns>
        /// <param name="input">A <see cref="Stream"/> that contains the 
        /// underlying input data</param>
        public IEnumerable<IRecord> GetCommaDelimitedRecords(Stream input)
        {
            return inputReader.Read(input, ',');
        }

        /// <summary>
        /// Reads the given <see cref="Stream"/> and will parse using a
        /// pipe as the delimiter
        /// </summary>
        /// <returns>An <see cref="IEnumerable{IRecord}"/> that contains
        /// a <see cref="IRecord"/> for each line on the read stream.</returns>
        /// <param name="input">A <see cref="Stream"/> that contains the 
        /// underlying input data</param>
        public IEnumerable<IRecord> GetPipeDelimitedRecords(Stream input)
        {
            return inputReader.Read(input, '|');
        }

        /// <summary>
        /// Reads the given <see cref="Stream"/> and will parse using a
        /// space as the delimiter
        /// </summary>
        /// <returns>An <see cref="IEnumerable{IRecord}"/> that contains
        /// a <see cref="IRecord"/> for each line on the read stream.</returns>
        /// <param name="input">A <see cref="Stream"/> that contains the 
        /// underlying input data</param>
        public IEnumerable<IRecord> GetSpaceDelimitedRecords(Stream input)
        {
            return inputReader.Read(input, ' ');
        }
    }
}
