using Chownus.AoC.Console;
using Xunit;

namespace Chownus.AoC.Tests
{
    public class Day9Tests
    {
        private readonly IAoCSolution _testObject;

        public Day9Tests()
        {
            _testObject = new Day9Solution();
        }

        [Theory]
        [InlineData("{}", 1)]
        [InlineData("{{{}}}", 6)]
        [InlineData("{{},{}}", 5)]
        [InlineData("{{{},{},{{}}}}", 16)]
        [InlineData("{<a>,<a>,<a>,<a>}", 1)]
        [InlineData("{{<ab>},{<ab>},{<ab>},{<ab>}}", 9)]
        [InlineData("{{<!!>},{<!!>},{<!!>},{<!!>}}", 9)]
        [InlineData("{{<a!>},{<a!>},{<a!>},{<ab>}}", 3)]
        public void Part1(string sequence, int expectedScore)
        {
            var input = new[] { sequence };
            _testObject.Initialize(input);

            var score = _testObject.RunPart1();

            Assert.Equal(expectedScore.ToString(), score);
        }

        [Fact]
        public void Part2()
        {
        }
    }
}