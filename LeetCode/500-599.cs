using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class _500_599
    {
        /// <summary>
        /// 547. Number of Provinces. Tags: Depth-First Search, Breadth-First Search, Union Find, Graph
        /// </summary>
        public static int FindCircleNum(int[][] isConnected)
        {
            var n = isConnected.Length;
            var island = 0;
            var isIncluded = new bool[n];

            for (int i = 0; i < n; i++)
            {
                if (isIncluded[i] == false)
                {
                    isIncluded[i] = true;
                    DFS(isConnected, i, isIncluded);
                    island++;
                }
            }

            return island;

            void DFS(int[][] graph, int i, bool[] h)
            {
                for (int j = 0; j < graph[i].Length; j++)
                {
                    if (i != j && graph[i][j] == 1 && h[j] == false)
                    {
                        h[j] = true;
                        DFS(graph, j, h);
                    }
                }
            }
        }
    }
}
