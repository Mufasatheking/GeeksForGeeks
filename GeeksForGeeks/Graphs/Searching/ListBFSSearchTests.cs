using GeeksForGeeks.Graphs.GraphHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeeksForGeeks.Graphs.Searching;

[TestClass]
public class ListBFSSearchTests
{

    [TestMethod]
    public void ListBFS()
    {
        var graph = AdjacencyListGraphs.TenNodesUndirected();
        BreadthFirstSearch(graph);
    }

    public void BreadthFirstSearch(AdjacencyListGraph graph)
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
                var connected = graph._adjacencyList[current];
                foreach (var next in connected)
                {
                    if (visited.Contains(next.To) == false)
                        queue.Enqueue(next.To);
                }

            }
        }
    }
    
}