using GeeksForGeeks.Graphs.GraphHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeeksForGeeks.Graphs.Searching;

[TestClass]
public class MatrixDFSSearchTests
{
    [TestMethod]
    public void MatrixDFS()
    {
        var graph = AdjacencyMatrixGraphs.TenNodesUndirected();
        //graph.PrintMatrix();
        var visited = new HashSet<int>();
        DepthFirstSearch(6,graph,visited);
    }

    public void DepthFirstSearch(int current, AdjacencyMatrixGraph graph, HashSet<int> visited)
    {
        Console.WriteLine($"Visiting: {current}");
        visited.Add(current);
        for (int i = 0; i < graph.Vertices; i++)
        {
            if (graph.HasEdge(current, i) && visited.Contains(i) == false)
            {
                DepthFirstSearch(i,graph,visited);
            }
        }
    }
}