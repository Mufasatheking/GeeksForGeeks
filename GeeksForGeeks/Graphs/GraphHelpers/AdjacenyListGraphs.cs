namespace GeeksForGeeks.Graphs.GraphHelpers;

public static class AdjacencyListGraphs
{
    private static readonly Random random = new Random();
    public static AdjacencyListGraph CreateRandomWeightedGraph(int vertices, int maxEdgesPerNode, int maxWeightPerEdge, bool undirected, int? jumpCount = null)
    {
        var graph = new AdjacencyListGraph(vertices, undirected); 

        for (int i = 0; i < vertices; i++)
        {
            int edgeCount = random.Next(1, maxEdgesPerNode + 1);

            for (int j = 0; j <= edgeCount; j++)
            {
                if (jumpCount != null)
                {
                    var ceiling = i > vertices - (int)jumpCount ? vertices : i + (int)jumpCount;
                    int to = random.Next(i, ceiling); 
                    while (graph.HasEdge(i, to) == true && i<vertices-(int)jumpCount)
                    {
                        to = random.Next(vertices);
                    }
                    int weight = random.Next(1, maxWeightPerEdge + 1); 

                    graph.AddEdge(i, to, weight);
                }
                else
                {
                    int to = random.Next(vertices);
                    while (graph.HasEdge(i, to) == true)
                    {
                        to = random.Next(vertices);
                    }

                    int weight = random.Next(1, maxWeightPerEdge + 1);

                    graph.AddEdge(i, to, weight);
                }
            }
        }

        return graph;
    }
    
    public static AdjacencyListGraph Complete(int vertices)
    {
        var graph = new AdjacencyListGraph(vertices, true);
        var rand = new Random();
        for (int i = 0; i < vertices; i++)
        {
            for (int j = i + 1; j < vertices; j++)
            {
                var weight = rand.Next(1, 10);
                graph.AddEdge(i, j,weight);
            }
        }
        return graph;
    }

    public static AdjacencyListGraph TenNodesUndirected()
    {
        var graph = new AdjacencyListGraph(10, true);
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
    public static AdjacencyListGraph TenNodesDirectedNoCycle()
    {
        //10NodesDirectedNoCycle.jpeg
        var graph = new AdjacencyListGraph(10, false);
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
        
        return graph;
    }
    public static AdjacencyListGraph TwelveNodesDirectedCycle()
    {
        var graph = new AdjacencyListGraph(12, false);
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