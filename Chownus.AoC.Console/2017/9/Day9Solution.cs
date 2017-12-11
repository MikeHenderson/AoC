using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace Chownus.AoC.Console
{
    public class Day9Solution : IAoCSolution
    {
        public int Day => 9;
        public string RunPart1()
        {
            return _input.Sum(CalculateScore).ToString();
        }

        public string RunPart2()
        {
            //Remove characters we don't care about
            var removedSkipped = ClearSkippedCharacters(_input.First());

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

        public void Initialize(IEnumerable<string> input)
        {
            _input = input;
        }

        private IEnumerable<string> _input;

       
    }
}