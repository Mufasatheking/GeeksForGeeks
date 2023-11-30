using GeeksForGeeks.Graphs.GraphHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeeksForGeeks.Graphs.Cycles;

[TestClass]
public class DirectedListGraphTests
{
    [TestMethod]
    public void DirectedListCycle()
    {
        var graph = AdjacencyListGraphs.TwelveNodesDirectedCycle();
        var visited = new HashSet<int>();
        var recursiveStack = new HashSet<int>();
        DetectCycle(0,graph,visited,recursiveStack);
    }
    [TestMethod]
    public void DirectedListNoCycle()
    {
        var graph = AdjacencyListGraphs.TenNodesDirectedNoCycle();
        var visited = new HashSet<int>();
        var recursiveStack = new HashSet<int>();
        DetectCycle(0,graph,visited,recursiveStack);
    }
    public void DetectCycle(int current, AdjacencyListGraph graph, HashSet<int> visited, HashSet<int> recursiveStack)
    {
        Console.WriteLine($"Visiting: {current}");
        visited.Add(current);
        recursiveStack.Add(current);
        var connected = graph._adjacencyList[current];
        foreach (var next in connected)
        {
            if (recursiveStack.Contains(next.To))
            {
                Console.WriteLine($"Cycle Detected: {string.Join(">",recursiveStack)}>{next}");
                break;
            }
            if (visited.Contains(next.To) == false)
            {
                recursiveStack.Add(next.To);
                DetectCycle(next.To,graph,visited,recursiveStack);
                recursiveStack.Remove(next.To);
            }
        }
    }

}