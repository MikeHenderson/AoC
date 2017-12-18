using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Chownus.AoC.Console._2015._5
{
    public class Solution : IAoCSolution
    {
        public int Day => 5;
        public int Year => 2015;

        public string RunPart1(IEnumerable<string> testData)
        {
            var checkVowels = new Func<string, bool>(x => Regex.IsMatch(x, "[aeiou].*[aeiou].*[aeiou]"));
            var checkLetters = new Func<string, bool>(x => Regex.IsMatch(x, @"(\w)\1+"));
            var checkClusters = new Func<string, bool>(x => !Regex.IsMatch(x, "ab|cd|pq|xy"));

            return testData.Count(x => checkClusters(x) && checkVowels(x) && checkLetters(x)).ToString();
        }

        public string RunPart2(IEnumerable<string> testData)
        {
            var checkLetters = new Func<string, bool>(x => Regex.IsMatch(x, @"(\w{2}).*\1+"));
            var checkInBetween = new Func<string, bool>(x => Regex.IsMatch(x, @"(\w).\1"));

            return testData.Count(x => checkInBetween(x) && checkLetters(x)).ToString();
        }
    }
}
