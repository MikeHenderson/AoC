using Chownus.AoC.Console;
using Chownus.AoC.Console._2017._9;
using Xunit;

namespace Chownus.AoC.Tests._2017._9
{
    public class Day9Tests
    {
        private readonly IAoCSolution _testObject;

        public Day9Tests()
        {
            _testObject = new Solution();
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
            var score = _testObject.RunPart1(new[] { sequence });

            Assert.Equal(expectedScore.ToString(), score);
        }

        [Theory]
        [InlineData("<>", 0)]
        [InlineData("<random characters>", 17)]
        [InlineData("<<<<>", 3)]
        [InlineData("<{!>}>", 2)]
        [InlineData("<!!>", 0)]
        [InlineData("<!!!>>", 0)]
        [InlineData("<{o\"i!a,<{i<a>", 10)]
        public void Part2(string sequence, int expectedCount)
        {
            var score = _testObject.RunPart2(new[] { sequence });

            Assert.Equal(expectedCount.ToString(), score);
        }
    }
}