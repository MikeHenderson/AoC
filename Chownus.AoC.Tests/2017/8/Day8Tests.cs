using System.Collections.Generic;
using Chownus.AoC.Console;
using Xunit;

namespace Chownus.AoC.Tests
{
    public class Day8Tests
    {
        private readonly IAoCSolution _testObject;

        public Day8Tests()
        {
            var input = new List<string>
            {
                "b inc 5 if a > 1",
                "a inc 1 if b < 5",
                "c dec -10 if a >= 1",
                "c inc -20 if c == 10",
            };

            _testObject = new Day8Solution();
            _testObject.Initialize(input);
        }

        [Fact]
        public void Part1()
        {
            var solution = _testObject.RunPart1();
            Assert.Equal("1", solution);
        }

        [Fact]
        public void Part2()
        {
            var solution = _testObject.RunPart2();
            Assert.Equal("10", solution);
        }
    }
}