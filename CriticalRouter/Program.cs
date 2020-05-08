using System;

namespace CriticalRouter
{
    class Program
    {
        static void Main(string[] args)
        {
            int numNodes = 7;
            int numEdges = 7;

            bool[, ] adjacencyList = new bool[numNodes, numNodes];

            var edges = new int[][]
            {
                new int[] { 0, 1 },
                new int[] { 0, 2 },
                new int[] { 1, 3 },
                new int[] { 2, 3 },
                new int[] { 2, 5 },
                new int[] { 5, 6 },
                new int[] { 3, 4 }
            };

            foreach (var edge in edges)
            {
                adjacencyList[edge[0], edge[1]] = true;
                adjacencyList[edge[1], edge[0]] = true;
            }

            var visited = new bool[numNodes];
            var parent = new int[numNodes];
            for (int i = 0; i < numNodes; i++)
                parent[i] = -1;
            var dis = new int[numNodes];
            var low = new int[numNodes];
            var aps = new bool[numNodes];

            DFS(adjacencyList, visited, parent, dis, low, aps, 0, 0);

            for (int i = 0; i < numNodes; i++)
            {
                if (aps[i])
                    Console.WriteLine(i);
            }
        }

        static void DFS(bool[, ] adjacencyList, bool[] visited, int[] parent, int[] dis, int[] low, bool[] aps, int vertex, int time)
        {
            visited[vertex] = true;
            dis[vertex] = time;
            low[vertex] = time;
            int children = 0;

            for (int neighbor = 0; neighbor < adjacencyList.GetLength(1); neighbor++)
            {
                if (adjacencyList[vertex, neighbor])
                {
                    // if not visited
                    if (!visited[neighbor])
                    {
                        parent[neighbor] = vertex;
                        children++;
                        DFS(adjacencyList, visited, parent, dis, low, aps, neighbor, time + 1);

                        if (low[neighbor] < low[vertex])
                            low[vertex] = low[neighbor];

                        if (parent[vertex] == -1 && children > 1)
                            aps[vertex] = true;
                        // no backedge from this neighbor to vertex's ancestor
                        if (parent[vertex] > -1 && low[neighbor] > dis[vertex])
                            aps[vertex] = true;
                    }
                    else
                    {
                        if (neighbor != parent[vertex])
                            if (low[neighbor] < low[vertex])
                                low[vertex] = low[neighbor];
                    }
                }
            }
        }

    }
}