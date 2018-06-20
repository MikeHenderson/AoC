using System.Collections.Generic;
using System.Linq;

namespace Chownus.AoC.Console.Common.Graphs
{
    // TODO: move weighted edge to WeightedGraph child
    public abstract class Graph<T>
    {
        public IList<Vertex<T>> Vertices { get; }
        public IList<WeightedEdge<T>> Edges { get; }

        protected Graph()
        {
            Edges = new List<WeightedEdge<T>>();
            Vertices = new List<Vertex<T>>();
        }

        public WeightedEdge<T> GetEdge(T from, T to)
        {
            return Edges.FirstOrDefault(x => x.From.Value.Equals(from) && x.To.Value.Equals(to));
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

        public IDictionary<T, IDictionary<T, int?>> ToAdjacencyMatrix()
        {
            // Build adjacency matrix w/ associative keys, 
            // root Dictionary = X axis, sub Dictionary = y axis w/ that value being the cost
            var rootList = Vertices.Select(x => x.Value).ToList();

            // initialize matrix
            var adjMatrix = rootList.ToDictionary<T, T, IDictionary<T, int?>>(v => v,
                v => rootList
                    .ToDictionary(x => x, x => (int?)null));

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