using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LeetCode
{
    /// <summary>
    /// 2642. Design Graph With Shortest Path Calculator
    /// </summary>
    public class Graph2642
    {
        private readonly List<(int Node, int Cost)>[] _graph;

        public Graph2642(int n, int[][] edges)
        {
            _graph = new List<(int Node, int Cost)>[n];

            for (int i = 0; i < n; i++)
            {
                _graph[i] = new List<(int Node, int Cost)>();
            }

            foreach (var edge in edges)
            {
                AddEdge(edge);
            }
        }

        public void AddEdge(int[] edge)
        {
            _graph[edge[0]].Add((edge[1], edge[2]));
        }

        public int ShortestPath(int node1, int node2)
        {
            if (node1 == node2)
            {
                return 0;
            }
            else if (!_graph[node1].Any())
            {
                return -1;
            }

            HashSet<int> visited = new HashSet<int>();
            var queue = new PriorityQueue<int, int>();
            queue.Enqueue(node1, 0);


            while (queue.TryDequeue(out int currNode, out int currCost))
            {
                if (visited.Contains(currNode))
                {
                    continue;
                }

                if (currNode == node2)
                { 
                    return currCost;
                }

                visited.Add(currNode);

                foreach (var next in _graph[currNode])
                {
                    queue.Enqueue(next.Node, next.Cost + currCost);
                }
            }

            return -1;
        }
    }

    public static class _2600_2699
    {
    }
}
