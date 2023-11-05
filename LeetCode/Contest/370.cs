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

            getBalance(nums, -1, int.MinValue, 0);

            long getBalance(int[] nums, int lastIndex, long lastValue, int positionId)
            {
                if (positionId >= n)
                {
                    return 0;
                }

                if (dp.ContainsKey((lastIndex, positionId)))
                {
                    return dp[(lastIndex, positionId)];
                }
                    
                var currValue = nums[positionId];

                if (currValue < 0)
                {
                    dp[(lastIndex, positionId)] = getBalance(nums, lastIndex, lastValue, positionId + 1);
                }
                else if (currValue > lastValue)
                {
                    if (currValue - lastValue >= positionId - lastIndex)
                    {
                        dp[(lastIndex, positionId)] = currValue + getBalance(nums, positionId, currValue, positionId + 1);
                    }
                    else
                    {
                        dp[(lastIndex, positionId)] = getBalance(nums, positionId, currValue, positionId + 1);
                    }
                }
                else
                {
                    dp[(lastIndex, positionId)] = getBalance(nums, lastIndex, lastValue, positionId + 1);
                }

                return dp[(lastIndex, positionId)];
            }

            return Math.Max(dp.Where(val => val.Value != 0).Select(v => v.Value).DefaultIfEmpty(long.MinValue).Max(), nums.Max());
        }
    }
}
