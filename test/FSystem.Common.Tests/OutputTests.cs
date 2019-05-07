using System;
using System.Collections.Generic;
using System.IO;
using FSystem.Common.Interfaces;
using Xunit;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FSystem.Common.Tests
{
    public class OutputTests
    {
        [Fact]
        public void TestOutputOneRecordJsonOutput()
        {
            var record = new Record("Toby", "Flenderson", "Male", "Black", "5/2/1972");
            var outputService = new OutputService(new JsonFormat());
            var output = outputService.Save(new List<IRecord> { record });
            var parsedOutput = JObject.Parse(output);
            var token = parsedOutput["items"].First;
            Assert.Equal(record.FirstName, token["FirstName"]);
            Assert.Equal(record.LastName, token["LastName"]);
            Assert.Equal(record.Gender, token["Gender"]);
            Assert.Equal(record.FavoriteColor, token["FavoriteColor"]);
            Assert.Equal(record.DateOfBirth, token["DateOfBirth"]);
        }

        [Fact]
        public void TestOutputMultipleRecordsJsonOutput()
        {
            var records = new List<IRecord>
            {
                new Record("Toby", "Flenderson", "Male", "Black", "5/2/1972"),
                new Record("Creed", "Bratton", "Male", "Purple", "5/2/1963"),
                new Record("David", "Wallace", "Male", "Green", "9/2/1960"),
                new Record("Jan", "Levinson", "Female", "Red", "10/2/1974")
            };
            var outputService = new OutputService(new JsonFormat());
            var output = outputService.Save(records);
            var parsedOutput = JObject.Parse(output);
            var items = parsedOutput["items"];
            int index = 0;
            foreach(var item in items)
            {
                Assert.Equal(records[index].FirstName, item["FirstName"]);
                Assert.Equal(records[index].LastName, item["LastName"]);
                Assert.Equal(records[index].Gender, item["Gender"]);
                Assert.Equal(records[index].FavoriteColor, item["FavoriteColor"]);
                Assert.Equal(records[index].DateOfBirth, item["DateOfBirth"]);
                index++;
            }
        }
    }
}
