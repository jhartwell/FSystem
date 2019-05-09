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

        /// <summary>
        /// This regex will parse a line by ensuring that there is a comma
        /// separating the 5 fields
        /// Patterns:
        ///   [^,]+ -> Matches one or more characters that is not a comma
        ///   [,] -> Matches a single comma
        /// </summary>
        private const string CommaRegexPattern = @"([^,]+)[,]([^,]+)[,]([^,]+)[,]([^,]+)[,]([^,]+)";

        /// <summary>
        /// This regex will parse a line by ensuring that there is a pipe 
        /// separating the 5 fields
        /// Patterns:
        ///    [^|]+ -> Matches one or more characters that are not pipes
        ///    [|] -> Matches a single pipe
        /// </summary>
        private const string PipeRegexPattern = @"([^\s]+)[|]([^\s]+)[|]([^\s]+)[|]([^\s]+)[|]([^\s]+)";

        /// <summary>
        /// This regex will parse a line by ensuring that there is a space 
        /// separating the 5 fields
        /// Patterns:
        ///    [^\s]+ -> Matches one or more characters that are not spaces
        ///    [\s] -> Matches a single space
        /// </summary>
        private const string SpaceRegexPattern = @"([^\s]+)[\s]([^\s]+)[\s]([^\s]+)[\s]([^\s]+)[\s]([^\s]+)";

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
                        lastName: groups[1].Value,
                        firstName: groups[2].Value,
                        gender: groups[3].Value,
                        favoriteColor: groups[4].Value,
                        dateOfBirth: DateTime.Parse(groups[5].Value).ToString("m/d/YYYY")));
                }
            }
            return records;
        }
    }
}
