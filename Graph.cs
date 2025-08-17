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
            Console.WriteLine("[RemoveVertex] Could not remove vertex" + vertexID + ", not found");
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
        Console.WriteLine("[RemoveVertex] Removed node " + vertexID);
    }

    public void RemoveEdge(int from, int to) {
        Vertex? fromVertex = FindVertex(from);
        if (fromVertex == null) {
            Console.WriteLine("[RemoveEdge] Could not remove edge, vertex " + from + " could not be found");
            return;
        }
        Vertex? toVertex = FindVertex(to);
        if (toVertex == null) {
            Console.WriteLine("[RemoveEdge] Could not remove edge, vertex " + to + " could not be found");
            return;
        }
        var fromEdges = fromVertex.Edges;
        Edge? edge = FindEdge(from, to);
        if (edge == null) {
            Console.WriteLine("[RemoveEdge] Could not remove edge, edge from " + from + " to " + to + " could not be found");
            return;
        }
        fromEdges.RemoveNode(edge);
    }

    public Vertex AddVertex(int id) {
        Vertex? vertex = FindVertex(id);
        if (vertex != null) {
            return vertex;
        }

        vertex = new Vertex(id);
        Vertices.Append(vertex);
        Console.WriteLine("[AddVertex] Created new vertex " + id);
        return vertex;
    }

    public Edge AddEdge(int from, int to, int weight) {
        Vertex fromVertex = AddVertex(from);
        Vertex toVertex = AddVertex(to);
        Edge? edge = FindEdge(from, to);
        if (edge != null) {
            Console.WriteLine("[AddEdge] Could not make a new edge, it already exists from " + from + " to " + to);
            return edge;
        }
        edge = new Edge(fromVertex, toVertex, weight);
        fromVertex.Edges.Append(edge);
        Console.WriteLine("[AddEdge] Created new edge from " + from + " to " + to + " with weight " + weight);
        return edge;
        
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

    public Edge? FindEdge(int from, int to) {
        Vertex? fromVertex = FindVertex(from);
        Vertex? toVertex = FindVertex(to);
        if (fromVertex == null || toVertex == null) {
            return null;
        }
        var fromEdges = fromVertex.Edges;
        var current = fromVertex.Edges.Head;

        while (current != null) {
            var next = current.Next;
            if (current.Data == null) {
                continue;
            }
            if (current.Data.To.Id == to && fromVertex.Id == from) { 
                return current.Data;
            }
            current = next;
        }
        return null;
    }

    public void Print() {
        Console.WriteLine("Graph");
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
        Console.WriteLine("------------------------------------------");
    }

}