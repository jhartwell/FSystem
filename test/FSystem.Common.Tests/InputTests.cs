using System;
using System.Linq;
using FSystem.Common.Interfaces;
using Xunit;

/*
 * TODO: Use reflection on IRecord interface to get number of
 * properties so if properties are added to the interface 
 * we don't have to manually change the tests
 */
namespace FSystem.Common.Tests
{
    public class InputTests
    {
        private InputData inputData;
        private const int expectedRecordFieldCount = 5;
        public InputTests()
        {
            inputData = new InputData();
        }

        [Fact]
        public void TestSingleCommaInput()
        {
            var raw = inputData.SingleRecordCommaDelimited();
            var inputService = new InputService(new Reader());
            var records = inputService.GetCommaDelimitedRecords(raw);
            Assert.NotNull(records);
            Assert.NotEmpty(records);

            var firstRecord = records.FirstOrDefault();
            Assert.NotNull(firstRecord);

            var fields = raw.Split(',');
            Assert.Equal(expectedRecordFieldCount, fields.Length);

            Assert.Equal(fields[0], firstRecord.LastName);
            Assert.Equal(fields[1], firstRecord.FirstName);
            Assert.Equal(fields[2], firstRecord.Gender);
            Assert.Equal(fields[3], firstRecord.FavoriteColor);
            Assert.Equal(fields[4], firstRecord.DateOfBirth);

        }

        [Fact]
        public void TestMultipleCommaDelimitedRecords()
        {
            var raw = inputData.MultipleRecordCommaDelimited();
            var inputService = new InputService(new Reader());
            var records = inputService.GetCommaDelimitedRecords(raw);
            Assert.NotNull(records);
            Assert.NotEmpty(records);

            var rawRecords = raw.Trim().Split('\n').Select(x => x.Split(','));
            Assert.Equal(rawRecords.Count(), records.Count());
            for(int i= 0; i < rawRecords.Count(); i++)
            {
                var rec = records.ElementAt(i);
                var rawRecord = rawRecords.ElementAt(i);
                Assert.Equal(rawRecord[0], rec.LastName);
                Assert.Equal(rawRecord[1], rec.FirstName);
                Assert.Equal(rawRecord[2], rec.Gender);
                Assert.Equal(rawRecord[3], rec.FavoriteColor);
                Assert.Equal(rawRecord[4], rec.DateOfBirth);
            }
        }


        [Fact]
        public void TestSinglePipeInput()
        {
            var raw = inputData.SingleRecordPipeDelimited();
            var inputService = new InputService(new Reader());
            var records = inputService.GetPipeDelimitedRecords(raw);
            Assert.NotNull(records);
            Assert.NotEmpty(records);

            IRecord firstRecord = records.FirstOrDefault();
            Assert.NotNull(firstRecord);

            var fields = raw.Split('|');        
            Assert.Equal(expectedRecordFieldCount, fields.Length);

            Assert.Equal(fields[0], firstRecord.LastName);
            Assert.Equal(fields[1], firstRecord.FirstName);
            Assert.Equal(fields[2], firstRecord.Gender);
            Assert.Equal(fields[3], firstRecord.FavoriteColor);
            Assert.Equal(fields[4], firstRecord.DateOfBirth);
        }

        [Fact]
        public void TestMultiplePipeDelimitedRecords()
        {
            var raw = inputData.MultipleRecordPipeDelimited();
            var inputService = new InputService(new Reader());
            var records = inputService.GetPipeDelimitedRecords(raw);
            Assert.NotNull(records);
            Assert.NotEmpty(records);

            var rawRecords = raw.Trim().Split('\n').Select(x => x.Split('|'));
            Assert.Equal(rawRecords.Count(), records.Count());
            for (int i = 0; i < rawRecords.Count(); i++)
            {
                var rec = records.ElementAt(i);
                var rawRecord = rawRecords.ElementAt(i);
                Assert.Equal(rawRecord[0], rec.LastName);
                Assert.Equal(rawRecord[1], rec.FirstName);
                Assert.Equal(rawRecord[2], rec.Gender);
                Assert.Equal(rawRecord[3], rec.FavoriteColor);
                Assert.Equal(rawRecord[4], rec.DateOfBirth);
            }
        }
        [Fact]
        public void TestSingleSpaceInput()
        {
            var raw = inputData.SingleRecordSpaceDelimited();
            var inputService = new InputService(new Reader());
            var records = inputService.GetSpaceDelimitedRecords(raw);
            Assert.NotNull(records);
            Assert.NotEmpty(records);

            var firstRecord = records.FirstOrDefault();
            Assert.NotNull(firstRecord);

            var fields = raw.Split(' ');
            Assert.Equal(expectedRecordFieldCount, fields.Length);

            Assert.Equal(fields[0], firstRecord.LastName);
            Assert.Equal(fields[1], firstRecord.FirstName);
            Assert.Equal(fields[2], firstRecord.Gender);
            Assert.Equal(fields[3], firstRecord.FavoriteColor);
            Assert.Equal(fields[4], firstRecord.DateOfBirth);
        }

        [Fact]
        public void TestMultipleSpaceDelimitedRecords()
        {
            var raw = inputData.MultipleRecordSpaceDelimited();
            var inputService = new InputService(new Reader());
            var records = inputService.GetSpaceDelimitedRecords(raw);
            Assert.NotNull(records);
            Assert.NotEmpty(records);

            var rawRecords = raw.Trim().Split('\n').Select(x => x.Split(' '));
            Assert.Equal(rawRecords.Count(), records.Count());
            for (int i = 0; i < rawRecords.Count(); i++)
            {
                var rec = records.ElementAt(i);
                var rawRecord = rawRecords.ElementAt(i);
                Assert.Equal(rawRecord[0], rec.LastName);
                Assert.Equal(rawRecord[1], rec.FirstName);
                Assert.Equal(rawRecord[2], rec.Gender);
                Assert.Equal(rawRecord[3], rec.FavoriteColor);
                Assert.Equal(rawRecord[4], rec.DateOfBirth);
            }
        }
    }
}
