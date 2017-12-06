using System.Collections.Generic;
using Chownus.AoC.Console;
using Xunit;

namespace Chownus.AoC.Tests
{
    public class Day6Tests
    {
        private readonly IAoCSolution _testObject;

        public Day6Tests()
        {
            var input = new List<string> { "0 2 7 0"};
            _testObject = new Day6Solution();
            _testObject.Initialize(input);
        }

        [Fact]
        public void Part1()
        {
            var solution = _testObject.RunPart1();
            Assert.Equal("5", solution);
        }

        [Fact]
        public void Part2()
        {
            var solution = _testObject.RunPart2();
            Assert.Equal("4", solution);
        }
    }
}