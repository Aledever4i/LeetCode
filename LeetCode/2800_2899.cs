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
    }
}
