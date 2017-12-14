using System.Collections.Generic;
using System.Linq;
using Chownus.AoC.Console;
using Chownus.AoC.Console.Common.Helpers;
using Chownus.AoC.Console._2017._14;
using Xunit;

namespace Chownus.AoC.Tests._2017._14
{
    public class Day14Tests
    {
        private readonly IAoCSolution _testObject;
        private readonly IList<string> _input;

        public Day14Tests()
        {
            _testObject = new Solution();
            _input = new List<string>
            {
                "flqrgnkx"
            };

        }

        [Fact]
        public void Part1()
        {
            var solution = _testObject.RunPart1(_input);

            Assert.Equal("8108", solution);
        }

        [Fact]
        public void Part2()
        {
            var solution = _testObject.RunPart2(_input);

            Assert.Equal("1242", solution);
        }
    }
}