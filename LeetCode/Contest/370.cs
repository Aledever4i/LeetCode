using System;
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
            var dp = new Dictionary<(int, int), long>();

            for (int i = 0; i < n; i++)
            {
                var value = nums[i];
                getBalance(nums, i, i);
            }

            long getBalance(int[] nums, int lastIndex, int positionId)
            {
                if (dp.ContainsKey((lastIndex, positionId)))
                {
                    return dp[(lastIndex, positionId)];
                }

                if (positionId >= n)
                {
                    return dp[(lastIndex, positionId)] = int.MinValue;
                }

                var currValue = nums[positionId];
                var lastValue = nums[lastIndex];

                if (currValue < 0)
                {
                    dp[(lastIndex, positionId)] = getBalance(nums, lastIndex, positionId + 1);
                }
                else if (lastIndex == positionId)
                {
                    dp[(lastIndex, positionId)] = currValue + Math.Max(getBalance(nums, positionId, positionId + 1), 0);
                }
                else if (currValue - lastValue >= positionId - lastIndex)
                {
                    if (currValue - lastValue == positionId - lastIndex)
                    {
                        dp[(lastIndex, positionId)] = currValue + Math.Max(getBalance(nums, positionId, positionId + 1), 0);
                    }
                    else
                    {
                        dp[(lastIndex, positionId)] = Math.Max(currValue + Math.Max(getBalance(nums, positionId, positionId + 1), 0), Math.Max(getBalance(nums, lastIndex, positionId + 1), 0));
                    }
                }
                else
                {
                    dp[(lastIndex, positionId)] = Math.Max(getBalance(nums, lastIndex, positionId + 1), 0);
                }

                return dp[(lastIndex, positionId)];
            }

            return Math.Max(dp.Where(val => val.Key.Item1 == val.Key.Item2).Select(v => v.Value).DefaultIfEmpty(long.MinValue).Max(), nums.Max());
        }
    }
}
