using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace FSystem.Common.Tests
{
    public class InputData
    {
        IEnumerable<string[]> records;

        public InputData()
        {
            records = new List<string[]>()
            {
                new[] {"Scott", "Michael", "Blue", "5/11/2000"},
                new[] {"Malone", "Kevin", "Red", "1/23/1948"},
                new[] {"Martinez", "Oscar", "Green", "12/3/1982"},
                new[] {"Halpert", "Jim", "Maroon", "3/4/1973"},
                new[] {"Beasley", "Pam", "Purple", "7/1/1976"}
            };
        }

        private Stream ToStream(string recordText)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(recordText);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        private string SingleRecord(char delimiter)
        {
            return string.Join(delimiter, records.First());
        }

        private string MultipleRecords(char delimiter)
        {
            return records.Aggregate(string.Empty, (recs, r) => recs + Environment.NewLine + string.Join(delimiter, r));                           
        }

        public (string, Stream) SingleRecordCommaDelimited()
        {
            var singleRecord = SingleRecord(',');
            return (singleRecord, ToStream(singleRecord));
        }

        public (IEnumerable<string[]>, Stream) MultipleRecordCommaDelimited()
        {
            return (records, ToStream(MultipleRecords(',')));
        }

        public (string, Stream) SingleRecordSpaceDelimited()
        {
            var singleRecord = SingleRecord(' ');
            return (singleRecord, ToStream(SingleRecord(' ')));
        }

        public (IEnumerable<string[]>, Stream) MultipleRecordSpaceDelimited()
        {
            return (records, ToStream(MultipleRecords(' ')));
        }

        public (string, Stream) SingleRecordPipeDelimited()
        {
            var singleRecord = SingleRecord('|');
            return (singleRecord, ToStream(singleRecord));
        }

        public (IEnumerable<string[]>, Stream) MultipleRecordPipeDelimited()
        {
            return (records, ToStream(MultipleRecords('|')));
        }
    }
}
