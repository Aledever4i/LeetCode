using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class _2800_2899
    {
        /// <summary>
        /// 2815. Max Pair Sum in an Array
        /// </summary>
        public static int MaxSum(int[] nums)
        {
            var result = -1;
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < 10; i++)
            {
                dict.Add(i, 0);
            }

            var hash = new HashSet<int>();
            foreach (var x in nums)
            {
                var maxValue = GetMaxDigit(x);

                if (dict[maxValue] > 0)
                {
                    result = Math.Max(result, x + dict[maxValue]);
                }

                dict[maxValue] = Math.Max(dict[maxValue], x);
            }

            return result;

            int GetMaxDigit(int n)
            {
                var max = n % 10;

                for (n /= 10; n > 0; n /= 10) max = Math.Max(max, n % 10);

                return max;
            }
        }

        /// <summary>
        /// 2849. Determine if a Cell Is Reachable at a Given Time
        /// </summary>
        public static bool IsReachableAtTime(int sx, int sy, int fx, int fy, int t)
        {
            if (sx == fx && sy == fy && t == 1)
            {
                return false;
            }

            return Math.Max(Math.Abs(sx - fx), Math.Abs(sy - fy)) <= t;
        }

        /// <summary>
        /// 2870. Minimum Number of Operations to Make Array Empty
        /// </summary>
        public static int MinOperations(int[] nums)
        {
            var dict = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                if (!dict.TryAdd(num, 1))
                {
                    dict[num]++;
                }
            }

            if (dict.Values.Any(x => x == 1))
            {
                return -1;
            }

            var result = 0;

            foreach (var value in dict.Values)
            {
                if (value == 2)
                {
                    result++;
                }
                else
                {
                    result += (value / 3) + ((value % 3 > 0) ? 1 : 0);
                }
            }

            return result;
        }

        /// <summary>
        /// 2873. Maximum Value of an Ordered Triplet I
        /// </summary>
        public static long MaximumTripletValue(int[] nums)
        {
            var n = nums.Length;
            var result = 0;

            if (n == 3)
            {
                result = (nums[0] - nums[1]) * nums[2];
            }
            else
            {
                var stack = new Stack<int>();
                int[] min = new int[n];

                min[0] = nums[0];
                for (int i = 1; i < n; i++)
                {
                    min[i] = Math.Min(min[i - 1], nums[i]);
                }
                for (int j = n - 1; j >= 0; j--)
                {
                    if (nums[j] > min[j])
                    {
                        while (stack.Count > 0 && stack.Peek() <= min[j])
                        {
                            stack.Pop();

                        }
                        if (stack.Count > 0 && stack.Peek() < nums[j])
                        {
                            return 0;
                        }

                        stack.Push(nums[j]);
                    }
                }

            }



            return (result < 0) ? 0 : result;
        }
    }
}
