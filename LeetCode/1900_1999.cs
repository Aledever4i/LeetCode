using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    public static class _1900_1999
    {
        /// <summary>
        /// 1903. Largest Odd Number in String
        /// </summary>
        public static string LargestOddNumber(string num)
        {
            return string.Empty;
        }

        /// <summary>
        /// 1921. Eliminate Maximum Number of Monsters
        /// </summary>
        public static int EliminateMaximum(int[] dist, int[] speed)
        {
            var result = 0;
            var n = dist.Length;

            var time = new double[n];
            for (int i = 0; i < n; i++)
            {
                time[i] = (1.0 * dist[i]) / (1.0 * speed[i]);
            }

            Array.Sort(time);

            for (int i = 0; i < n; i++)
            {
                if (time[i] <= i)
                {
                    break;
                }
                result++;
            }

            return result;
        }

        /// <summary>
        /// 1945. Sum of Digits of String After Convert
        /// </summary>
        public static int GetLucky(string s, int k)
        {
            var numbers = string.Join("", s.Select(x => x - 'a' + 1));

            while (k-- > 0)
            {
                numbers = numbers.Sum(x => (decimal)(x -'0')).ToString();
            }

            return int.Parse(numbers);
        }

        /// <summary>
        /// 1980. Find Unique Binary String
        /// </summary>
        public static string FindDifferentBinaryString(string[] nums)
        {
            var value = nums[0];
            var hash = new HashSet<int>();
            var count = Math.Pow(2, value.Length);

            foreach (var item in nums)
            {
                hash.Add(Convert.ToInt32(item, 2));
            }

            foreach (var x in Enumerable.Range(0, (int)count))
            {
                if (hash.Add(x))
                {
                    var binary = Convert.ToString(x, 2);

                    return new string('0', value.Length - binary.Length) + binary;
                }
            }

            return "";
        }
    }
}
