using Chownus.AoC.Console;
using Xunit;

namespace Chownus.AoC.Tests
{
    public class Day11Tests
    {
        private readonly IAoCSolution _testObject;

        public Day11Tests()
        {
            _testObject = new Day11Solution();
        }

        [Theory]
        [InlineData("ne,ne,ne", 3)]
        [InlineData("ne,ne,sw,sw", 0)]
        [InlineData("ne,ne,s,s", 2)]
        [InlineData("se,sw,se,sw,sw", 3)]
        public void Part1(string input, int expected)
        {
            var solution = _testObject.RunPart1(new[] { input });

            Assert.Equal(expected.ToString(), solution);
        }

        [Theory]
        [InlineData("ne,ne,ne", 3)]
        [InlineData("ne,ne,sw,sw", 2)]
        [InlineData("ne,ne,s,s", 2)]
        [InlineData("se,sw,se,sw,sw", 3)]
        public void Part2(string input, int expected)
        {
            var solution = _testObject.RunPart2(new[] { input });

            Assert.Equal(expected.ToString(), solution);
        }
    }
}