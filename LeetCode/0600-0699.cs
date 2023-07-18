using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class _0600_0699
    {
        /// <summary>
        /// 643. Maximum Average Subarray I. Tags: Array, Sliding Window
        /// </summary>
        public static double FindMaxAverage(int[] nums, int k)
        {
            var n = nums.Length;

            double windowValue = 0;
            for (int i = 0; i < k; i++)
            {
                windowValue += nums[i];
            }
            double maxValue = windowValue;

            for (int i = k; i < n; i++)
            {
                windowValue += nums[i] - nums[i - k];
                maxValue = Math.Max(maxValue, windowValue);
            }

            return maxValue / k;
        }
    }
}
