﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class _2400_2499
    {
        /// <summary>
        /// 2448. Minimum Cost to Make Array Equal. Tags: Array, Binary Search, Greedy, Sorting, Prefix Sum
        /// </summary>
        public static long MinCost(int[] nums, int[] cost)
        {
            long getCost(int[] nums, int[] cost, int b) {
                long result = 0;
                for (int i = 0; i < nums.Length; ++i)
                {
                    result += 1L * Math.Abs(nums[i] - b) * cost[i];
                }    
                return result;
            }

            long answer = getCost(nums, cost, nums[0]);
            int left = nums.Min();
            int right = nums.Max();

            while (left < right)
            {
                int mid = (left + right) / 2;

                long cost1 = getCost(nums, cost, mid);
                long cost2 = getCost(nums, cost, mid + 1);

                answer = Math.Min(cost1, cost2);

                if (cost1 > cost2)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return answer;

            //var dict = new Dictionary<(int, int), ulong>();
            //var uniqueValues = nums.Distinct();
            //ulong minCost = ulong.MaxValue;
            //ulong currentSum = 0;

            //for (int i = 0; i < nums.Length; i++)
            //{
            //    dict.Add((nums[i], i), Convert.ToUInt64(cost[i]));
            //}

            //var array = dict.OrderByDescending(value => value.Value).ToArray();

            //foreach (var value in uniqueValues.OrderByDescending(value => value))
            //{
            //    foreach (var element in array)
            //    {
            //        currentSum += Convert.ToUInt64((Math.Abs(element.Key.Item1 - value))) * element.Value;

            //        if (currentSum >= minCost)
            //        {
            //            break;
            //        }
            //    }

            //    minCost = Math.Min(minCost, currentSum);
            //    currentSum = 0;
            //}

            //return Convert.ToInt64(minCost);

            //var dict = new (int, int)[nums.Length];
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    dict[i] = (nums[i], cost[i]);
            //}

            //var sortedArray = dict.OrderBy(x => x.Item1).ToArray();

            //long[] prefixCost = new long[nums.Length];
            //prefixCost[0] = sortedArray[0].Item2;

            //for (int i = 1; i < nums.Length; i++)
            //{
            //    prefixCost[i] = 1l * sortedArray[0].Item2 + prefixCost[i - 1];
            //}

            //long totalCost = 0;
            //for (int i = 1; i < nums.Length; i++)
            //{
            //    totalCost += 1l * sortedArray[i].Item2 * (sortedArray[i].Item1 - sortedArray[0].Item1);
            //}

            //long answer = totalCost;

            //for (int i = 1; i < nums.Length; i++)
            //{
            //    int gap = sortedArray[i].Item1 - sortedArray[i - 1].Item1;
            //    totalCost += 1l * prefixCost[i - 1] * gap;
            //    totalCost -= 1l * (prefixCost[nums.Length - 1] - prefixCost[i - 1]) * gap;
            //    answer = Math.Min(answer, totalCost);
            //}

            //return answer;
        }
    }
}
