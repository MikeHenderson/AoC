using System.Collections.Generic;
using Chownus.AoC.Console;
using Chownus.AoC.Console._2017._8;
using Xunit;

namespace Chownus.AoC.Tests._2017._8
{
    public class Day8Tests
    {
        private readonly IAoCSolution _testObject;
        private readonly IList<string> _input;

        public Day8Tests()
        {
            _input = new List<string>
            {
                "b inc 5 if a > 1",
                "a inc 1 if b < 5",
                "c dec -10 if a >= 1",
                "c inc -20 if c == 10",
            };

            _testObject = new Solution();
        }

        [Fact]
        public void Part1()
        {
            var solution = _testObject.RunPart1(_input);
            Assert.Equal("1", solution);
        }

        [Fact]
        public void Part2()
        {
            var solution = _testObject.RunPart2(_input);
            Assert.Equal("10", solution);
        }
    }
}