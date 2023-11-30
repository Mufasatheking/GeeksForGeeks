namespace GeeksForGeeks.Graphs
{
    public class Edge
    {
        public int To { get; set; }
        public int Weight { get; set; }

        public Edge(int to, int weight)
        {
            To = to;
            Weight = weight;
        }
    }

    public class AdjacencyListGraph
    {
        public int _vertices;
        private readonly bool _undirected;
        public List<Edge>[] _adjacencyList;

        public AdjacencyListGraph(int vertices, bool undirected)
        {
            _vertices = vertices;
            _undirected = undirected;
            _adjacencyList = new List<Edge>[vertices];
            for (int i = 0; i < vertices; ++i)
                _adjacencyList[i] = new List<Edge>();
        }

        // Function to add an edge into the graph
        public void AddEdge(int from, int to, int weight = 1)
        {
            _adjacencyList[from].Add(new Edge(to, weight));
            if (_undirected)
            {
                _adjacencyList[to].Add(new Edge(from, weight));
            }
        }

        public bool HasEdge(int from, int to)
        {
            return _adjacencyList[from].Any(edge => edge.To == to);
        }
        // A function to print the adjacency list representation of the graph
        public void PrintGraph()
        {
            for (int v = 0; v < _vertices; v++)
            {
                Console.Write("Adjacency list of vertex " + v + ": ");
                foreach (var edge in _adjacencyList[v])
                {
                    Console.Write($"({edge.To}, {edge.Weight}) ");
                }
                Console.WriteLine();
            }
        }
    }
}