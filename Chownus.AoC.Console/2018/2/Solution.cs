using System;
using System.Collections.Generic;
using System.Linq;

namespace Chownus.AoC.Console._2018._2
{
    public class Solution : IAoCSolution
    {
        public int Day => 2;
        public int Year => 2018;

        private readonly Func<int, string, bool> AnyLetterAppears = (n, s) =>
        {
            var arr = s.ToCharArray().GroupBy(x => x).ToArray();

            return arr.Any(x => x.Count() == n);
        };

        public string RunPart1(IEnumerable<string> testData)
        {
            var twiceCheckCount = testData.Count(x => AnyLetterAppears(2, x));
            var thriceCheckCount = testData.Count(x => AnyLetterAppears(3, x));

            return (twiceCheckCount * thriceCheckCount).ToString();
        }

        public string RunPart2(IEnumerable<string> testData)
        {
            var data = testData.ToList();
            string match = null;
            int greatest = 0;

            for (int i = 0; i < data.Count; i++)
            {
                for (int j = i + 1; j < data.Count; j++)
                {
                    var c = data[i].Where((x, ix) => x == data[j][ix]);

                    if (c.Count() > greatest)
                    {
                        match = new string(c.ToArray());
                        greatest = c.Count();
                    }
                }
            }

            return match;
        }
    }
}
