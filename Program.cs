public class Program {
    static void Main(String[] args){
        Graph graph = new Graph();

        graph.AddEdge(0, 1, 1);
        graph.AddEdge(1, 2, 1);
        graph.AddEdge(2, 3, 1);
        graph.AddEdge(3, 0, 1);
        graph.Print();

        graph.RemoveVertex(0);
        graph.Print();

        graph.AddVertex(0);
        graph.AddEdge(0, 1, 1);
        graph.Print();

        graph.RemoveEdge(0, 1);
        graph.Print();
    }
}
