using System.Collections.Generic;
using Chownus.AoC.Console;
using Chownus.AoC.Console._2015._1;
using Xunit;

namespace Chownus.AoC.Tests._2015._1
{
    public class Day1Tests
    {
        private readonly IAoCSolution _testObject;
        private readonly IList<string> _input;

        public Day1Tests()
        {
            _input = new List<string> { ")())())" };
            _testObject = new Solution();
        }

        [Fact]
        public void Part1()
        {
            var solution = _testObject.RunPart1(_input);
            Assert.Equal("-3", solution);
        }

        [Fact]
        public void Part2()
        {
            var solution = _testObject.RunPart2(_input);
            Assert.Equal("1", solution);
        }
    }
}