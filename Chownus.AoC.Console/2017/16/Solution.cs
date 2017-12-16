using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace Chownus.AoC.Console._2017._16
{
    public class Solution : IAoCSolution
    {
        public int Day => 16;

        private static Func<string, MatchCollection> getDigits = s => Regex.Matches(s, "\\d+");
        private readonly IList<char> alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        private readonly IDictionary<char, Func<string, string, string>> _actions = new Dictionary<char, Func<string, string, string>>
        {
            {'s', (c, p) =>
                {
                    var numbers = getDigits(c);
                    return Shift(int.Parse(numbers[0].Value), p);
                }
            },
            {'x', (c, p) =>
                {
                    var numbers = getDigits(c);
                    return Exchange(int.Parse(numbers[0].Value), int.Parse(numbers[1].Value), p);
                }
            },
            {'p', (c, p) => Partner(c[1], c[3], p) }
        };

        public string RunPart1(IEnumerable<string> testData)
        {
            var n = int.Parse(testData.First());
            var moves = testData.ToList()[1].Split(',');
            var programs = string.Join(string.Empty, alphabet.Take(n));

            return moves.Aggregate(programs, (current, move) => _actions[move[0]](move, current));
        }

        public string RunPart2(IEnumerable<string> testData)
        {
            var n = int.Parse(testData.First());
            var moves = testData.ToList()[1].Split(',');
            var programs = string.Join(string.Empty, alphabet.Take(n));
            var states = new Dictionary<string, string>();
            var nDances = 1000000000;

            for (int i = 0; i < nDances; i++)
            {
                // Begins repeat at this point
                if (states.ContainsKey(programs))
                    break;

                var original = programs;
                foreach (var move in moves)
                {
                    programs = _actions[move[0]](move, programs);
                }

                states.Add(original, programs);
            }

            // Find state which would have been the billionth state
            var index = nDances % states.Count;

            // Get the "billionth" result
            return states.ElementAt(index).Key;
        }

        private static string Exchange(int a, int b, string programs)
        {
            var arr = programs.ToCharArray();
            var temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;

            return string.Join(string.Empty, arr);
        }

        private static string Shift(int n, string programs)
        {
            if (n == 0) return programs;
            return programs.Substring(programs.Length - n) + programs.Substring(0, programs.Length - n);
        }

        private static string Partner(char a, char b, string programs)
        {
            var aIndex = programs.IndexOf(a);
            var bIndex = programs.IndexOf(b);

            return Exchange(aIndex, bIndex, programs);
        }
    }
}