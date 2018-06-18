namespace Chownus.AoC.Console.Common.Graphs
{
    public class WeightedEdge<T>
    {
        public Vertex<T> From { get; set; }
        public Vertex<T> To { get; set; }
        public int Cost { get; set; }
    }
}