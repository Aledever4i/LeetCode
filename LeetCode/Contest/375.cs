using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Contest
{
    public static class _375
    {
        public static int CountTestedDevices(int[] batteryPercentages)
        {
            int result = 0;

            foreach (int percent in batteryPercentages)
            {
                if (percent > result)
                {
                    result++;
                }
            }

            return result;
        }


        public static IList<int> GetGoodIndices(int[][] variables, int target)
        {
            var n = variables.Length;
            var indicates = new List<int>();

            for (int i = 0; i < n; i++)
            {
                var value = variables[i];
                var ab = modular_pow(value[0], value[1], 10);
                var abcm = modular_pow(ab, value[2], value[3]);
                if (abcm == target)
                {
                    indicates.Add(i);
                }
            }

            int modular_pow(int foundation, int exponent, int modulus)
            {
                if (modulus == 1)
                {
                    return 0;
                }

                double ans = 1;

                for (int i = 0; i < exponent; i++)
                {
                    ans = ans * foundation % modulus;
                }

                return (int)ans;
            }

            return indicates;
        }


        public static long CountSubarrays(int[] nums, int k)
        {
            var maxElement = nums.Max();
            var n = nums.Length;

            double lessThanK(int[] nums, int k, int maxElement)
            {
                int ans = 0;
                int valid = 0;

                for (int i = 0, j = 0; j < n; j++)
                {
                    int c = nums[j];
                    if (c == maxElement)
                    {
                        valid++;
                    }

                    while (i <= j && valid >= k)
                    {
                        int d = nums[i++];
                        if (d == maxElement) {
                            valid--;
                        }
                    }

                    if (valid < k)
                    {
                        ans += j - i + 1;
                    }
                }

                return ans;
            }

            return (int)(1.0 * (n) * (n + 1) / 2 - lessThanK(nums, k, maxElement));
        }
    }
}
