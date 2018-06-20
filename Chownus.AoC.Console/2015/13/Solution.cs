using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Chownus.AoC.Console.Common.Graphs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Chownus.AoC.Console._2015._13
{
    public class Solution : IAoCSolution
    {
        public int Day => 13;
        public int Year => 2015;

        public string RunPart1(IEnumerable<string> testData)
        {
            var graph = GenerateGraph(testData);

            return GetMaxHappinessChange(graph);
        }

        public string RunPart2(IEnumerable<string> testData)
        {
            var graph = GenerateGraph(testData);
            var me = graph.AddVertex("Me");

            foreach (var v in graph.Vertices)
            {
                graph.AddEdge(v, me, 0);
                graph.AddEdge(me, v, 0);
            }

            return GetMaxHappinessChange(graph);
        }

        private static string GetMaxHappinessChange(DirectedWeightedGraph<string> graph)
        {
            var p = graph.Vertices[0].GetPermutations(new List<Vertex<string>>()).ToList();
            var adjMatrix = graph.ToAdjacencyMatrix();

            return p.Max(x =>
                {
                    var total = 0;
                    var path = x.ToList();

                    for (int i = 0; i < path.Count; i++)
                    {
                        var i2 = i == path.Count - 1 ? 0 : i + 1;

                        total += adjMatrix[path[i]][path[i2]].Value
                                 + adjMatrix[path[i2]][path[i]].Value;
                    }

                    return total;
                })
                .ToString();
        }

        private static DirectedWeightedGraph<string> GenerateGraph(IEnumerable<string> testData)
        {
            var graph = new DirectedWeightedGraph<string>();

            // Build the thing - complete directed weighted graph
            foreach (var line in testData)
            {
                //Alice would gain 2 happiness units by sitting next to Bob.
                var parts = line.Split(' ');
                var n1 = parts[0];
                var n2 = parts.Last().Substring(0, parts.Last().Length - 1);

                var v1 = graph.GetVertex(n1);
                var v2 = graph.GetVertex(n2);

                if (v1 == null)
                    v1 = graph.AddVertex(n1);

                if (v2 == null)
                    v2 = graph.AddVertex(n2);

                //Happiness cost
                var hCost = int.Parse(parts[3]);

                if (parts[2].Equals("lose")) hCost *= -1;

                graph.AddEdge(v1, v2, hCost);
            }

            return graph;
        }


    }
}