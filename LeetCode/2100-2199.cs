using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class _2100_2199
    {

        /// <summary>
        /// 2101. Detonate the Maximum Bombs. Tags: Array, Math, Depth-First Search, Breadth-First Search, Graph, Geometry
        /// </summary>
        public static int MaximumDetonation(int[][] bombs)
        {
            var n = bombs.Length;
            var list = new int[n][];
            var result = new int[n];

            for (int i = 0; i < n; i++)
            {
                List<int> points = new List<int>();

                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    if ((Math.Pow(bombs[i][0] - bombs[j][0], 2) + Math.Pow(bombs[i][1] - bombs[j][1], 2)) <= Math.Pow(bombs[i][2], 2))
                    {
                        points.Add(j);
                    }
                }

                list[i] = points.ToArray();
            }

            for (int i = 0; i < n; i++)
            {
                var visited = new List<int>();
                var booms = new List<int>();

                booms.Add(i);
                boom(i, visited, booms);

                result[i] = booms.Distinct().Count();
            }

            return result.Max();

            void boom(int p, List<int> visited, List<int> booms)
            {
                var newBooms = list[p];
                booms.AddRange(newBooms);
                visited.Add(p);

                foreach (var i in newBooms)
                {
                    if (!visited.Contains(i))
                    {
                        boom(i, visited, booms);
                    }
                }
            }
        }
    }
}
