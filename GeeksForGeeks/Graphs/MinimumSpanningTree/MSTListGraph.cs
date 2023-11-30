using System.Reflection.Metadata;
using GeeksForGeeks.Graphs.GraphHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeeksForGeeks.Graphs.MinimumSpanningTree;

[TestClass]
public class MSTListGraph
{
    [TestMethod]
    public void MSTTest()
    {
        var completeGraph = AdjacencyListGraphs.Complete(10);
        completeGraph.PrintGraph();
        Console.WriteLine("---");
        var mst = Prims(completeGraph);
        mst.PrintGraph();
    }

    public AdjacencyListGraph Prims(AdjacencyListGraph initial)
    {
        var connected = new HashSet<int>();
        var unconnected = new HashSet<int>();
        for (int i = 0; i < initial._vertices; i++)
        {
            unconnected.Add(i);
        }

        var MST = new AdjacencyListGraph(initial._vertices, true);
        var current = unconnected.First(); // Start from any vertex
        connected.Add(current);
        unconnected.Remove(current);

        while (unconnected.Any())
        {
            Edge nextEdge = null;
            int nextVertex = -1;

            // Find the smallest edge connecting the connected and unconnected sets
            foreach (var vertex in connected)
            {
                foreach (var edge in initial._adjacencyList[vertex])
                {
                    if (unconnected.Contains(edge.To) && (nextEdge == null || edge.Weight < nextEdge.Weight))
                    {
                        nextEdge = edge;
                        nextVertex = edge.To;
                    }
                }
            }

            // If no edge is found, the graph is disconnected
            if (nextEdge == null) break;

            // Add the edge to the MST and update the sets
            MST.AddEdge(current, nextVertex, nextEdge.Weight);
            connected.Add(nextVertex);
            unconnected.Remove(nextVertex);
            current = nextVertex;
        }

        return MST;
    }

}