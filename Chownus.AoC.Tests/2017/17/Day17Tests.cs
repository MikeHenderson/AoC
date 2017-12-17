using System.Collections.Generic;
using Chownus.AoC.Console;
using Chownus.AoC.Console._2017._17;
using Xunit;

namespace Chownus.AoC.Tests._2017._17
{
    public class Day17Tests
    {
        private readonly IAoCSolution _testObject;
        private readonly IList<string> _input;

        public Day17Tests()
        {
            _testObject = new Solution();
            _input = new List<string>
            {
                "3"
            };

        }

        [Fact]
        public void Part1()
        {
            var solution = _testObject.RunPart1(_input);
            Assert.Equal("638", solution);
        }

        [Fact]
        public void Part2()
        {

        }
    }
}