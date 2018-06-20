namespace Chownus.AoC.Console.Common.Graphs
{
    public abstract class WeightedGraph<T> : Graph<T>
    {
        /// <summary>
        /// Adds a weighted edge with a cost.
        /// </summary>
        /// <param name="v1">The source vertex</param>
        /// <param name="v2">The destination vertex</param>
        /// <param name="cost">The cost of the trip.</param>
        public abstract void AddEdge(Vertex<T> v1, Vertex<T> v2, int cost);
    }

    public class UndirectedWeightedGraph<T> : WeightedGraph<T>
    {
        public override void AddEdge(Vertex<T> v1, Vertex<T> v2, int cost)
        {
            var fwd = new WeightedEdge<T> { From = v1, To = v2, Cost = cost };
            var back = new WeightedEdge<T> { From = v2, To = v1, Cost = cost };
            v1.Neighbors.Add(fwd);
            v2.Neighbors.Add(back);

            Edges.Add(fwd);
            Edges.Add(back);
        }
    }

    public class DirectedWeightedGraph<T> : WeightedGraph<T>
    {
        public override void AddEdge(Vertex<T> v1, Vertex<T> v2, int cost)
        {
            var edge = new WeightedEdge<T> {From = v1, To = v2, Cost = cost};
            v1.Neighbors.Add(edge);

            Edges.Add(edge);
        }
    }
}