using GeeksForGeeks.Graphs.GraphHelpers;
using GeeksForGeeks.Graphs.Searching;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeeksForGeeks.Graphs.Paths;

[TestClass]
public class DijkstrasAlgorithmLists
{
    [TestMethod]
    public void FindShortestPath()
    {
        var graph = AdjacencyListGraphs.CreateRandomWeightedGraph(30, 2, 5, true,5);
        var visited = new HashSet<int>();
        var path = DepthFirstSearch(0, graph, visited, 28);
        while (path == false)
        {
            graph = AdjacencyListGraphs.CreateRandomWeightedGraph(30, 2, 5, true,5);
            path = DepthFirstSearch(0, graph, visited, 28);
        }

        Dijkstras(graph, 0, 28);
    }

    public void Dijkstras(AdjacencyListGraph graph, int start, int target)
    {
        var queue = new PriorityQueue<int, int>();
        var distances = new Dictionary<int, int>();
        var predecessors = new Dictionary<int, int?>();
        var visited = new HashSet<int>();

        // Initialize distances and predecessors
        for (int i = 0; i < graph._vertices; i++)
        {
            distances[i] = int.MaxValue;
            predecessors[i] = null;
        }
        distances[start] = 0;

        queue.Enqueue(start, 0);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            if (visited.Contains(current)) continue;
            visited.Add(current);

            foreach (var edge in graph._adjacencyList[current])
            {
                if (visited.Contains(edge.To)) continue;

                var pathLength = distances[current] + edge.Weight;
                if (pathLength < distances[edge.To])
                {
                    distances[edge.To] = pathLength;
                    predecessors[edge.To] = current;
                    queue.Enqueue(edge.To, pathLength);
                }
            }
        }

        // Reconstruct the shortest path from source to target
        var path = ReconstructPath(predecessors, target);

        foreach (var node in path)
        {
            Console.WriteLine(node);
        }
    }

    private List<int> ReconstructPath(Dictionary<int, int?> predecessors, int target)
    {
        var path = new List<int>();
        int? current = target;

        while (current != null)
        {
            path.Add(current.Value);
            current = predecessors[current.Value];
        }

        path.Reverse(); // Reverse to get the path from source to target
        return path;
    }
 
    public bool DepthFirstSearch(int current, AdjacencyListGraph graph,HashSet<int> visited, int target)
    {
        if (current == target) return true;
        visited.Add(current);
        var connected = graph._adjacencyList[current];
        foreach (var next in connected)
        {
            if (visited.Contains(next.To) == false)
            {
                bool found = DepthFirstSearch(next.To,graph, visited, target);
                if (found)
                    return true;
            }
        }

        return false;
    }
}