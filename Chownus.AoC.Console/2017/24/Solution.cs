using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Chownus.AoC.Console.Common.Helpers;

namespace Chownus.AoC.Console._2017._24
{
    public class Solution : IAoCSolution
    {
        public int Day => 24;
        public int Year => 2017;

        public string RunPart1(IEnumerable<string> testData)
        {
            var input = testData.Select(line => line.GetDigits())
                .Select(numbers => new BridgePiece(int.Parse(numbers[0].Value), int.Parse(numbers[1].Value)))
                .ToImmutableList();

            return FindMaxStrength(input).ToString();


        }

        private int FindMaxStrength(IImmutableList<BridgePiece> ports, int current = 0, int strength = 0)
        {
            return ports.Where(x => x.Left == current || x.Right == current)
                .Select(x => FindMaxStrength(ports.Remove(x), x.Left == current ? x.Right : x.Left,
                    strength + x.GetStrength()))
                .Concat(Enumerable.Repeat(strength, 1))
                .Max();
        }

        public string RunPart2(IEnumerable<string> testData)
        {
            var input = testData.Select(line => line.GetDigits())
                .Select(numbers => new BridgePiece(int.Parse(numbers[0].Value), int.Parse(numbers[1].Value)))
                .ToImmutableList();

            return FindMaxStrengthOfLongest(input).Item1.ToString();


        }

        private (int, int) FindMaxStrengthOfLongest(IImmutableList<BridgePiece> ports, int current = 0, int strength = 0, int length = 0)
        {
            return ports.Where(x => x.Left == current || x.Right == current)
                .Select(x => FindMaxStrengthOfLongest(ports.Remove(x), x.Left == current ? x.Right : x.Left,
                    strength + x.GetStrength(), length + 1))
                .Concat(Enumerable.Repeat((strength, length), 1))
                .OrderByDescending(x => x.Item2)
                .ThenByDescending(x => x.Item1)
                .First();
        }

        public class BridgePiece
        {
            public BridgePiece(int left, int right)
            {
                Left = left;
                Right = right;
            }

            public int Left;
            public int Right;

            public int GetStrength()
            {
                return Left + Right;
            }
        }
    }
}