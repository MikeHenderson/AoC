using System;
using System.Collections.Generic;
using System.Linq;

namespace Chownus.AoC.Console._2017._12
{
    public class Solution : IAoCSolution
    {
        public int Year => 2017;

        public int Day => 12;
        public string RunPart1(IEnumerable<string> testData)
        {
            var input = BuildGraph(testData);
            var visited = new List<int>();
           
            DoSearch(0, input, visited);

            return visited.Count.ToString();
        }

        public string RunPart2(IEnumerable<string> testData)
        {
            var input = BuildGraph(testData);
            var visited = new List<int>();
            var groupCounter = 0;

            foreach (var key in input.Keys)
            {
                if (visited.Contains(key)) continue;

                groupCounter++;
                DoSearch(key, input, visited);
            }

            return groupCounter.ToString();
        }

        private void DoSearch(int key, IDictionary<int, IList<int>> graph, IList<int> visited)
        {
            if (visited.Contains(key)) return;

            visited.Add(key);

            foreach (var child in graph[key])
                DoSearch(child, graph, visited);
        }


        private IDictionary<int, IList<int>> BuildGraph(IEnumerable<string> testData)
        {
            var graph = new Dictionary<int, IList<int>>();
            foreach (var line in testData)
            {
                var parts = line.Split(new[] { "<->" }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToList();

                graph.Add(int.Parse(parts[0]), parts[1].Split(',').Select(int.Parse).ToList());
            }

            return graph;
        }
    }
}