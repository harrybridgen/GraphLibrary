public class Program {
    static void Main(String[] args){
        Graph graph = new Graph();

        graph.AddVertex(0);
        graph.AddVertex(1);
        graph.AddEdge(0, 1, 4);
        graph.AddEdge(1, 3, 1);
        graph.Print();
        graph.RemoveVertex(1);
        graph.Print();
    }
}
