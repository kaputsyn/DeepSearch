using System;
using System.Collections.Generic;
using System.Text;

namespace DeepSearch
{
    public class Graph
    {
        public List<List<NodeConnection>> graphList = new List<List<NodeConnection>>();

        public int[] FindPath()
        {
            var path = new List<int>();
            var visited = new bool[graphList.Count];

            DFS(0, visited, path);

            return path.ToArray();
        }
        private void DFS(int number, bool[] visited ,List<int> path, KeyValuePair<int, int>? connectionToDelete = null )
        {
            path.Add(number);
            visited[number] = true;

            var conns = graphList[number];
            foreach (var conn in conns)
            {
                if (connectionToDelete.HasValue
                    && ((connectionToDelete.Value.Key == number && connectionToDelete.Value.Value == conn.Number)))
                {
                    continue;
                }
                if (!visited[conn.Number])
                {
                    DFS(conn.Number, visited, path, connectionToDelete);
                    path.Add(number);
                }

            }
        }
        public List<HashSet<int>> connectivityComponents(KeyValuePair<int, int>? connectionToDelete = null)
        {
            var result = new List<HashSet<int>>();

            
            var visited = new bool[graphList.Count];

            for (int i = 0; i < graphList.Count; i++)
            {
                if (!visited[i])
                {
                    var path = new List<int>();
                    DFS(i, visited, path, connectionToDelete);
                    var set = new HashSet<int>(path);

                    result.Add(set);
                }
            }
            return result;
        }
        public List<KeyValuePair<int, int>> FindBridge()
        {
            var bridges = new List<KeyValuePair<int, int>>();

            var cc = connectivityComponents().Count;

            for (int i = 0; i < graphList.Count; i++)
            {
                for (int j = 0; j < graphList[i].Count; j++)
                {
                    var pair = new KeyValuePair<int, int>(i, graphList[i][j].Number);

                    if (cc < connectivityComponents(pair).Count)
                    {
                        bridges.Add(pair);
                    }
                }
            }
            return bridges;
        }

        public List<int> BFS(int startNumber, int endNumber)
        {
            
            var visited = new bool[graphList.Count];
            int[] path = new int[graphList.Count];

            int[] weights = new int[graphList.Count];
            for (int i = 1; i < graphList.Count; i++)
            {
                weights[i] = Int32.MaxValue;
            }


            var queue = new Queue<int>();
            queue.Enqueue(startNumber);

            while (queue.Count > 0)
            {

                var node = queue.Dequeue();

                if (visited[node]) { continue; }

                visited[node] = true;

                foreach (var n in graphList[node])
                {
                    
                    if (weights[node] + n.Weight < weights[n.Number])
                    {
                        weights[n.Number] = weights[node] + n.Weight;
                        path[n.Number] = node;
                    }

                    queue.Enqueue(n.Number);
                }
            }


            List<int> minPath = new List<int>();
            minPath.Add(endNumber);
            var temp = endNumber;

            while (temp != startNumber)
            {
                temp = path[temp];
                minPath.Add(temp);
            }


            minPath.Reverse();

            return minPath;
        }
    }
}
