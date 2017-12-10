using Chownus.AoC.Console;
using Xunit;

namespace Chownus.AoC.Tests
{
    public class Day10Tests
    {
        private readonly IAoCSolution _testObject;

        public Day10Tests()
        {
            _testObject = new Day10Solution();
        }

        [Fact]
        public void Part1()
        {
            _testObject.Initialize(new[] { "3,4,1,5" });
            var solution = _testObject.RunPart1();
            Assert.Equal("12", solution);
        }

        [Fact] 
        public void Part2()
        {
            _testObject.Initialize(new[] { "1,2,3" });
            var solution = _testObject.RunPart2();
            Assert.Equal("3efbe78a8d82f29979031a4aa0b16a9d", solution.ToLower());
        }
    }
}