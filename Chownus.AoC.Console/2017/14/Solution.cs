using System;
using System.Collections.Generic;
using System.Linq;
using Chownus.AoC.Console.Common.Helpers;

namespace Chownus.AoC.Console._2017._14
{
    public class Solution : IAoCSolution
    {
        public int Day => 14;
        public int Year => 2017;

        public string RunPart1(IEnumerable<string> testData)
        {
            var hashKey = testData.First();
            var total = 0;
            for (int i = 0; i < 128; i++)
            {
                var hashString = GetKnotHash($"{hashKey}-{i}");

                foreach (var c in hashString)
                {
                    var binary = Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0');
                    total += binary.Count(x => x.Equals('1'));
                }
            }

            return total.ToString();

        }

        public string RunPart2(IEnumerable<string> testData)
        {
            var hashKey = testData.First();
            var total = 0;
            var grid = new int[128, 128];

            // Fill grid
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                var hashString = GetKnotHash($"{hashKey}-{i}");
                var binaryString = string.Join(string.Empty,
                    hashString.Select(c =>
                        Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2)
                            .PadLeft(4, '0')));

                for (int j = 0; j < 128; j++)
                {
                    grid[i, j] = binaryString[j] == '1' ? 1 : 0;
                }
            }

            // Find regions
            var visited = new bool[128, 128];

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i,j] == 1 && !visited[i,j])
                    {
                        DiscoverIsland(grid, i, j, visited);
                        total++;
                    }
                }
            }

            return total.ToString();
        }

        private void DiscoverIsland(int[,] grid, int x, int y, bool[,] visited)
        {
            if (x < 0 || x >= grid.GetLength(0) || y < 0 || y >= grid.GetLength(1) || grid[x, y] == 0 || visited[x, y])
                return;

            // Mark off that we visited location
            visited[x, y] = true;

            // Neighbors
            int[] nx = { 0, 1, 0, -1 };
            int[] ny = { 1, 0, -1, 0 };

            // Search neighbors for island
            for (int i = 0; i < 4; i++)
            {
                var dx = x + nx[i];
                var dy = y + ny[i];

                DiscoverIsland(grid, dx, dy, visited);
            }
        }

        private string GetKnotHash(string input)
        {
            var list = GenerateHashList();
            var inputList = GenerateAsciiInputList(input);
            var head = list.First;
            var skipCount = 0;

            for (int i = 0; i < 64; i++)
                head = GenerateSparseHashFromInput(head, inputList, ref skipCount);

            // Generate dense hash from sparse hash
            var denseHash = new List<int>();

            for (int i = 0; i < 16; i++)
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
            var asciiCodes = input.Select(x => (int)x).ToList();
            asciiCodes.AddRange(new[] { 17, 31, 73, 47, 23 });

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