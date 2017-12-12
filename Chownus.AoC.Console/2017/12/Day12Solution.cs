using System;
using System.Collections.Generic;
using System.Linq;

namespace Chownus.AoC.Console
{
    public class Day12Solution : IAoCSolution
    {
        private IEnumerable<string> _input;

        public int Day => 12;
        public string RunPart1(IEnumerable<string> testData)
        {
            var input = new Dictionary<int, IList<int>>();
            var visited = new List<int>();

            foreach (var line in testData)
            {
                var parts = line.Split(new[] {"<->"}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToList();

                input.Add(int.Parse(parts[0]), parts[1].Split(',').Select(int.Parse).ToList());
            }

            var count = 0;

            // LOL this is bad.....
            for (int i = 0; i < 100; i++)
            {
                foreach (var kvp in input)
                {
                    var visitedKey = CanTalkWithRoot(kvp, input, visited);

                    if (visitedKey != null)
                    {
                        if (!visited.Contains(kvp.Key))
                            visited.Add(kvp.Key);

                        foreach (var val in kvp.Value)
                        {
                            if (!visited.Contains(val))
                                visited.Add(val);
                        }

                    }
                }
            }

            return visited.Count.ToString();
        }

        public string RunPart2(IEnumerable<string> testData)
        {
            return "";
        }

        private int? CanTalkWithRoot(KeyValuePair<int, IList<int>> kvp, IDictionary<int, IList<int>> lookup, IEnumerable<int> visited)
        {
            if (kvp.Key == 0) return kvp.Key;

            if (kvp.Value.Intersect(visited).Any()) return kvp.Key;

            if (lookup[0].Contains(kvp.Key)) return kvp.Key;

            if (lookup[kvp.Key].Contains(0)) return kvp.Key;

            return null;
        }
    }
}