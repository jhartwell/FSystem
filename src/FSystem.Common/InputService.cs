using System;
using System.Collections.Generic;
using System.IO;
using FSystem.Common.Interfaces;

namespace FSystem.Common
{
    public class InputService : IInputService
    {
        private IReader inputReader;
        public InputService(IReader reader)
        {
            inputReader = reader;
        }

        public IEnumerable<IRecord> GetCommaDelimitedRecords(Stream input)
        {
            return inputReader.Read(input, ',');
        }

        public IEnumerable<IRecord> GetPipeDelimitedRecords(Stream input)
        {
            return inputReader.Read(input, '|');
        }

        public IEnumerable<IRecord> GetSpaceDelimitedRecords(Stream input)
        {
            return inputReader.Read(input, ' ');
        }
    }
}
