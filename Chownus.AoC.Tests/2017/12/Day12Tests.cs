using System.Collections;
using System.Collections.Generic;
using Chownus.AoC.Console;
using Xunit;

namespace Chownus.AoC.Tests
{
    public class Day12Tests
    {
        private readonly IAoCSolution _testObject;
        private readonly IList<string> _input;


        public Day12Tests()
        {
            _testObject = new Day12Solution();
            _input = new List<string>
            {
                "0 <-> 2",
                "1 <-> 1",
                "2 <-> 0, 3, 4",
                "3 <-> 2, 4",
                "4 <-> 2, 3, 6",
                "5 <-> 6",
                "6 <-> 4, 5"
            };
        }

        [Fact]
        public void Part1()
        {
            var solution = _testObject.RunPart1(_input);

            Assert.Equal("6", solution);
        }

        [Fact]
        public void Part2()
        {
            var solution = _testObject.RunPart2(_input);

            Assert.Equal("2", solution);
        }
    }
}