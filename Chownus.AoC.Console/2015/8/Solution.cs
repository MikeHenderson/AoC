using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Chownus.AoC.Console._2015._8
{
    public class Solution : IAoCSolution
    {
        public int Day => 8;
        public int Year => 2015;

        public string RunPart1(IEnumerable<string> testData)
        {
            var memoryCount = testData.Sum(x => x.Length);
            var charCount = testData.Sum(x =>
                Regex.Unescape(x.Substring(1, x.Length - 2)
                    .Replace("\\\\", "!")
                    .Replace("\\\"", "!")).Length
            );

            return (memoryCount - charCount).ToString();
        }

        public string RunPart2(IEnumerable<string> testData)
        {
            var originalCount = testData.Sum(x => x.Length);
            var newCount = testData.Sum(x => x.Replace("\\", "\\\\").Replace("\"", "\\\"").Length + 2);

            return (newCount - originalCount).ToString();
        }
    }
}