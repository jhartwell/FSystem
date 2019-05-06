using System;
using System.Collections.Generic;
using System.IO;
using FSystem.Common.Interfaces;

namespace FSystem.Common
{
    /// <summary>
    /// Concrete implementation of <see cref="IReader"/>
    /// </summary>
    public class Reader : IReader
    {
        /// <summary>
        /// Reads a <see cref="Stream"/> and will split each row based on the 
        /// passed in delimiter
        /// </summary>
        /// <returns>An <see cref="IEnumerable{IRecord}"/> that contains
        /// an instance of <see cref="IRecord"/> for each valid line in the
        /// stream</returns>
        /// <param name="input">A <see cref="Stream"/> that contains the
        /// underlying input</param>
        /// <param name="delimiter">A char that is used to delimite each line
        /// of input.</param>
        public IEnumerable<IRecord> Read(Stream input, char delimiter)
        {
            var records = new List<IRecord>();
            using (var reader = new StreamReader(input))
            {
                while (!reader.EndOfStream)
                {
                    string[] fields = reader.ReadLine().Split(delimiter);
                    records.Add(new Record(fields[1], fields[0], fields[2], fields[3], fields[4]));
                }
            }
            return records;
        }
    }
}
