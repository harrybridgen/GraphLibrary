public class Graph {
    private LinkedList<Vertex> Vertices = new();

    public class Vertex {
        public int Id { get; }
        public LinkedList<Edge> Edges { get; } = new();
        public Vertex(int id) { Id = id; }
    }

    public class Edge {
        public Vertex From { get; }
        public Vertex To { get; }
        public int Weight { get; }
        public Edge(Vertex from, Vertex to, int weight) {
            From = from; 
            To = to; 
            Weight = weight;
        }
    }
    public void RemoveVertex(int vertexID) {
        Vertex? fromVertex = FindVertex(vertexID);
        if (fromVertex == null) {
            return;
        }

        for (var Current = Vertices.Head; Current != null; Current = Current.Next) {
            var NodeData = Current.Data;
            if (NodeData == null) {
                continue;
            }

            if (NodeData.Equals(fromVertex)) {
                fromVertex.Edges.Clear();
                continue;
            }
            var edge = NodeData.Edges.Head;
            while (edge != null) {
                var next = edge.Next;
                if (edge.Data == null) {
                    continue;
                }
                if (edge.Data.To.Equals(fromVertex)) {
                    NodeData.Edges.RemoveNode(edge.Data);
                }
                edge = next;
            }
        }

        Vertices.RemoveNode(fromVertex);
    }

    public void RemoveEdge(int from, int to) {
        Vertex? fromVertex = FindVertex(from);
        if (fromVertex == null) {
            return;
        }
        Vertex? toVertex = FindVertex(to);
        if (toVertex == null) {
            return;
        }

        var fromEdges = fromVertex.Edges;
        var current = fromVertex.Edges.Head;

        while (current != null) {
            var next = current.Next;
            if (current.Data == null) {
                continue;
            }
            if (current.Data.To.Id == to) {
                fromEdges.RemoveNode(current.Data);
                break;
            }
            current = next;
        }

    }
    public Vertex AddVertex(int id) {
        Vertex? vertex = FindVertex(id);
        if (vertex != null) {
            return vertex;
        }

        vertex = new Vertex(id);
        Vertices.Append(vertex);
        return vertex;
    }

    public void AddEdge(int from, int to, int weight) {
        Vertex fromVertex = AddVertex(from);
        Vertex toVertex = AddVertex(to);
        fromVertex.Edges.Append(new Edge(fromVertex, toVertex, weight));
    }

    public Vertex? FindVertex(int id) {
        if (Vertices.Head == null) {
            return null;
        }
        LinkedList<Vertex>.Node? current = Vertices.Head;
        
        while (current != null) {
            if (current.Data == null) {
                current = current.Next;
                continue;
            }

            Vertex vertex = current.Data;
            if (id == vertex.Id) {
                return vertex;
            }
            current = current.Next;
        }
        return null;
    }

    public void Print() {
        Console.WriteLine("\nGraph");
        var current = Vertices.Head;
        while (current != null) {
            var v = current.Data!;
            Console.Write($"Vertex {v.Id}: ");

            var edgeNode = v.Edges.Head;
            while (edgeNode != null) {
                var e = edgeNode.Data!;
                Console.Write($" -> {e.To.Id}({e.Weight})");
                edgeNode = edgeNode.Next;
            }

            Console.WriteLine(); 
            current = current.Next;
        }
    }

}