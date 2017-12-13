using System.Collections.Generic;
using Chownus.AoC.Console;
using Chownus.AoC.Console._2017._6;
using Xunit;

namespace Chownus.AoC.Tests._2017._6
{
    public class Day6Tests
    {
        private readonly IAoCSolution _testObject;
        private readonly IList<string> _input;

        public Day6Tests()
        {
            _input = new List<string> { "0 2 7 0"};
            _testObject = new Solution();
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
            Assert.Equal("4", solution);
        }
    }
}