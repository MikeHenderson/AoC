using System.Collections.Generic;
using System.Linq;

namespace Chownus.AoC.Console.Common.Graphs
{
    public class UndirectedGraph<T>
    {
        public IList<Vertex<T>> Vertices { get; }
        public IList<WeightedEdge<T>> Edges { get; }

        public UndirectedGraph()
        {
            Edges = new List<WeightedEdge<T>>();
            Vertices = new List<Vertex<T>>();
        }

        public Vertex<T> GetVertex(T value)
        {
            return Vertices.FirstOrDefault(x => x.Value.Equals(value));
        }

        public Vertex<T> AddVertex(T value)
        {
            var v = new Vertex<T>(value);
            Vertices.Add(v);
            return v;
        }

        public void AddWeightedEdge(Vertex<T> v1, Vertex<T> v2, int cost)
        {
            var fwd = new WeightedEdge<T>{ From = v1, To = v2, Cost = cost };
            var back = new WeightedEdge<T>{ From = v2, To = v1, Cost = cost };
            v1.Neighbors.Add(fwd);
            v2.Neighbors.Add(back);

            Edges.Add(fwd);
            Edges.Add(back);
        }

        public IDictionary<T, IDictionary<T, int?>> ToAdjacencyMatrix()
        {
            // Build adjacency matrix w/ associative keys, 
            // root Dictionary = X axis, sub Dictionary = y axis w/ that value being the cost
            var rootList = Vertices.Select(x => x.Value).ToList();

            // initialize matrix
            var adjMatrix = rootList.ToDictionary<T, T, IDictionary<T, int?>>(v => v,
                v => rootList
                    .ToDictionary(x => x, x => (int?) null));

            // initialize diagonal values to "infinity"
            foreach (var key in adjMatrix.Keys)
                adjMatrix[key][key] = null;

            // loop through edges to populate matrix
            foreach (var e in Edges)
                adjMatrix[e.From.Value][e.To.Value] = e.Cost;

            return adjMatrix;
        }
    }
}