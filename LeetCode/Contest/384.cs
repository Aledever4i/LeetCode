using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Contest
{
    public static class _384
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static int[][] ModifiedMatrix(int[][] matrix)
        {
            var columnMax = new int[matrix[0].Length];
            Array.Fill(columnMax, -1);

            var map = new List<(int, int)>();
            for (var y = 0; y < matrix.Length; y++)
            {
                for (var i = 0; i < columnMax.Length; i++)
                {
                    var v = matrix[y][i];

                    if (v == -1)
                    {
                        map.Add((y, i));
                    }
                    else
                    {
                        columnMax[i] = Math.Max(columnMax[i], v);
                    }                    
                }
            }

            foreach (var v in map)
            {
                matrix[v.Item1][v.Item2] = columnMax[v.Item2];
            }

            return matrix;
        }


        public static int CountMatchingSubarrays(int[] nums, int[] pattern)
        {
            return 0;
        }
    }
}
