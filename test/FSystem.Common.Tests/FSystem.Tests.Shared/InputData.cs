using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace FSystem.Tests.Shared
{
    public class InputData
    {
        private IEnumerable<string[]> records;

        public InputData()
        {
            records = new List<string[]>()
            {
                new[] {"Scott", "Michael", "Male", "Blue", "5/11/2000"},
                new[] {"Malone", "Kevin", "Male", "Red", "1/23/1948"},
                new[] {"Martinez", "Oscar", "Male", "Green", "12/3/1982"},
                new[] {"Halpert", "Jim", "Male", "Maroon", "3/4/1973"},
                new[] {"Beasley", "Pam", "Female", "Purple", "7/1/1976"}
            };
        }


        private string SingleRecord(string delimiter)
        {
            return string.Join(delimiter, records.First());
        }

        private string MultipleRecords(string delimiter)
        {
            return records.Aggregate(string.Empty, (recs, r) => recs + string.Join(delimiter, r) + Environment.NewLine);
        }

        public string SingleRecordCommaDelimited()
        {
            return SingleRecord(",");
        }

        public string MultipleRecordCommaDelimited()
        {
            return MultipleRecords(",");
        }

        public string SingleRecordSpaceDelimited()
        {
            return SingleRecord(" ");
        }

        public string MultipleRecordSpaceDelimited()
        {
            return MultipleRecords(" ");
        }

        public string SingleRecordPipeDelimited()
        {
            return SingleRecord("|");
        }

        public string MultipleRecordPipeDelimited()
        {
            return MultipleRecords("|");
        }
    }
}
