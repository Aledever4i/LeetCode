using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class _700_799
    {
        /// <summary>
        /// 785. Is Graph Bipartite?. Tags: Depth-First Search, Breadth-First Search, Union Find, Graph
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public static bool IsBipartite(int[][] graph)
        {
            var n = graph.Length;

            for (int i = 0; i < n; i++)
            {
                var connects = graph[i];

                var notConnectedX = Enumerable.Range(0, n).Except(connects);

                foreach (var y in notConnectedX)
                {
                    var connectY = graph[y];

                    var notConnectedY = Enumerable.Range(0, n).Except(connects).Except(new int[] { i, y });

                    if (!notConnectedY.Any())
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
