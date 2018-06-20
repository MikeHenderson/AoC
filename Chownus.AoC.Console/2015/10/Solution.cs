using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Chownus.AoC.Console._2015._10
{
    public class Solution : IAoCSolution
    {
        public int Day => 10;
        public int Year => 2015;

        public string RunPart1(IEnumerable<string> testData)
        {
            var s = testData.First();

            for (int i = 0; i < 40; i++)
                s = ProcessSequence(s);

            return s.Length.ToString();
        }

        public string RunPart2(IEnumerable<string> testData)
        {
            var s = testData.First();

            for (int i = 0; i < 50; i++)
                s = ProcessSequence(s);

            return s.Length.ToString();
        }

        private string ProcessSequence(string sequence)
        {
            var matches = Regex.Matches(sequence, @"([0-9])\1{0,}");

            var sb = new StringBuilder();

            foreach (Match m in matches)
            {
                sb.Append(m.Length)
                    .Append(m.Value[0]);
            }

            return sb.ToString();
        }
    }
}
