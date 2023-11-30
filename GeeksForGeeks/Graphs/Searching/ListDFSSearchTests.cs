using GeeksForGeeks.Graphs.GraphHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeeksForGeeks.Graphs.Searching;

[TestClass]
public class ListDFSSearchTests
{

    [TestMethod]
    public void ListDFS()
    {
        var graph = AdjacencyListGraphs.TenNodesUndirected();
        var visited = new HashSet<int>();
        DepthFirstSearch(0,graph,visited);
    }

    public void DepthFirstSearch(int current, AdjacencyListGraph graph, HashSet<int> visited)
    {
        Console.WriteLine($"Visiting: {current}");
        visited.Add(current);
        var connected = graph._adjacencyList[current];
        foreach (var next in connected)
        {
            if (visited.Contains(next.To) == false)
            {
                DepthFirstSearch(next.To,graph,visited);
            }
        }
    }
}