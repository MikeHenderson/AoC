using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Chownus.AoC.Console._2015._2
{
    public class Solution : IAoCSolution
    {
        public int Day => 2;
        public int Year => 2015;
        private static Func<string, MatchCollection> getDigits = s => Regex.Matches(s, "\\d+");

        public string RunPart1(IEnumerable<string> testData)
        {
            var sum = 0;

            foreach (var dim in testData)
            {
                var numbers = getDigits(dim);
                // l w h
                var l = int.Parse(numbers[0].Value);
                var w = int.Parse(numbers[1].Value);
                var h = int.Parse(numbers[2].Value);

                int smallest;

                var lw = l * w;
                var wh = w * h;
                var hl = h * l;

                if (lw < wh) smallest = lw;
                else smallest = wh;

                if (hl < smallest) smallest = hl;

                sum += 2 * lw + 2 * wh + 2 * hl + smallest;
            }

            return sum.ToString();
        }

        public string RunPart2(IEnumerable<string> testData)
        {
            var sum = 0;

            foreach (var dim in testData)
            {
                var numbers = getDigits(dim);

                // l w h
                var dimensions = new List<int>
                {
                    int.Parse(numbers[0].Value),
                    int.Parse(numbers[1].Value),
                    int.Parse(numbers[2].Value)
                }.OrderBy(x => x);

                sum += dimensions.Aggregate((x, y) => x * y) + dimensions.Take(2).Sum(x => 2 * x);
            }

            return sum.ToString();
        }
    }
}
