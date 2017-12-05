using System.Collections.Generic;
using System.Linq;

namespace Chownus.AoC.Console._2017.Day5
{
    public class Day5Solution : IAoCSolution
    {
        private IList<int> _input;
        public int Day => 5;

        public void Initialize(IEnumerable<string> input)
        {
            _input = input.Select(int.Parse).ToList();
        }

        public string RunPart1()
        {
            var stepCount = 0;
            var index = 0;

            while (index < _input.Count)
            {
                //Get instruction
                var instruction = _input[index];

                //Increment instruction
                _input[index]++;

                //Do hop
                index += instruction;

                //Increment counter
                stepCount++;
            }

            return stepCount.ToString();
        }

        public string RunPart2()
        {
            var index = 0;
            var stepCount = 0;

            while (index >= 0 && index < _input.Count)
            {
                //Get instruction
                var instruction = _input[index];

                //Do hop
                index += instruction;

                //Increment/Decrement instruction
                if (instruction >= 3)
                    _input[index - instruction]--;
                else
                    _input[index - instruction]++;

                stepCount++;
            }

            return stepCount.ToString();
        }
    }
}
