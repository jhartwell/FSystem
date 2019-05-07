using System;
using System.Text;

namespace FSystem.Api.Model
{
    public class DataStore : IDataStore
    {
        private StringBuilder input;

        public DataStore()
        {
            input = new StringBuilder();
        }

        public void Add(string line)
        {
            input.AppendLine(line);
        }

        public string Data => input.ToString();
    }
}
