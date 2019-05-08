using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using FSystem.Common.Interfaces;

namespace FSystem.Common
{
    /// <summary>
    /// Concrete implementation of <see cref="IReader"/>
    /// </summary>
    public class Reader : IReader
    {
        private Regex commaRegex;
        private Regex spaceRegex;
        private Regex pipeRegex;

        private const string CommaRegexPattern = @"([^,]+),([^,]+),([^,]+),([^,]+),([^,]+)";
        private const string PipeRegexPattern = @"([^|]+)|([^|]+)|([^|]+)|([^|]+)|([^|]+)";
        private const string SpaceRegexPattern = @"([^\s]+)\s([^\s]+)\s([^\s]+)\s([^\s]+)\s([^\s]+)";

        public Reader()
        {
            commaRegex = new Regex(CommaRegexPattern);
            pipeRegex = new Regex(PipeRegexPattern);
            spaceRegex = new Regex(SpaceRegexPattern);
        }
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
        public IEnumerable<IRecord> Read(IEnumerable<string> input)
        {
            var records = new List<IRecord>();
            foreach(var line in input)
            {
                Match regexMatch = null;
                if(commaRegex.IsMatch(line))
                {
                    regexMatch = commaRegex.Match(line);
                } else if (spaceRegex.IsMatch(line))
                {
                    regexMatch = spaceRegex.Match(line);
                } else if(pipeRegex.IsMatch(line))
                {
                    regexMatch = pipeRegex.Match(line);
                }
                if (regexMatch != null)
                {
                    var groups = regexMatch.Groups;
                    records.Add(new Record(
                        lastName: groups[2].Value,
                        firstName: groups[3].Value,
                        gender: groups[4].Value,
                        favoriteColor: groups[5].Value,
                        dateOfBirth: groups[6].Value));
                }
            }
            return records;
        }
    }
}
