using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Contest
{
    public static class _370
    {
        public static int FindChampion1(int[][] grid)
        {
            var n = grid.Length;

            var maxWin = 0;
            var curIndex = 0;

            for (int i = 0; i < n; i++)
            {
                var row = grid[i];

                var wins = row.Sum();

                if (wins > maxWin)
                {
                    maxWin = wins;
                    curIndex = i;
                }
            }

            return curIndex;
        }

        public static int FindChampion2(int n, int[][] edges)
        {
            if (n == 1)
            {
                return 0;
            }

            var hash = new HashSet<int>();
            foreach (var edge in edges)
            {
                hash.Add(edge[1]);
            }

            var teams = Enumerable.Range(0, n).Except(hash);
            return (teams.Count() > 1) ? -1 : teams.ElementAt(0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="edges"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static long MaximumScoreAfterOperations(int[][] edges, int[] values)
        {


            return 0;
        }


        public static long MaxBalancedSubsequenceSum(int[] nums)
        {
            var n = nums.Length;
            var dict = new Dictionary<int, int>() { { int.MinValue, 0 } };

            //for (int i = 0; i < n; i++)
            //{
            //    var value = nums[i];

            //    if (value > 0)
            //    {
            //        var p = InternalBisectRight(nums, value, 0, n);

            //        dict.Add(p, )
            //    }
            //}

            return 0;

            int InternalBisectRight(IDictionary<int, int> list, int item, int lo, int hi)
            {
                object litem;
                int mid;

                while (lo < hi)
                {
                    mid = (lo + hi) / 2;
                    if (item.CompareTo(list[mid]) < 0)
                    {
                        hi = mid;
                    }
                    else
                    {
                        lo = mid + 1;
                    }
                }

                return lo;
            }
        }
    }
}
