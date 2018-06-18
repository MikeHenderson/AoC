using System.Collections.Generic;

namespace Chownus.AoC.Console.Common.Graphs
{
    public class Vertex<T>
    {
        public Vertex(T value)
        {
            Value = value; 
            Neighbors = new List<WeightedEdge<T>>();
        }

        public T Value { get; }
        public ICollection<WeightedEdge<T>> Neighbors { get; }
    }
}