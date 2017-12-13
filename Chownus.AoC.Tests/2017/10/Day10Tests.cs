using Chownus.AoC.Console;
using Chownus.AoC.Console._2017._10;
using Xunit;

namespace Chownus.AoC.Tests._2017._10
{
    public class Day10Tests
    {
        private readonly IAoCSolution _testObject;

        public Day10Tests()
        {
            _testObject = new Solution();
        }

        [Fact]
        public void Part1()
        {
            var solution = _testObject.RunPart1(new[] { "3,4,1,5" });
            Assert.Equal("12", solution);
        }

        [Fact] 
        public void Part2()
        {
            var solution = _testObject.RunPart2(new[] { "1,2,3" });
            Assert.Equal("3efbe78a8d82f29979031a4aa0b16a9d", solution.ToLower());
        }
    }
}