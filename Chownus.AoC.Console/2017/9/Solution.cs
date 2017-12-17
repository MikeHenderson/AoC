using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Chownus.AoC.Console._2017._9
{
    public class Solution : IAoCSolution
    {
        public int Day => 9;
        public int Year => 2017;
        
        public string RunPart1(IEnumerable<string> testData)
        {
            return testData.Sum(CalculateScore).ToString();
        }

        public string RunPart2(IEnumerable<string> testData)
        {
            //Remove characters we don't care about
            var removedSkipped = ClearSkippedCharacters(testData.First());

            //Find matches and count
            var garbage = "<.*?>";
            var matches = Regex.Matches(removedSkipped, garbage);

            var count = 0;

            foreach (var match in matches)
            {
                // Ignore trailing and leading < >
                count += match.ToString().Length - 2;
            }

            return count.ToString();
        }

        private static int CalculateScore(string input)
        {
            var cleaned = ClearGarbage(input);
            return CalculateTotalScore(cleaned);
        }

        private static int CalculateTotalScore(string input, int score = 0, int level = 1)
        {
            if (string.IsNullOrEmpty(input)) return score;

            return input[0] == '{'
                ? CalculateTotalScore(input.Substring(1, input.Length - 1), score + level, level + 1)
                : CalculateTotalScore(input.Substring(1, input.Length - 1), score, level - 1);
        }

        private static string ClearGarbage(string input)
        {
            var garbage = "<.*?>";
            var nonScoring = "[^{}]";

            var removedGarbage = Regex.Replace(ClearSkippedCharacters(input), garbage, string.Empty);
            var onlyScoring = Regex.Replace(removedGarbage, nonScoring, string.Empty);

            return onlyScoring;
        }

        private static string ClearSkippedCharacters(string input)
        {
            var skipCharacter = "!.";
            return Regex.Replace(input, skipCharacter, string.Empty);
        }
    }
}