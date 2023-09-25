using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class _1000_1099
    {
        /// <summary>
        /// 1027. Longest Arithmetic Subsequence. Tags: Array, Hash Table, Binary Search, Dynamic Programming
        /// </summary>
        public static int LongestArithSeqLength(int[] nums)
        {
            var length = nums.Length;

            if (length == 2)
            {
                return 2;
            }

            var dp = new Dictionary<(int, int), int>();
            var maxLength = 0;

            for (int right = 0; right < length; right++)
            {
                var rightValue = nums[right];

                for (int left = 0; left < right; left++)
                {
                    var leftValue = nums[left];
                    int diff = leftValue - rightValue;

                    if (dp.TryGetValue((left, diff), out int prevValue))
                    {
                        dp[(right, diff)] = prevValue + 1;
                    }
                    else
                    {
                        dp[(right, diff)] = 2;
                    }

                    maxLength = Math.Max(maxLength, dp[(right, diff)]);
                }
            }

            return maxLength;
        }

        /// <summary>
        /// 1048. Longest String Chain
        /// </summary>
        public static int LongestStrChain(string[] words)
        {
            System.Array.Sort(words, (a, b) => { return a.Length - b.Length; });

            var chainCount = new string[words.Length][];

            return 0;
        }

        /// <summary>
        /// 1091. Shortest Path in Binary Matrix. Tags: Array, Breadth-First Search, Matrix
        /// </summary>
        public static int ShortestPathBinaryMatrix(int[][] grid)
        {
            var n = grid.Length;
            var ways = new List<(int, int, int)>();
            var results = new List<int>();

            var visited = new int[n][];
            for (var i = 0; i < n; i++ )
            {
                visited[i] = new int[n];
            }

            if (grid[0][0] == 1 || grid[n - 1][n - 1] == 1)
            {
                return -1;
            }

            analyse(0, 0, 1);

            while (ways.Count > 0)
            {
                var item = ways.First();
                ways.RemoveAt(0);

                analyse(item.Item1, item.Item2, item.Item3);
            }

            return results.Any() ? results.Min() : -1;

            void analyse(int x, int y, int count)
            {
                if (x == n - 1 && y == n - 1)
                {
                    results.Add(count);
                    return;
                }

                if (x < n - 1 && y < n - 1 && visited[x + 1][y + 1] < 8 && grid[x + 1][y + 1] == 0)
                {
                    ways.Add((x + 1, y + 1, count + 1));
                    visited[x + 1][y + 1] += 1;
                }

                if (x < n - 1 && visited[x + 1][y] < 8 && grid[x + 1][y] == 0)
                {
                    ways.Add((x + 1, y, count + 1));
                    visited[x + 1][y] += 1;
                }

                if (y < n - 1 && visited[x][y + 1] < 8 && grid[x][y + 1] == 0)
                {
                    ways.Add((x, y + 1, count + 1));
                    visited[x][y + 1] += 1;
                }

                if (x > 0 && y < n - 1 && visited[x - 1][y + 1] < 8 && grid[x - 1][y + 1] == 0)
                {
                    ways.Add((x - 1, y + 1, count + 1));
                    visited[x - 1][y + 1] += 1;
                }

                if (y > 0 && visited[x][y - 1] < 8 && grid[x][y - 1] == 0)
                {
                    ways.Add((x, y - 1, count + 1));
                    visited[x][y - 1] += 1;
                }

                if (y > 0 && x < n - 1 && visited[x + 1][y - 1] < 8 && grid[x + 1][y - 1] == 0)
                {
                    ways.Add((x + 1, y - 1, count + 1));
                    visited[x + 1][y - 1] += 1;
                }

                if (x > 0 && visited[x - 1][y] < 8 && grid[x - 1][y] == 0)
                {
                    ways.Add((x - 1, y, count + 1));
                    visited[x - 1][y] += 1;
                }

                if (x > 0 && y > 0 && visited[x - 1][y - 1] < 8 && grid[x - 1][y - 1] == 0)
                {
                    ways.Add((x - 1, y - 1, count + 1));
                    visited[x - 1][y - 1] += 1;
                }
            }
        }

    }
}
