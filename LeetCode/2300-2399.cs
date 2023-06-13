using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class _2300_2399
    {
        /// <summary>
        /// 2352. Equal Row and Column Pairs
        /// </summary>
        public static int EqualPairs(int[][] grid)
        {
            var n = grid.Length;
            var coincidences = new Dictionary<string, int>();
            var result = 0;

            for (int i = 0; i < n; i++)
            {
                var row = grid[i];

                var key = string.Join("-", row);

                if (!coincidences.TryAdd(key, 1))
                {
                    coincidences[key] += 1;
                }
            }

            for (int i = 0; i < n; i++)
            {
                var columnKey = grid[0][i].ToString();

                for (int y = 1; y < n; y++)
                {
                    columnKey = $"{columnKey}-{grid[y][i]}";
                }

                if (coincidences.TryGetValue(columnKey, out int value))
                {
                    result += value;
                }
            }

            return result;
        }
    }
}
