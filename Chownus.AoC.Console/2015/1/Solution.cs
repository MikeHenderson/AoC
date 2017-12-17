using System.Collections.Generic;
using System.Linq;

namespace Chownus.AoC.Console._2015._1
{
    public class Solution : IAoCSolution
    {
        public int Day => 1;
        public int Year => 2015;

        public string RunPart1(IEnumerable<string> testData)
        {
            var line = testData.First();
            var counter = 0;

            foreach (var c in line)
            {
                if (c == '(') counter++;
                else counter--;
            }

            return counter.ToString();
        }

        public string RunPart2(IEnumerable<string> testData)
        {
            var line = testData.First();
            var counter = 0;
            int basementPosition = 0;

            foreach (var c in line)
            {
                if (c == '(') counter++;
                else counter--;

                basementPosition++;

                if (counter == -1)
                    break;
            }

            return basementPosition.ToString();
        }
    }
}
