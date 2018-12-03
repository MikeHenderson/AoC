using System.Collections.Generic;
using System.Linq;

namespace Chownus.AoC.Console._2018._1
{
    public class Solution : IAoCSolution
    {
        public int Day => 1;
        public int Year => 2018;

        public string RunPart1(IEnumerable<string> testData)
        {
            return testData.Sum(int.Parse).ToString();
        }

        public string RunPart2(IEnumerable<string> testData)
        {
            int frequency = 0;
            var freqChart = new List<int> {frequency};
            var data = testData.Select(int.Parse).ToList();

            bool dupeFound = false;
            int i = 0;

            while (!dupeFound)
            {
                frequency += data[i];

                if (freqChart.Contains(frequency))
                    dupeFound = true;
                else
                {
                    if (i == data.Count - 1)
                        i = 0;
                    else
                        i++;

                    freqChart.Add(frequency);
                }
            }

            return frequency.ToString();
        }
    }
}
