using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using FSystem.Common;
using FSystem.Common.Interfaces;
using FSystem.Tests.Shared;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;

namespace FSystem.Api.Tests
{
    public class IntegrationTests : IClassFixture<FSystemWebApiTesterFactory>
    {
        const string PipeRecord = "Scott|Michael|Male|Blue|5/2/1972";
        const string CommaRecord = "Scott,Michael,Male,Blue,5/2/1972";
        const string SpaceRecord = "Scott Michael Male Blue 5/2/1972";

        private readonly FSystemWebApiTesterFactory factory;

        public IntegrationTests(FSystemWebApiTesterFactory factory)
        {
            this.factory = factory;
        }

        [Theory]
        [InlineData("/Records", "1")]
        public async Task GetEmptyIndex(string url, string session)
        {
            var client = factory.CreateClient();
            var response = await client.GetAsync($"{url}?session={session}");
            response.EnsureSuccessStatusCode();
            var expectedResult = JsonConvert.SerializeObject(new { items = new List<IRecord>()});
            Assert.Equal(expectedResult, await response.Content.ReadAsStringAsync());

        }

        [Theory]
        //[InlineData("/Records", PipeRecord, "2")]
        //[InlineData("/Records", SpaceRecord, "3")]
        [InlineData("/Records", CommaRecord, "4")]
        public async Task AddRecord(string url, string record, string session)
        {
            var client = factory.CreateClient();
            var response = await client.PostAsync($"{url}?session={session}", new StringContent(record));
            Assert.Equal(HttpStatusCode.OK, response.EnsureSuccessStatusCode().StatusCode);

        }

        [Theory]
        [InlineData("/Records", CommaRecord, "5")]
        public async Task AddAndRetrieve(string url, string record, string session)
        {
            var client = factory.CreateClient();
            var postResponse = await client.PostAsync($"{url}?session={session}", new StringContent(record));
            Assert.Equal(HttpStatusCode.OK, postResponse.EnsureSuccessStatusCode().StatusCode);

            var getResponse = await client.GetAsync($"{url}?session={session}");
            var inputService = new InputService(new Reader());
            var outputService = new OutputService(new JsonFormat());
            var expectedRecords = inputService.GetCommaDelimitedRecords(record);
            var expectedOutput = outputService.Save(expectedRecords);

            Assert.Equal(expectedOutput, await getResponse.Content.ReadAsStringAsync());
        }

        [Theory]
        [InlineData("/Records", "name", "6")]
        [InlineData("/Records", "birthdate", "7")]
        [InlineData("/Records", "gender", "8")]
        public async Task AddAndRetrieveSorted(string url, string sortBy, string session)
        {
            var data = new InputData();
            var rawRecord = data.MultipleRecordCommaDelimited();

            var client = factory.CreateClient();
            var postResponse = await client.PostAsync($"{url}?session={session}", new StringContent(rawRecord));
            Assert.Equal(HttpStatusCode.OK, postResponse.StatusCode);

            var getResponse = await client.GetAsync($"{url}/{sortBy}?session={session}");
            Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);

            var actualOutput = await getResponse.Content.ReadAsStringAsync();
            var inputService = new InputService(new Reader());
            var records = inputService.GetCommaDelimitedRecords(rawRecord);
            switch(sortBy)
            {
                case "name":
                    records = records.OrderBy(x => x.LastName);
                    break;
                case "birthdate":
                    records = records.OrderBy(x => x.DateOfBirth);
                    break;
                case "gender":
                    records = records.OrderBy(x => x.Gender);
                    break;
            }
            var outputService = new OutputService(new JsonFormat());
            var expectedOutput = outputService.Save(records);
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
    