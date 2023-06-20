using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class _1400_1499
    {
        /// <summary>
        /// 1480. Running Sum of 1d Array. Tags: Array, Sliding Window
        /// </summary>
        public static int[] RunningSum(int[] nums)
        {
            var result = new int[nums.Length];
            var windowValue = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                windowValue += nums[i];
                result[i] = windowValue;
            }

            return result;
        }
    }
}
