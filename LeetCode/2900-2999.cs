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
