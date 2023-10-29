using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Contest
{
    public static class _369
    {
        /// <summary>
        /// 2917. Find the K-or of an Array
        /// </summary>
        public static int FindKOr(int[] nums, int k)
        {
            var n = nums.Length;
            var dict = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                var number = Convert.ToString(nums[i], 2);
                for (int j = 0; j < number.Length; j++)
                {
                    if (number[number.Length - 1 - j] == '1')
                    {
                        if (!dict.TryAdd(j, 1))
                        {
                            dict[j]++;
                        }
                    }
                }
            }

            return (int)dict.Where(val => val.Value >= k).Select(val => Math.Pow(2, val.Key)).Sum();
        }

        /// <summary>
        /// 2918. Minimum Equal Sum of Two Arrays After Replacing Zeros
        /// </summary>
        public static long MinSum(int[] nums1, int[] nums2)
        {
            long nums1Sum = 0;
            long nums1Zeros = 0;
            long nums2Sum = 0;
            long nums2Zeros = 0;

            foreach (long n in nums1)
            {
                nums1Sum += n;
                if (n == 0)
                {
                    nums1Zeros++;
                }
            }

            foreach (long n in nums2)
            {
                nums2Sum += n;
                if (n == 0)
                {
                    nums2Zeros++;
                }
            }

            var diff = nums1Sum - nums2Sum;
            if (diff + nums1Zeros > 0 && nums2Zeros == 0)
            {
                return -1;
            }
            if (diff - nums2Zeros < 0 && nums1Zeros == 0)
            {
                return -1;
            }

            if (diff == 0)
            {
                return Math.Min(nums1Sum, nums2Sum) + Math.Max(nums1Zeros, nums2Zeros);
            }

            if (nums1Sum + nums1Zeros >= nums2Sum + nums2Zeros)
            {
                return nums1Sum + nums1Zeros;
            }
            else
            {
                return nums2Sum + nums2Zeros;
            }
        }


        public static long MinIncrementOperations(int[] nums, int k)
        {
            var n = nums.Length;
            var dp = new int[n];

            for (int i = 0; i < n - k; i++)
            {

            }

            return 0;

            int CheckMin(int[] nums, int index)
            {
                return 0;
            }
        }
    }
}
