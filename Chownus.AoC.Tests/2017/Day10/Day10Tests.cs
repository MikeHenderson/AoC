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
            _testObject.Initialize(new [] { "3,4,1,5" });
        }

        [Fact]
        public void Part1()
        {
            var solution = _testObject.RunPart1();
            Assert.Equal("12", solution);
        }

        [Fact] 
        public void Part2()
        {

        }
    }
}