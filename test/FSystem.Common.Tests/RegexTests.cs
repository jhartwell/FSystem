using System;
using System.Text.RegularExpressions;
using Xunit;

namespace FSystem.Common.Tests
{
    public class RegexTests
    {
        [Theory]
        [InlineData("Scott|Michael|Male|Blue|5/11/2000")]
        [InlineData("Scott |Michael|Male |Blue|5/11/2000")]
        public void TestPipeRegex(string input)
        {
            var regex = new Regex(@"([^|]+)[|]([^|]+)[|]([^|]+)[|]([^|]+)[|]([^|]+)");
            Assert.True(regex.IsMatch(input));
            var groups = regex.Match(input).Groups;
            Assert.Equal("Scott", groups[1].Value.Trim());
            Assert.Equal("Michael", groups[2].Value.Trim());
            Assert.Equal("Male", groups[3].Value.Trim());
            Assert.Equal("Blue", groups[4].Value.Trim());
            Assert.Equal("5/11/2000", groups[5].Value.Trim());
        }

        [Theory]
        [InlineData("Scott Michael Male Blue 5/11/2000")]
        public void TestSpaceRegex(string input)
        {
            var regex = new Regex(@"([^\s]+)[\s]([^\s]+)[\s]([^\s]+)[\s]([^\s]+)[\s]([^\s]+)");
            Assert.True(regex.IsMatch(input));
            var groups = regex.Match(input).Groups;
            Assert.Equal("Scott", groups[1].Value.Trim());
            Assert.Equal("Michael", groups[2].Value.Trim());
            Assert.Equal("Male", groups[3].Value.Trim());
            Assert.Equal("Blue", groups[4].Value.Trim());
            Assert.Equal("5/11/2000", groups[5].Value.Trim());
        }

        [Theory]
        [InlineData("Scott,Michael,Male,Blue,5/11/2000")]
        public void TestCommaRegex(string input)
        {
            var regex = new Regex(@"([^,]+)[,]([^,]+)[,]([^,]+)[,]([^,]+)[,]([^,]+)");
            Assert.True(regex.IsMatch(input));
            var groups = regex.Match(input).Groups;
            Assert.Equal("Scott", groups[1].Value.Trim());
            Assert.Equal("Michael", groups[2].Value.Trim());
            Assert.Equal("Male", groups[3].Value.Trim());
            Assert.Equal("Blue", groups[4].Value.Trim());
            Assert.Equal("5/11/2000", groups[5].Value.Trim());
        }
    }
}
