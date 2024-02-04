using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Contest
{
    public static class B123
    {
        public static string TriangleType(int[] nums)
        {
            var n0 = nums[0];
            var n1 = nums[1];
            var n2 = nums[2];

            if (n0 == n1 && n1 == n2)
            {
                return "equilateral";
            }

            if (n0 + n1 <= n2 || n1 + n2 <= n0 || n0 + n2 <= n1)
            {
                return "none";
            }

            if (n0 == n1 || n1 == n2 || n0 == n2)
            {
                return "isosceles";
            }

            return "scalene";
        }


        public static long MaximumSubarraySum(int[] nums, int k)
        {
            var dict = nums.Select((n, index) => new { Number = n, Index = index }).GroupBy(n => n.Number).ToDictionary(n => n.Key, n => n.Select(x => x.Index).ToList());
            long result = int.MinValue;
            var longNums = new long[nums.Length];
            nums.CopyTo(longNums, 0);

            for (int i = 0; i < nums.Length; i++)
            {
                var value = longNums[i];
                if (dict.TryGetValue((int)value - k, out var indexs))
                {
                    foreach (var ind in indexs.Where(ix => ix > i))
                    {
                        result = Math.Max(result, longNums[i..(ind + 1)].Sum());
                    }
                }

                if (dict.TryGetValue((int)value + k, out indexs))
                {
                    foreach (var ind in indexs.Where(ix => ix > i))
                    {
                        result = Math.Max(result, longNums[i..(ind + 1)].Sum());
                    }
                }
            }

            return result == int.MinValue ? 0 : result;
        }
    }
}
