namespace GeeksForGeeks.Graphs
{
    public class AdjacencyMatrixGraph
    {
        private int[,] _adjacencyMatrix;
        public int Vertices { get; private set; }
        private readonly bool _undirected;

        public AdjacencyMatrixGraph(int vertices, bool undirected)
        {
            Vertices = vertices;
            _undirected = undirected;
            _adjacencyMatrix = new int[vertices, vertices];
        }

        public void AddEdge(int from, int to, int weight = 1)
        {
            _adjacencyMatrix[from, to] = weight;
            if (_undirected)
            {
                _adjacencyMatrix[to, from] = weight;
            }
        }

        public bool HasEdge(int from, int to)
        {
            return _adjacencyMatrix[from, to] != 0;
        }

        public int GetWeight(int from, int to)
        {
            return _adjacencyMatrix[from, to];
        }

        public void PrintMatrix()
        {
            for (int i = 0; i < Vertices; i++)
            {
                for (int j = 0; j < Vertices; j++)
                {
                    Console.Write(_adjacencyMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}