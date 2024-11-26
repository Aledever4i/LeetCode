using LeetCode.Contest.Transfered;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class _2900_2999
    {
        /// <summary>
        /// 2914. Minimum Number of Changes to Make Binary String Beautiful
        /// </summary>
        public static int MinChanges(string s)
        {
            var currentNumber = s[0];
            var currentCount = 1;
            var result = 0;

            for (var i = 1; i < s.Length; i++)
            {
                if (currentNumber == s[i])
                {
                    currentCount++;
                    continue;
                }

                if (currentCount % 2 == 1)
                {
                    currentCount++;
                    result++;
                }
                else
                {
                    currentNumber = s[i];
                    currentCount = 1;
                }
            }

            return result;
        }

        /// <summary>
        /// 2924. Find Champion II
        /// </summary>
        public static int FindChampion(int n, int[][] edges)
        {
            if (n == 1)
            {
                return 0;
            }

            var winners = new List<int>();
            for (var i = 0; i < n; i++)
            {
                winners.Add(i);
            }

            var losers = edges.Select(edge => edge[1]);
            var bests = winners.Except(losers);

            return bests.Count() > 1 || !bests.Any() ? -1 : bests.First();
        }

        /// <summary>
        /// 2958. Length of Longest Subarray With at Most K Frequency
        /// </summary>
        public static int MaxSubarrayLength(int[] nums, int k)
        {
            int left = 0, right = 0;
            var n = nums.Length;
            var occurs = new Dictionary<int, int>();
            var result = 0;

            while (right < n)
            {
                var x = nums[right];
                if (!occurs.TryAdd(x, 1))
                {
                    occurs[x]++;

                    if (occurs[x] > k)
                    {
                        while (nums[left] != x)
                        {
                            occurs[nums[left]]--;
                            left++;
                        }

                        occurs[nums[left]]--;
                        left++;
                    }
                }

                result = Math.Max(result, right - left + 1);
                right++;
            }

            return result;
        }

        /// <summary>
        /// 2966. Divide Array Into Arrays With Max Difference
        /// </summary>
        public static int[][] DivideArray(int[] nums, int k)
        {
            var n = nums.Length;
            if (n % 3 != 0)
            {
                return Array.Empty<int[]>();
            }

            Array.Sort(nums);
            var result = new int[n / 3][];

            for (int i = 0; i < n / 3; i++)
            {
                var n1 = nums[i * 3];
                var n2 = nums[i * 3 + 1];
                var n3 = nums[i * 3 + 2];

                if (n3 - n1 > k)
                {
                    return Array.Empty<int[]>();
                }

                result[i] = new int[] { n1, n2, n3 };
            }

            return result;
        }

        /// <summary>
        /// 2971. Find Polygon With the Largest Perimeter
        /// </summary>
        public static long LargestPerimeter(int[] nums)
        {
            Array.Sort(nums);
            var index = nums.Length - 1;
            long prefix = nums.Sum(v => (long)v) - nums[index];
            long suffix = nums[index];

            while (prefix <= suffix && index >= 0)
            {
                index--;

                if (index < 0)
                {
                    break;
                }

                suffix = nums[index];
                prefix = prefix - suffix;
            }

            if (index < 0)
            {
                return -1;
            }
            else
            {
                return suffix + prefix;
            }
        }

        /// <summary>
        /// 2980. Check if Bitwise OR Has Trailing Zeros
        /// </summary>
        public static bool HasTrailingZeros(int[] nums)
        {
            return _378.HasTrailingZeros(nums);
        }

        /// <summary>
        /// 2981. Find Longest Special Substring That Occurs Thrice I
        /// </summary>
        public static int MaximumLength(string s)
        {
            return _378.MaximumLength(s);
        }

        /// <summary>
        /// 2982. Find Longest Special Substring That Occurs Thrice II
        /// </summary>
        public static int MaximumLength2(string s)
        {
            return _378.MaximumLength(s);
        }
    }
}
