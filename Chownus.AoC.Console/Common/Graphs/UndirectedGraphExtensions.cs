using System.Collections.Generic;
using System.Linq;

namespace Chownus.AoC.Console.Common.Graphs
{
    public static class UndirectedGraphExtensions
    {
        public static int CalculateLongestPath<T>(this UndirectedWeightedGraph<T> weightedGraph)
        {
            var permutations = weightedGraph.Vertices.SelectMany(x => x.GetPermutations(new List<Vertex<T>>()));
            var adjMatrix = weightedGraph.ToAdjacencyMatrix();

            return permutations.Max(x =>
            {
                var cost = 0;
                var p = x.ToList();

                for (int i = 0; i < p.Count - 1; i++)
                {
                    var from = p[i];
                    var to = p[i + 1];

                    cost += adjMatrix[from][to].Value;
                }

                return cost;
            });
        }

        public static int CalculateShortestPath<T>(this UndirectedWeightedGraph<T> weightedGraph)
        {
            var permutations = weightedGraph.Vertices.SelectMany(x => x.GetPermutations(new List<Vertex<T>>()));
            var adjMatrix = weightedGraph.ToAdjacencyMatrix();

            return permutations.Min(x =>
            {
                var cost = 0;
                var p = x.ToList();

                for (int i = 0; i < p.Count - 1; i++)
                {
                    var from = p[i];
                    var to = p[i + 1];

                    cost += adjMatrix[from][to].Value;
                }

                return cost;
            });
        }
    }
}