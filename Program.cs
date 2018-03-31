using System;
using System.Collections.Generic;

namespace DeepSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var g = NewMethod();

            //var path = g.FindPath();
            //foreach (var num in path)
            //{
            //    Console.Write($"{num} ->");
            //}
            //Console.WriteLine();

            //var res = g.connectivityComponents();

            //foreach (var conn in res)
            //{
            //    foreach (var node in conn)
            //    {
            //        Console.Write(node + " - ");
            //    }
            //    Console.WriteLine();
            //}
            



            //var bridges = g.FindBridge();

            //foreach (var x in bridges)
            //{
            //    Console.WriteLine($"{x.Key} -- {x.Value}");
            //}



            var minPath = g.BFS(0, 6);

            foreach (var x in minPath)
            {
                Console.Write($"{x} -->");
            }

            Console.ReadLine();
        }

        private static Graph NewMethod()
        {
            Graph g = new Graph();
            g.graphList.Add(new List<NodeConnection>());
            g.graphList[0].Add(new NodeConnection() { Number = 1, Weight = 10 });

            g.graphList.Add(new List<NodeConnection>());
            g.graphList[1].Add(new NodeConnection() { Number = 0, Weight = 10 });
            g.graphList[1].Add(new NodeConnection() { Number = 2, Weight = 30 });

            g.graphList.Add(new List<NodeConnection>());
            g.graphList[2].Add(new NodeConnection() { Number = 1, Weight = 30 });
            g.graphList[2].Add(new NodeConnection() { Number = 3, Weight = 150 });
            g.graphList[2].Add(new NodeConnection() { Number = 4, Weight = 80 });
            g.graphList[2].Add(new NodeConnection() { Number = 5, Weight = 60 });
            g.graphList[2].Add(new NodeConnection() { Number = 7, Weight = 60 });

            g.graphList.Add(new List<NodeConnection>());
            g.graphList[3].Add(new NodeConnection() { Number = 2, Weight = 150 });
            g.graphList[3].Add(new NodeConnection() { Number = 4, Weight = 40 });
            g.graphList[3].Add(new NodeConnection() { Number = 6, Weight = 15 });

            g.graphList.Add(new List<NodeConnection>());
            g.graphList[4].Add(new NodeConnection() { Number = 2, Weight = 80 });
            g.graphList[4].Add(new NodeConnection() { Number = 3, Weight = 40 });
            g.graphList[4].Add(new NodeConnection() { Number = 5, Weight = 100 });

            g.graphList.Add(new List<NodeConnection>());
            g.graphList[5].Add(new NodeConnection() { Number = 4, Weight = 100 });
            g.graphList[5].Add(new NodeConnection() { Number = 2, Weight = 60 });


            g.graphList.Add(new List<NodeConnection>());
            g.graphList[6].Add(new NodeConnection() { Number = 3, Weight = 15 });

            g.graphList.Add(new List<NodeConnection>());
            g.graphList[7].Add(new NodeConnection() { Number = 8, Weight = 15 });
            g.graphList[7].Add(new NodeConnection() { Number = 9, Weight = 15 });
            g.graphList[7].Add(new NodeConnection() { Number = 2, Weight = 60 });

            g.graphList.Add(new List<NodeConnection>());
            g.graphList[8].Add(new NodeConnection() { Number = 7, Weight = 15 });
            g.graphList[8].Add(new NodeConnection() { Number = 9, Weight = 15 });

            g.graphList.Add(new List<NodeConnection>());
            g.graphList[9].Add(new NodeConnection() { Number = 7, Weight = 15 });
            g.graphList[9].Add(new NodeConnection() { Number = 8, Weight = 15 });



            return g;
        }
    }
}
