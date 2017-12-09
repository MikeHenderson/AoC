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
            return "";
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
            var skipCharacter = "!.";
            var garbage = "<.*?>";
            var nonScoring = "[^{}]";

            var removedSkip = Regex.Replace(input, skipCharacter, string.Empty);
            var removedGarbage = Regex.Replace(removedSkip, garbage, string.Empty);
            var onlyScoring = Regex.Replace(removedGarbage, nonScoring, string.Empty);

            return onlyScoring;
        }

        public void Initialize(IEnumerable<string> input)
        {
            _input = input;
        }

        private IEnumerable<string> _input;

       
    }
}