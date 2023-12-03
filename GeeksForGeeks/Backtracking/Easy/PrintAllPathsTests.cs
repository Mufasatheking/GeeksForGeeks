using GeeksForGeeks.Graphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeeksForGeeks.Backtracking.Easy;

[TestClass]
public class PrintAllPathsTests
{
    [TestMethod]
    public void TestPrintAllPaths()
    {
        var graph = new AdjacencyListGraph(5, false);
        graph.AddEdge(0,1);
        graph.AddEdge(0,2);
        graph.AddEdge(0,4);
        
        graph.AddEdge(1,3);
        graph.AddEdge(1,4);
        
        graph.AddEdge(2,4);
        
        graph.AddEdge(3,2);
        
        PrintAllPaths(graph,0,4,new List<int>());
    }

    public void PrintAllPaths(AdjacencyListGraph graph, int current, int target, List<int> predecessors)
    {
        predecessors.Add(current);

        if (current == target)
        {
            Console.WriteLine(string.Join(">",predecessors));
            return;
        }

        var edges = graph._adjacencyList[current];
        if(edges.Any() == false)return;

        foreach (var edge in edges)
        {
            var next = new List<int>(predecessors);
            PrintAllPaths(graph, edge.To, target, next);
        }
    }
}