using GeeksForGeeks.Graphs.GraphHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeeksForGeeks.Graphs.Searching;

[TestClass]
public class MatrixBFSSearchTests
{
    [TestMethod]
    public void MatrixBFS()
    {
        var graph = AdjacencyMatrixGraphs.TenNodesUndirected();
        //graph.PrintMatrix();
        BreadthFirstSearch(graph);
    }

    public void BreadthFirstSearch(AdjacencyMatrixGraph graph)
    {
        var visited = new HashSet<int>();
        var queue = new Queue<int>();
        queue.Enqueue(6);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            if (visited.Contains(current) == false)
            {
                Console.WriteLine($"Visiting: {current}");

                visited.Add(current);
                for (int i = 0; i < graph.Vertices; i++)
                {
                    if (graph.HasEdge(current, i) && visited.Contains(i) == false)
                    {
                        queue.Enqueue(i);
                    }
                }
            }
        }
    }
}