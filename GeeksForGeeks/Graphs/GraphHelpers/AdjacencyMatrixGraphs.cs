namespace GeeksForGeeks.Graphs.GraphHelpers;

public static class AdjacencyMatrixGraphs
{
    private static readonly Random random = new Random();

    public static AdjacencyMatrixGraph CreateRandomWeightedMatrixGraph(int vertices, int maxEdgesPerNode, int maxWeightPerEdge, bool undirected)
    {
        var graph = new AdjacencyMatrixGraph(vertices, undirected);

        for (int i = 0; i < vertices; i++)
        {
            HashSet<int> addedEdges = new HashSet<int>();
            int edgeCount = random.Next(1, maxEdgesPerNode + 1); // Random number of edges

            for (int j = 0; j < edgeCount; j++)
            {
                int to = random.Next(vertices); // Random target vertex
                while (addedEdges.Contains(to) || to == i) // Ensure no duplicate edge and no self-loop
                {
                    to = random.Next(vertices);
                }

                int weight = random.Next(1, maxWeightPerEdge + 1); // Random weight
                graph.AddEdge(i, to, weight);
                addedEdges.Add(to);
            }
        }

        return graph;
    }
    public static AdjacencyMatrixGraph TenNodesUndirected()
    {
        //10NodesUndirected.jpeg
        var graph = new AdjacencyMatrixGraph(10, true);
        graph.AddEdge(0, 1);
        graph.AddEdge(0, 2);
        graph.AddEdge(0, 3);

        graph.AddEdge(1, 4);
        graph.AddEdge(2, 5);
        graph.AddEdge(3, 6);

        graph.AddEdge(4, 7);
        graph.AddEdge(5, 8);
        graph.AddEdge(6, 9);

        graph.AddEdge(7, 8);
        graph.AddEdge(8, 9);

        return graph;
    }
    
    public static AdjacencyMatrixGraph TenNodesDirectedNoCycle()
    {
        //10NodesUndirected.jpeg
        var graph = new AdjacencyMatrixGraph(10, false);
        graph.AddEdge(0, 1);
        graph.AddEdge(0, 2);
        graph.AddEdge(0, 3);

        graph.AddEdge(1, 4);
        graph.AddEdge(2, 5);
        graph.AddEdge(3, 6);

        graph.AddEdge(4, 7);
        graph.AddEdge(5, 8);
        graph.AddEdge(6, 9);

        graph.AddEdge(7, 8);
        graph.AddEdge(8, 9);

        return graph;
    }

    public static AdjacencyMatrixGraph TwelveNodesDirectedCycle()
    {
        var graph = new AdjacencyMatrixGraph(12, false);
        graph.AddEdge(0, 1);
        graph.AddEdge(0, 2);
        graph.AddEdge(0, 3);

        graph.AddEdge(1, 4);
        graph.AddEdge(2, 5);
        graph.AddEdge(3, 6);

        graph.AddEdge(4, 7);
        graph.AddEdge(5, 8);
        graph.AddEdge(6, 9);

        graph.AddEdge(7, 8);
        graph.AddEdge(9, 8);

        graph.AddEdge(8, 10);
        graph.AddEdge(10, 11);
        graph.AddEdge(11, 8);
        
        return graph;
    }
}