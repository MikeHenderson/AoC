using System.Collections.Generic;
using Chownus.AoC.Console;
using Chownus.AoC.Console._2017._15;
using Xunit;

namespace Chownus.AoC.Tests._2017._15
{
    public class Day15Tests
    {
        private readonly IAoCSolution _testObject;
        private readonly IList<string> _input;

        public Day15Tests()
        {
            _testObject = new Solution();
            _input = new List<string>
            {
                "65,8921"
            };

        }

        [Fact]
        public void Part1()
        {
            var solution = _testObject.RunPart1(_input);

            Assert.Equal("588", solution);
        }

        [Fact]
        public void Part2()
        {
            var solution = _testObject.RunPart2(_input);

            Assert.Equal("309", solution);
        }
    }
}