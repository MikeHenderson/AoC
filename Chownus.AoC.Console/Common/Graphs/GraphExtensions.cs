using System.Collections.Generic;
using System.Linq;

namespace Chownus.AoC.Console.Common.Graphs
{
    public static class GraphExtensions
    {
        public static IEnumerable<IEnumerable<T>> GetPermutations<T>(this Vertex<T> root, ICollection<Vertex<T>> path)
        {
            path.Add(root);

            if (root.Neighbors.All(x => path.Contains(x.To)))
                yield return path.Select(x => x.Value);

            foreach (var n in root.Neighbors.Where(x => !path.Contains(x.To)))
            {
                // Potential here to cause problems with large data sets
                var pa = new List<Vertex<T>>(path);

                foreach (var p in n.To.GetPermutations(pa))
                    yield return p;
            }
        }
    }
}