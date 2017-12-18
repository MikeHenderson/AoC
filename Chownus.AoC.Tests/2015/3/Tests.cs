using System.Collections.Generic;
using Chownus.AoC.Console;
using Chownus.AoC.Console._2015._3;
using Xunit;

namespace Chownus.AoC.Tests._2015._3
{
    public class Tests
    {
        private readonly IAoCSolution _testObject;

        public Tests()
        {
            _testObject = new Solution();
        }

        [Theory]
        [InlineData(">", 2)]
        [InlineData("^>v<", 4)]
        [InlineData("^v^v^v^v^v", 2)]
        public void Part1(string input, int expected)
        {
            var solution = _testObject.RunPart1(new List<string> { input });
            Assert.Equal(expected.ToString(), solution);
        }

        [Theory]
        [InlineData("^v", 3)]
        [InlineData("^>v<", 3)]
        [InlineData("^v^v^v^v^v", 11)]
        public void Part2(string input, int expected)
        {
            var solution = _testObject.RunPart2(new List<string> { input });
            Assert.Equal(expected.ToString(), solution);
        }
    }
}