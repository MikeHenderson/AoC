using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Chownus.AoC.Console
{
    public class Day6Solution : IAoCSolution
    {
        public int Day => 6;

        public string RunPart1(IEnumerable<string> testData)
        {
            var input = Regex.Replace(testData.First(), @"\t|\n|\r", " ").Split(' ').Select(int.Parse).ToArray();
            var counter = 0;
            var dupeFound = false;

            var redist = (int[]) input.Clone();
            var visited = new List<int[]>{ redist }; //seed original

            while (!dupeFound)
            {
                redist = Redistribute(redist);

                if (HasBeenVisited(visited, redist))
                    dupeFound = true;
                else 
                    visited.Add(redist);

                counter++;
            } 

            return counter.ToString();
        }

        public string RunPart2(IEnumerable<string> testData)
        {
            var input = Regex.Replace(testData.First(), @"\t|\n|\r", " ").Split(' ').Select(int.Parse).ToArray();
            var matchFound = false;

            var redist = (int[]) input.Clone();
            var visited = new List<string>{ string.Join(string.Empty, redist) }; // seed original

            while (!matchFound)
            {
                redist = Redistribute(redist);

                visited.Add(string.Join(string.Empty, redist));

                var steps = FindSpacesBetweenVisited(visited);

                if (steps > 0)
                    return steps.ToString();
            }


            return "Answer not found";
        }

        private int[] Redistribute(int[] list)
        {
            var result = (int[]) list.Clone();
            int index = result.ToList().IndexOf(list.Max(x => x));

            var n = result[index];
            result[index] = 0;

            while (n > 0)
            {
                index++;

                if (index >= result.Length)
                    index = 0;

                result[index]++;

                n--;
            }

            return result;
        }

        private bool HasBeenVisited(IList<int[]> states, IList<int> check)
        {
            foreach (var state in states)
            {
                if (state.SequenceEqual(check))
                    return true;
            }

            return false;
        }

        private int FindSpacesBetweenVisited(IList<string> states)
        {
            var groups = states.Select((x, i) => new {Index = i, Data = x})
                .GroupBy(g => g.Data)
                .Where(g => g.Count() == 2)
                .ToList();

            // Should only be 2 here
            if (groups.Any())
            {
                var g = groups.First().ToList();

                return g[1].Index - g[0].Index;
            }

            return 0;
        }
    }
}
