using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FSystem.Common.Interfaces;

namespace FSystem.Common
{
    /// <summary>
    /// Concrete implementation of <see cref="IReader"/>
    /// </summary>
    public class Reader : IReader
    {
        /// <summary>
        /// Converts an <see cref="IEnumerable{string}"/>  to an <see cref="IEnumerable{IRecord}"/>
        /// </summary>
        /// <returns>An <see cref="IEnumerable{IRecord}"/> that contains
        /// an instance of <see cref="IRecord"/> for each valid line in the
        /// stream</returns>
        /// <param name="input">An <see cref="IEnumerable{string}"/> that contains a single line
        /// </param>
        /// <param name="delimiter">A char that is used to delimite each line
        /// of input.</param>
        public IEnumerable<IRecord> Read(IEnumerable<string> input, char delimiter)
        {
            return input.Select(line =>
            {
                var fields = line.Split(delimiter);
                return new Record(fields[1], fields[0], fields[2], fields[3], fields[4]);
            }).ToList(); 
        }
    }
}
