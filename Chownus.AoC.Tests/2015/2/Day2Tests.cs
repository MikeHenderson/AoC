using System.Collections.Generic;
using Chownus.AoC.Console;
using Chownus.AoC.Console._2015._2;
using Xunit;

namespace Chownus.AoC.Tests._2015._2
{
    public class Day2Tests
    {
        private readonly IAoCSolution _testObject;
        private readonly IList<string> _input;

        public Day2Tests()
        {
            _input = new List<string> { "2x3x4" };
            _testObject = new Solution();
        }

        [Fact]
        public void Part1()
        {
            var solution = _testObject.RunPart1(_input);
            Assert.Equal("58", solution);
        }

        [Fact]
        public void Part2()
        {
            var solution = _testObject.RunPart2(_input);
            Assert.Equal("34", solution);
        }
    }
}