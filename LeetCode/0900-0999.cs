﻿using System.Collections.Generic;

namespace LeetCode
{
    public static class _0900_0999
    {
        /// <summary>
        /// 905. Sort Array By Parity
        /// </summary>
        public static int[] SortArrayByParity(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;

            var result = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                var value = nums[i];

                if (value % 2 == 0)
                {
                    result[left] = value;
                    left++;
                }
                else
                {
                    result[right] = value;
                    right--;
                }
            }

            return result;
        }


        /// <summary>
        /// 934. Shortest Bridge. Tags: Array, Depth-First Search, Breadth-First Search, Matrix
        /// </summary>
        public static int ShortestBridge(int[][] grid)
        {
            int[][] dirs = {
                new int[] { 0, -1 },
                new int[] { -1, 0 },
                new int[] { 0, 1 },
                new int[] { 1, 0 }
            };

            return 1;
        }

        /// <summary>
        /// 956. Tallest Billboard. Tags: Array, Dynamic Programming
        /// </summary>
        public static int TallestBillboard(int[] rods)
        {
            return 0;
        }
    }
}
