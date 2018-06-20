using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace Chownus.AoC.Console._2015._11
{
    public class Solution : IAoCSolution
    {
        public int Day => 11;
        public int Year => 2015;

        private static IList<string> letterClusters = new List<string>();

        private static Func<char, bool> isIllegalLetter = x => x == 'i' || x == 'o' || x == 'l';
        private static Func<string, bool> containsAtLeastTwoPairs = x => Regex.Matches(x, @"([a-z])\1{1,}").Count >= 2;
        private static Func<string, bool> containsValidCluster = x => letterClusters.Any(x.Contains);

        private static IList<char> letters = new[]
        {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'j', 'k', 'm', 'n', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w',
            'x', 'y', 'z'
        };

        public Solution()
        {
            for (int i = 0; i < letters.Count - 2; i++)
                letterClusters.Add(string.Concat(letters[i], letters[i + 1], letters[i + 2]));
        }

        public string RunPart1(IEnumerable<string> testData)
        {
           return GetNextPassword(testData.First());

        }

        public string RunPart2(IEnumerable<string> testData)
        {
            var init = GetNextPassword(testData.First());

            return GetNextPassword(init);
        }

        private static string GetNextPassword(string p)
        {
            while (true)
            {
                p = IncrementPassword(p);

                if (containsAtLeastTwoPairs(p) && containsValidCluster(p))
                    break;
            }

            return p;
        }

        private static string IncrementPassword(string p)
        {
            return string.Concat(IncrementLetter(p.ToCharArray(), p.Length - 1));
        }

        private static char[] IncrementLetter(char[] p, int i)
        {
            if (i < 0) return p;

            if (p[i] != 'z')
            {
                var index = letters.IndexOf(p[i]) + 1;
                if (isIllegalLetter(letters[index])) index++;

                p[i] = letters[index];
                return p;
            }

            p[i] = 'a';

            return IncrementLetter(p, i - 1);
        }
    }
}