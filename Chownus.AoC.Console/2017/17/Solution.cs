using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Chownus.AoC.Console.Common.Helpers;

namespace Chownus.AoC.Console._2017._17
{
    public class Solution : IAoCSolution
    {
        public int Day => 17;
        public string RunPart1(IEnumerable<string> testData)
        {
            var skip = int.Parse(testData.First());
            var list = new List<int> { 0 };
            var current = 0;

            for (int i = 1; i < 2018; i++)
            {
                current = (current + skip) % list.Count;
                list.Insert(current + 1, i);
                current = (current + 1) % list.Count;
            }

            return list[current + 1].ToString();
        }

        public string RunPart2(IEnumerable<string> testData)
        {
            return string.Empty;
        }
    }
}