using GraphTheory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheory
{
    public class Program
    {
        // function to form edge between
        // two vertices source and dest
        private static void AddEdge(List<List<int>> adj, int i, int j)
        {
            adj[i].Add(j);
            adj[j].Add(i);
        }
        // function to print the shortest
        // distance and path between source
        // vertex and destination vertex
        private static void PrintShortestDistance(List<List<int>> adj, int s, int dest, int v)
        {
            // predecessor[i] array stores
            // predecessor of i and distance
            // array stores distance of i
            // from s
            int[] pred = new int[v];
            int[] dist = new int[v];

            if (BFS(adj, s, dest, v, pred, dist) == false)
            {
                Console.WriteLine("Given source and destination are not connected");
                return;
            }
            // List to store path
            List<int> path = new List<int>();
            int crawl = dest;
            path.Add(crawl);

            while (pred[crawl] != -1)
            {
                path.Add(pred[crawl]);
                crawl = pred[crawl];
            }

            // Print distance
            Console.WriteLine("Shortest path length is: " + dist[dest]);

            // Print path
            Console.WriteLine("Path is ::");

            for (int i = path.Count - 1;
                     i >= 0; i--)
            {
                Console.Write(path[i] + " ");
            }
        }

        // a modified version of BFS that
        // stores predecessor of each vertex
        // in array pred and its distance
        // from source in array dist
        private static bool BFS(List<List<int>> adj,
                                int src, int dest,
                                int v, int[] pred,
                                int[] dist)
        {
            // a queue to maintain queue of
            // vertices whose adjacency list
            // is to be scanned as per normal
            // BFS algorithm using List of int type
            List<int> queue = new List<int>();

            // bool array visited[] which
            // stores the information whether
            // ith vertex is reached at least
            // once in the Breadth first search
            bool[] visited = new bool[v];

            // initially all vertices are
            // unvisited so v[i] for all i
            // is false and as no path is
            // yet constructed dist[i] for
            // all i set to infinity
            for (int i = 0; i < v; i++)
            {
                visited[i] = false;
                dist[i] = int.MaxValue;
                pred[i] = -1;
            }

            // now source is first to be
            // visited and distance from
            // source to itself should be 0
            visited[src] = true;
            dist[src] = 0;
            queue.Add(src);

            // bfs Algorithm
            while (queue.Count != 0)
            {
                int u = queue[0];
                queue.RemoveAt(0);

                for (int i = 0; i < adj[u].Count; i++)
                {
                    if (visited[adj[u][i]] == false)
                    {
                        visited[adj[u][i]] = true;
                        dist[adj[u][i]] = dist[u] + 1;
                        pred[adj[u][i]] = u;
                        queue.Add(adj[u][i]);

                        // stopping condition (when we
                        // find our destination)
                        if (adj[u][i] == dest)
                            return true;
                    }
                }
            }
            return false;
        }

        static void Main(string[] args)
        {

            Console.ReadKey();
        }
    }
}
