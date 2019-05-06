using System;
using System.Linq;
using FSystem.Common.Interfaces;
using Xunit;

namespace FSystem.Common.Tests
{
    public class InputTests
    {
        private InputData inputData;

        public InputTests()
        {
            inputData = new InputData();
        }

        [Fact]
        public void TestSingleCommaInput()
        {
            var (rawString, stream) = inputData.SingleRecordCommaDelimited();
            var inputService = new InputService(new Reader());
            var records = inputService.GetCommaDelimitedRecords(stream);
            Assert.NotNull(records);
            Assert.NotEmpty(records);

            var firstRecord = records.FirstOrDefault();
            Assert.NotNull(firstRecord);

            var fields = rawString.Split(',');
            Assert.Equal(4, fields.Length);

            Assert.Equal(fields[0], firstRecord.LastName);
            Assert.Equal(fields[1], firstRecord.FirstName);
            Assert.Equal(fields[2], firstRecord.FavoriteColor);
            Assert.Equal(fields[3], firstRecord.DateOfBirth);

        }

        [Fact]
        public void TestSinglePipeInput()
        {
            var (rawString, stream) = inputData.SingleRecordPipeDelimited();
            var inputService = new InputService(new Reader());
            var records = inputService.GetPipeDelimitedRecords(stream);
            Assert.NotNull(records);
            Assert.NotEmpty(records);

            var firstRecord = records.FirstOrDefault();
            Assert.NotNull(firstRecord);

            var fields = rawString.Split('|');
            Assert.Equal(4, fields.Length);

            Assert.Equal(fields[0], firstRecord.LastName);
            Assert.Equal(fields[1], firstRecord.FirstName);
            Assert.Equal(fields[2], firstRecord.FavoriteColor);
            Assert.Equal(fields[3], firstRecord.DateOfBirth);
        }

        [Fact]
        public void TestSingleSpaceInput()
        {
            var (rawString, stream) = inputData.SingleRecordSpaceDelimited();
            var inputService = new InputService(new Reader());
            var records = inputService.GetSpaceDelimitedRecords(stream);
            Assert.NotNull(records);
            Assert.NotEmpty(records);

            var firstRecord = records.FirstOrDefault();
            Assert.NotNull(firstRecord);

            var fields = rawString.Split(' ');
            Assert.Equal(4, fields.Length);

            Assert.Equal(fields[0], firstRecord.LastName);
            Assert.Equal(fields[1], firstRecord.FirstName);
            Assert.Equal(fields[2], firstRecord.FavoriteColor);
            Assert.Equal(fields[3], firstRecord.DateOfBirth);
        }
    }
}
