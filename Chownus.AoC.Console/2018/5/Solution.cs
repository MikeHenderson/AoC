using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Chownus.AoC.Console._2018._5
{
    public class Solution : IAoCSolution
    {
        public int Day => 5;
        public int Year => 2018;

        private Func<string, int> ReducePolymer => polymer =>
        {
            var result = new Stack<char>();
            var p = polymer.ToList();

            // Why isn't this recursive you ask? Two words - stack overflow!
            for (int i = 0; i < p.Count; i++)
                result = Reduce(p, result, ref i);

            return result.Count;
        };

        public string RunPart1(IEnumerable<string> testData)
        {
            return ReducePolymer(testData.First()).ToString();
        }

        public string RunPart2(IEnumerable<string> testData)
        {
            var alpha = "abcdefghijklmnopqrstuvwxyz";

            return alpha.ToCharArray().Min(x =>
            {
                var l = char.ToLower(x);
                var u = char.ToUpper(x);

                var n = Regex.Replace(testData.First(), $"{l}|{u}", string.Empty);

                return ReducePolymer(n);
            }).ToString();
        }

        private bool AreOppositePolarity(char a, char b)
        {
            return a != b && char.ToLower(a) == char.ToLower(b);
        }

        private Stack<char> Reduce(IList<char> e, Stack<char> result, ref int i)
        {
            if (i > e.Count - 1) return result;

            if (i == e.Count - 1)
            {
                result.Push(e[i]);
                return result;
            }

            char curr = e[i];

            // Same polarity found, add to result and move on
            if (!AreOppositePolarity(curr, e[i+1]))
            {
                result.Push(curr);
                return result;
            }

            if (result.Count == 0)
            {
                i++;
                return result;
            }

            i++;

            // Opposite polarity found, start backtracking
            // Keep moving out until no more opposite polarity found
            while (i < e.Count - 1 && result.TryPeek(out char temp) && AreOppositePolarity(e[i+1], temp))
            {
                result.Pop();
                i++;
            }

            return result;
        }
    }

    public static class StackExtensions
    {
        public static bool TryPeek<T>(this Stack<T> stack, out T result) 
        {
            if (stack == null || stack.Count == 0)
            {
                result = default(T);
                return false;
            }

            result = stack.Peek();
            return true;
        }
    }
}