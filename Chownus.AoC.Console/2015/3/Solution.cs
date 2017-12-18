using System;
using System.Collections.Generic;
using System.Linq;

namespace Chownus.AoC.Console._2015._3
{
    public class Solution : IAoCSolution
    {
        public int Day => 3;
        public int Year => 2015;

        //TODO: Clean this up
        private IDictionary<char, int[]> actions = new Dictionary<char, int[]>
        {
            {'<', new[] {-1, 0}},
            {'^', new[] {0, 1}},
            {'>', new[] {1, 0}},
            {'v', new[] {0, -1}}
        };

        public string RunPart1(IEnumerable<string> testData)
        {
            var input = testData.First();

            var current = new[] {0, 0};
            var visited = new List<int[]> { current };

            foreach (var move in input)
            {
                current = current.Zip(actions[move], (a, b) => a + b).ToArray();

                if(!visited.Any(x => x[0] == current[0] && x[1] == current[1]))
                    visited.Add(current);
            }

            return visited.Count.ToString();
        }

        public string RunPart2(IEnumerable<string> testData)
        {
            var input = testData.First();
            var santa = GetPath(input.Where((x, i) => i % 2 == 0));
            var robo = GetPath(input.Where((x, i) => i % 2 == 1));
            var unique = santa;

            foreach (var visit in robo)
            {
                if (!unique.Any(x => x[0] == visit[0] && x[1] == visit[1]))
                    unique.Add(visit);
            }

            return unique.Count.ToString();
        }

        private List<int[]> GetPath(IEnumerable<char> moves)
        {
            var current = new[] { 0, 0 };
            var visited = new List<int[]> { current };

            foreach (var move in moves)
            {
                current = current.Zip(actions[move], (a, b) => a + b).ToArray();

                if (!visited.Any(x => x[0] == current[0] && x[1] == current[1]))
                    visited.Add(current);
            }

            return visited;
        }
    }
}
