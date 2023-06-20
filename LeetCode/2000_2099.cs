﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class _2000_2099
    {
        /// <summary>
        /// 2090. K Radius Subarray Averages. Tags: Array, Sliding Window
        /// </summary>
        public static int[] GetAverages(int[] nums, int k)
        {
            var n = nums.Length;
            if (2 * k >= n)
            {
                System.Array.Fill(nums, -1);
                return nums;
            }

            var decimals = new int[n];
            System.Array.Fill(decimals, -1);

            decimal currentWindowValue = 0.0M;

            for (int i = 0; i < n; i++)
            {
                currentWindowValue += nums[i];

                if (i >= 2 * k + 1)
                {
                    currentWindowValue -= nums[i - ((2 * k) + 1)];
                }

                if (i - (2 * k) >= 0)
                {
                    decimals[i - k] = Convert.ToInt32(currentWindowValue / (2 * k + 1));
                }
            }

            return decimals;
        }
    }
}