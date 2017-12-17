using System.Collections.Generic;
using System.Linq;
using Chownus.AoC.Console.Common.Helpers;

namespace Chownus.AoC.Console._2017._10
{
    public class Solution : IAoCSolution
    {
        public int Day => 10;
        public int Year => 2017;

        public string RunPart1(IEnumerable<string> testData)
        {
            var input = testData.First().Split(',').Select(int.Parse);
            var count = 0;
            var knotHash = GenerateSparseHashFromInput(GenerateHashList().First, input, ref count);
            return (knotHash.List.First.Value * knotHash.List.First.Next.Value).ToString();
        }

        public string RunPart2(IEnumerable<string> testData)
        {
            // Get sparse hash array
            var list = GenerateHashList();
            var inputList = GenerateAsciiInputList(testData.First());
            var head = list.First;
            var skipCount = 0;

            for (int i = 0; i < 64; i++)
                head = GenerateSparseHashFromInput(head, inputList, ref skipCount);

            // Generate dense hash from sparse hash
            var denseHash = new List<int>();

            for(int i = 0; i < 16; i++)
                denseHash.Add(list.Skip(i * 16).Take(16).Aggregate(0, (x, y) => x ^ y));

            return string.Join(string.Empty, denseHash.Select(x => x.ToString("X2")));
        }

        private LinkedList<int> GenerateHashList()
        {
            var list = new LinkedList<int>();

            var head = list.AddFirst(0);

            for (int i = 1; i < 256; i++)
                head = list.AddAfter(head, i);

            return list;
        }

        private IList<int> GenerateAsciiInputList(string input)
        {
            // Get original ascii codes and add appendix
            var asciiCodes = input.Select(x => (int) x).ToList();
            asciiCodes.AddRange(new[] {17, 31, 73, 47, 23});

            return asciiCodes;
        }

        private LinkedListNode<T> GenerateSparseHashFromInput<T>(LinkedListNode<T> current, IEnumerable<int> input, ref int skipCount)
        {
            foreach (var direction in input)
            {
                current = current.ReverseSection(direction);

                current = current.Skip(skipCount);

                skipCount++;
            }

            return current;
        }
    }
}