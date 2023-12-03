using GeeksForGeeks.Graphs;
using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeeksForGeeks.Backtracking.Easy;

[TestClass]
public class FindIfPathWithKTests
{
    [TestMethod]
    public void TestFindIfPathWithK()
    {
        var graph = new AdjacencyListGraph(9, true);
        
        graph.AddEdge(0,1,4);
        graph.AddEdge(0,7,8);
        
        graph.AddEdge(1,2,8);
        graph.AddEdge(1,7,11);
        
        graph.AddEdge(2,3,7);
        graph.AddEdge(2,5,4);
        graph.AddEdge(2,8,2);
        
        graph.AddEdge(3,4,9);
        graph.AddEdge(3,5,14);
        
        graph.AddEdge(4,5,10);
        
        graph.AddEdge(5,6,2);
        
        graph.AddEdge(6,8,6);
        graph.AddEdge(6,7,1);
        
        graph.AddEdge(7,8,7);
        FindIfPathWithK(graph, 0, 58, new List<int>());

    }

    public void FindIfPathWithK(AdjacencyListGraph graph, int current, int target, List<int> predecessors)
    {
        predecessors.Add(current);
        if (target <= 0)
        {
            Console.WriteLine(String.Join(">", predecessors));
            return;
        }

        var edges = graph._adjacencyList[current];

        foreach (var edge in edges)
        {
            if (predecessors.Contains(edge.To) == false)
            {
                var next = new List<int>(predecessors);
                FindIfPathWithK(graph, edge.To, target - edge.Weight, next);
            }
        }
        return;
    }
}