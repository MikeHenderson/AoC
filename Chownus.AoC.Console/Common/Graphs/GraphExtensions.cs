using System.Collections.Generic;
using System.Linq;

namespace Chownus.AoC.Console.Common.Graphs
{
    public static class GraphExtensions
    {
        public static int CalculateLongestPath<T>(this UndirectedGraph<T> graph)
        {
            var permutations = graph.Vertices.SelectMany(x => GetPermutations(x, new List<Vertex<T>>()));
            var adjMatrix = graph.ToAdjacencyMatrix();

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

        public static int CalculateShortestPath<T>(this UndirectedGraph<T> graph)
        {
            var permutations = graph.Vertices.SelectMany(x => x.GetPermutations(new List<Vertex<T>>()));
            var adjMatrix = graph.ToAdjacencyMatrix();

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

        private static IEnumerable<IEnumerable<T>> GetPermutations<T>(this Vertex<T> root, ICollection<Vertex<T>> path)
        {
            path.Add(root);

            if (root.Neighbors.All(x => path.Contains(x.To)))
                yield return path.Select(x => x.Value);

            foreach (var n in root.Neighbors.Where(x => !path.Contains(x.To)))
            {
                var pa = new List<Vertex<T>>(path);

                foreach (var p in n.To.GetPermutations(pa))
                    yield return p;
            }
        }
    }
}