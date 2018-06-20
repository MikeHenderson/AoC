using System.Collections.Generic;
using Chownus.AoC.Console.Common.Graphs;

namespace Chownus.AoC.Console._2015._9
{
    public class Solution : IAoCSolution
    {
        public int Day => 9;
        public int Year => 2015;

        public string RunPart1(IEnumerable<string> testData)
        {
            var graph = new UndirectedGraph<string>();

            // Populate graph
            foreach (var line in testData)
            {
                var parts = line.Split(' ');
                var from = parts[0];
                var to = parts[2];
                var cost = int.Parse(parts[4]);

                var fromV = graph.GetVertex(from) ?? graph.AddVertex(from);
                var toV = graph.GetVertex(to) ?? graph.AddVertex(to);

                graph.AddWeightedEdge(fromV, toV, cost);
            }

            return graph.CalculateShortestPath().ToString();
        }

        public string RunPart2(IEnumerable<string> testData)
        {
            var graph = new UndirectedGraph<string>();

            // Populate graph
            foreach (var line in testData)
            {
                var parts = line.Split(' ');
                var from = parts[0];
                var to = parts[2];
                var cost = int.Parse(parts[4]);

                var fromV = graph.GetVertex(from) ?? graph.AddVertex(from);
                var toV = graph.GetVertex(to) ?? graph.AddVertex(to);

                graph.AddWeightedEdge(fromV, toV, cost);
            }

            return graph.CalculateLongestPath().ToString();
        }
    }
}