using System.Collections.Generic;
using Chownus.AoC.Console;
using Chownus.AoC.Console._2017._13;
using Xunit;

namespace Chownus.AoC.Tests._2017._13
{
    public class Day13Tests
    {
        private readonly IAoCSolution _testObject;
        private readonly IList<string> _input;

        public Day13Tests()
        {
            _testObject = new Solution();
            _input = new List<string>
            {
                "0: 3",
                "1: 2",
                "4: 4",
                "6: 4"  
            };
        }

        [Fact]
        public void Part1()
        {
            var solution = _testObject.RunPart1(_input);

            Assert.Equal("24", solution);
        }

        [Fact]
        public void Part2()
        {
            var solution = _testObject.RunPart2(_input);

            Assert.Equal("10", solution);
        }
    }
}