using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace FSystem.Api.Tests
{
    public class BasicTests : IClassFixture<FSystemWebApiTesterFactory>
    {
        private readonly FSystemWebApiTesterFactory factory;

        public BasicTests(FSystemWebApiTesterFactory factory)
        {
            this.factory = factory;
        }

        [Theory]
        [InlineData("/Records")]
        public async Task GetEmptyIndex(string url)
        {
            var client = factory.CreateClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            Assert.Equal(string.Empty, response.Content.ToString());

        }
    }
}
    