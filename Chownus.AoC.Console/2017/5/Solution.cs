using System.Collections.Generic;
using System.Linq;

namespace Chownus.AoC.Console._2017._5
{
    public class Solution : IAoCSolution
    {
        public int Day => 5;

        public string RunPart1(IEnumerable<string> testData)
        {
            var input = testData.Select(int.Parse).ToList();
            var stepCount = 0;
            var index = 0;

            while (index >= 0 && index < input.Count)
            {
                //Get instruction
                var instruction = input[index];

                //Increment instruction
                input[index]++;

                //Do hop
                index += instruction;

                //Increment counter
                stepCount++;
            }

            return stepCount.ToString();
        }

        public string RunPart2(IEnumerable<string> testData)
        {
            var input = testData.Select(int.Parse).ToList();
            var index = 0;
            var stepCount = 0;

            while (index >= 0 && index < input.Count)
            {
                //Get instruction
                var instruction = input[index];

                //Do hop
                index += instruction;

                //Increment/Decrement instruction
                if (instruction >= 3)
                    input[index - instruction]--;
                else
                    input[index - instruction]++;

                stepCount++;
            }

            return stepCount.ToString();
        }
    }
}
