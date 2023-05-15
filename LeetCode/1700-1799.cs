using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class _1700_1799
    {
        /// <summary>
        /// 1799. Maximize Score After N Operations. Tags: Array, Math, Dynamic Programming, Backtracking, Bit Manipulation, Number Theory, Bitmask
        /// </summary>
        /// <param name="nums"></param>
        /// TODO: Изучить тему с рекурсией и битовыми масками
        public static int MaxScore(int[] nums)
        {
            Dictionary<string, int> dp = new Dictionary<string, int>();
            Dictionary<string, int> cache = new Dictionary<string, int>();
            return Util(nums, new bool[nums.Length], nums.Length / 2);

            int GCD(int num1, int num2)
            {
                int Remainder;
                while (num2 != 0)
                {
                    Remainder = num1 % num2;
                    num1 = num2;
                    num2 = Remainder;
                }
                return num1;
            }

            int Util(int[] arr, bool[] taken, int operations)

            {

                if (operations == 0)

                {

                    return 0;

                }

                string key = string.Join(",", taken.Select(b => b ? "1" : "0")) + "|" + operations;

                if (dp.ContainsKey(key))

                {

                    return dp[key];

                }

                int max = int.MinValue;

                for (int i = 0; i < arr.Length; i++)

                {

                    for (int j = i + 1; j < arr.Length; j++)

                    {

                        if (!taken[i] && !taken[j])

                        {

                            taken[i] = taken[j] = true;



                            var gcdKey = $"{arr[i]}|{arr[j]}";

                            if (!cache.TryGetValue(gcdKey, out int gcdValue))

                            {

                                gcdValue = GCD(arr[i], arr[j]);

                                cache.Add(gcdKey, gcdValue);

                            }



                            int val = (operations * gcdValue) + Util(arr, taken, operations - 1);

                            max = Math.Max(max, val);

                            taken[i] = taken[j] = false;

                        }

                    }

                }

                dp[key] = max;

                return max;

            }

        }
    }
}