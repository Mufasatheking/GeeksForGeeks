using GeeksForGeeks.Graphs.GraphHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeeksForGeeks.Graphs.Cycles;

[TestClass]
public class DirectedMatrixGraph
{
    [TestMethod]
    public void DirectedListCycle()
    {
        var graph = AdjacencyMatrixGraphs.TwelveNodesDirectedCycle();
        var visited = new HashSet<int>();
        var recursiveStack = new HashSet<int>();
        DetectCycle(0,graph,visited,recursiveStack);
    }
    [TestMethod]
    public void DirectedListNoCycle()
    {
        var graph = AdjacencyMatrixGraphs.TenNodesDirectedNoCycle();
        var visited = new HashSet<int>();
        var recursiveStack = new HashSet<int>();
        DetectCycle(0,graph,visited,recursiveStack);
    }
    public void DetectCycle(int current, AdjacencyMatrixGraph graph, HashSet<int> visited, HashSet<int> recursiveStack)
    {
        Console.WriteLine($"Visiting: {current}");
        visited.Add(current);
        recursiveStack.Add(current);
        for (int i =0; i<graph.Vertices; i++)
        {
            if(graph.HasEdge(current,i) == false)continue;
            
            if (recursiveStack.Contains(i))
            {
                Console.WriteLine($"Cycle Detected: {string.Join(">",recursiveStack)}>{i}");
                break;
            }
            if (visited.Contains(i) == false)
            {
                recursiveStack.Add(i);
                DetectCycle(i,graph,visited,recursiveStack);
                recursiveStack.Remove(i);
            }
        }
    }
}