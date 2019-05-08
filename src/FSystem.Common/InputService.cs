using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
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

        public IEnumerable<IRecord> GetRecords(string input)
        {
            var recordLines = new List<string>();
            using (var stringReader = new StringReader(input))
            {
                string line;
                while((line = stringReader.ReadLine()) != null)
                {
                    recordLines.Add(line);
                }
                return inputReader.Read(recordLines);
            }
        }
    }
}
