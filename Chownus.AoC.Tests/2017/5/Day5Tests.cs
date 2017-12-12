using System.Collections.Generic;
using Chownus.AoC.Console;
using Xunit;

namespace Chownus.AoC.Tests
{
    public class Day5Tests
    {
        private readonly IAoCSolution _testObject;
        private readonly IList<string> _input;

        public Day5Tests()
        {
            _input = new List<string> { "0", "3", "0", "1", "-3" };
            _testObject = new Day5Solution();
        }

        [Fact]
        public void Part1()
        {
            var solution = _testObject.RunPart1(_input);
            Assert.Equal("5", solution);
        }

        [Fact]
        public void Part2()
        {
            var solution = _testObject.RunPart2(_input);
            Assert.Equal("10", solution);
        }
    }
}