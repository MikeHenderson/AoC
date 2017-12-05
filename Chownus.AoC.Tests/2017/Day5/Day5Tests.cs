using System.Collections.Generic;
using Chownus.AoC.Console;
using Chownus.AoC.Console._2017.Day5;
using Xunit;

namespace Chownus.AoC.Tests._2017.Day5
{
    public class Day5Tests
    {
        private IAoCSolution _testObject;

        [Fact]
        public void Part1()
        {
            var input = new List<string> {"0", "3", "0", "1", "-3"};
            _testObject = new Day5Solution();
            _testObject.Initialize(input);

            var solution = _testObject.RunPart1();

            Assert.Equal("5", solution);
        }

        [Fact]
        public void Part2()
        {
            var input = new List<string> { "0", "3", "0", "1", "-3" };
            _testObject = new Day5Solution();
            _testObject.Initialize(input);

            var solution = _testObject.RunPart2();

            Assert.Equal("10", solution);
        }

    }
}
