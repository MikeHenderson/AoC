using System.Collections.Generic;
using System.Linq;

namespace Chownus.AoC.Console._2017._10
{
    public class Solution : IAoCSolution
    {
        public int Day => 10;

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
                current = ReverseSection(current, direction);

                current = Skip(current, skipCount);

                skipCount++;
            }

            return current;
        }

        private LinkedListNode<T> ReverseSection<T>(LinkedListNode<T> current, int direction)
        {
            var subset = new T[direction];

            for (int i = 0; i < direction; i++)
            {
                subset[i] = current.Value;

                if (i < direction - 1)
                    current = GetNextOrFirst(current);
            }

            for (int i = 0; i < direction; i++)
            {
                current.Value = subset[i];

                if (i < direction - 1)
                    current = GetPreviousOrLast(current);
            }

            // Skip ahead forward to the next one
            return Skip(current, direction);
        }

        // Create the behavior of a circularly linked list
        private LinkedListNode<T> GetNextOrFirst<T>(LinkedListNode<T> current)
        {
            return current.Next ?? current.List.First;
        }

        private LinkedListNode<T> GetPreviousOrLast<T>(LinkedListNode<T> current)
        {
            return current.Previous ?? current.List.Last;
        }

        private LinkedListNode<T> Skip<T>(LinkedListNode<T> current, int count)
        {
            if (count == 0) return current;

            while (count > 0)
            {
                current = GetNextOrFirst(current);
                count--;
            }

            return current;
        }
    }
}