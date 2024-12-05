using LeetCode.Algorithms;
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
        /// 2328. Number of Increasing Paths in a Grid
        /// </summary>
        public static int CountPaths(int[][] grid)
        {
            int[][] directions = new int[4][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };
            int m = grid.Length, n = grid[0].Length;
            int mod = 1_000_000_007;

            int[][] dp = new int[m][];
            for (int i = 0; i < m; i++)
            {
                dp[i]= new int[n];
                for (int y = 0; y < n; y++)
                {
                    dp[i][y] = 1;
                }
            }

            int[][] cellList = new int[m * n][];
            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    int index = i * n + j;

                    cellList[index] = new int[] { i, j };
                }
            }

            System.Array.Sort(cellList, (x, y) => grid[x[0]][x[1]] - grid[y[0]][y[1]]);

            foreach (var cell in cellList)
            {
                int i = cell[0], j = cell[1];

                foreach (var d in directions)
                {
                    int currI = i + d[0], currJ = j + d[1];

                    if (
                        currI >= 0
                        && currI < m
                        && currJ >= 0
                        && currJ < n
                        && grid[currI][currJ] > grid[i][j]
                    )
                    {
                        dp[currI][currJ] += dp[i][j];
                        dp[currI][currJ] %= mod;
                    }
                }
            }

            int answer = 0;
            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    answer += dp[i][j];
                    answer %= mod;
                }
            }
            return answer;
        }

        /// <summary>
        /// 2337. Move Pieces to Obtain a String
        /// </summary>
        public static bool CanChange(string start, string target)
        {
            var queue = new Queue<(char c, int index)>();
            for (int i = 0; i < start.Length; i++)
            {
                var c = start[i];
                if (c == 'L' || c == 'R')
                {
                    queue.Enqueue((c, i));
                }
            }

            for (int i = 0; i < target.Length; i++)
            {
                var c = target[i];
                if (c == 'L' || c == 'R')
                {
                    if (queue.Count == 0)
                    {
                        return false;
                    }

                    var element = queue.Dequeue();

                    if (c == 'L' && element.c == 'L' && i > element.index)
                    {
                        return false;
                    }

                    if (c == 'R' && element.c == 'R' && i < element.index)
                    {
                        return false;
                    }

                    if (c != element.c)
                    {
                        return false;
                    }
                }
            }

            if (queue.Count > 0)
            {
                return false;
            }

            return true;
        }

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

        /// <summary>
        /// 2385. Amount of Time for Binary Tree to Be Infected
        /// </summary>
        public static int AmountOfTime(TreeNode root, int start)
        {
            var graph = new Dictionary<int, List<int>>();
            var visited = new HashSet<int>();

            var wayQueue = new Queue<(TreeNode, TreeNode)>();
            wayQueue.Enqueue((root, root.left));
            wayQueue.Enqueue((root, root.right));
            while (wayQueue.Count > 0)
            {
                var e = wayQueue.Dequeue();
                if (e.Item2 != null)
                {
                    if (!graph.TryAdd(e.Item1.val, new List<int>() { e.Item2.val }))
                    {
                        graph[e.Item1.val].Add(e.Item2.val);
                    }

                    if (!graph.TryAdd(e.Item2.val, new List<int>() { e.Item1.val }))
                    {
                        graph[e.Item2.val].Add(e.Item1.val);
                    }

                    if (e.Item2.left != null)
                    {
                        wayQueue.Enqueue((e.Item2, e.Item2.left));
                    }
                    if (e.Item2.right != null)
                    {
                        wayQueue.Enqueue((e.Item2, e.Item2.right));
                    }
                }
            }

            if (graph.Count == 0)
            {
                return 0;
            }

            var queue = new Queue<(int, int)>();
            var ways = graph[start];
            visited.Add(start);
            var result = 0;
            foreach (var way in ways)
            {
                queue.Enqueue((way, 1));
            }

            while (queue.Count > 0)
            {
                var way = queue.Dequeue();
                result = Math.Max(result, way.Item2);
                visited.Add(way.Item1);
                var newWays = graph[way.Item1];
                foreach (var newWay in newWays)
                {
                    if (!visited.Contains(newWay))
                    {
                        queue.Enqueue((newWay, way.Item2 + 1));
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 2392. Build a Matrix With Conditions
        /// </summary>
        public static int[][] BuildMatrix(int k, int[][] rowConditions, int[][] colConditions)
        {
            var rowDict = new Dictionary<int, List<int>>(k);
            for (int i = 1; i <= k; i++)
            {
                rowDict.Add(i, new List<int>());
            }

            var colDict = new Dictionary<int, List<int>>(k);
            for (int i = 1; i <= k; i++)
            {
                colDict.Add(i, new List<int>());
            }

            foreach (var rCond in rowConditions)
            {
                rowDict[rCond[0]].Add(rCond[1]);
            }
            foreach (var cCond in colConditions)
            {
                colDict[cCond[0]].Add(cCond[1]);
            }

            var rowList = new List<int>();
            if (!Sorting.TopologicalSort(rowDict, 1, k, rowList))
            {
                return new List<int[]>().ToArray();
            }
            var rowOrder = new Dictionary<int, int>(rowList.Select((v, i) => new KeyValuePair<int, int>(v, i)));

            var colList = new List<int>();
            if (!Sorting.TopologicalSort(colDict, 1, k, colList))
            {
                return new List<int[]>().ToArray();

            }
            var colOrder = new Dictionary<int, int>(colList.Select((v, i) => new KeyValuePair<int, int>(v, i)));

            var result = new int[k][];
            for (int i = 0; i < k; i++)
            {
                result[i] = new int[k];
            }
            for (int i = 1; i <= k; i++)
            {
                result[rowOrder[i]][colOrder[i]] = i;
            }

            return result;
        }
    }
}
