﻿using System;
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
        /// <summary>
        /// 2610. Convert an Array Into a 2D Array With Conditions
        /// </summary>
        public static IList<IList<int>> FindMatrix(int[] nums)
        {
            var dict = new Dictionary<int, int>();

            foreach (int num in nums)
            {
                if (!dict.TryAdd(num, 1))
                {
                    dict[num]++;
                }
            }

            var result = new List<IList<int>>();

            while (dict.Count > 0)
            {
                var keys = dict.Keys;
                var row = new List<int>();
                var keysForRemove = new List<int>();

                foreach (var key in keys)
                {
                    var val = dict[key];
                    row.Add(key);

                    if (val == 1)
                    {
                        dict.Remove(key);
                    }
                    else
                    {
                        dict[key]--;
                    }
                }

                result.Add(row);    
            }

            return result;
        }

        /// <summary>
        /// 2696. Minimum String Length After Removing Substrings
        /// </summary>
        public static int MinLength(string s)
        {
            var prev = new Stack<char>();
            var next = new Queue<char>(s);

            while (next.Count > 0)
            {
                var cur = next.Dequeue();

                if (cur == 'B' && prev.TryPeek(out var result) && result == 'A')
                {
                    prev.Pop();
                }
                else if (cur == 'D' && prev.TryPeek(out result) && result == 'C')
                {
                    prev.Pop();
                }
                else
                {
                    prev.Push(cur);
                }
            }

            return prev.Count;
        }
    }
}
