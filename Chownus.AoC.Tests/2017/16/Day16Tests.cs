using System.Collections.Generic;
using Chownus.AoC.Console;
using Chownus.AoC.Console._2017._16;
using Xunit;

namespace Chownus.AoC.Tests._2017._16
{
    public class Day16Tests
    {
        private readonly IAoCSolution _testObject;
        private readonly IList<string> _input;

        public Day16Tests()
        {
            _testObject = new Solution();
            _input = new List<string>
            {
                "5",
                "s1,x3/4,pe/b"
            };

        }

        [Fact]
        public void Part1()
        {
            var solution = _testObject.RunPart1(_input);

            Assert.Equal("baedc", solution);
        }

        [Fact]
        public void Part2()
        {
            var solution = _testObject.RunPart2(_input);

            Assert.Equal("abcde", solution);
        }
    }
}