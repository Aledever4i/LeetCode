using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class _100_199
    {
        /// <summary>
        /// 118. Pascal's Triangle. Tags: Array, Dynamic Programming
        /// </summary>
        public static IList<IList<int>> Generate(int numRows)
        {
            var result = new List<IList<int>>();

            result.Add(new List<int>() { 1 });

            if (numRows == 1)
            {
                return result;
            }

            result.Add(new List<int>() { 1, 1 });

            if (numRows == 2)
            {
                return result;
            }

            for (int i = 2; i < numRows; i++)
            {
                var values = new List<int>();

                for (int j = 0; j < i + 1; j++)
                {
                    if (j == 0 || j == i)
                    {
                        values.Add(1);
                    }
                    else
                    {
                        values.Add(result[i - 1][j - 1] + result[i - 1][j]);
                    }
                }

                result.Add(values);
            }

            return result;
        }

        /// <summary>
        /// 119. Pascal's Triangle II. Tags: Array, Dynamic Programming
        /// </summary>
        public static IList<int> GenerateRow(int rowIndex)
        {
            var result = new List<IList<int>>();

            result.Add(new List<int>() { 1 });

            if (rowIndex == 0)
            {
                return result.ElementAt(rowIndex);
            }

            result.Add(new List<int>() { 1, 1 });

            if (rowIndex == 1)
            {
                return result.ElementAt(rowIndex);
            }

            for (int i = 2; i < rowIndex + 1; i++)
            {
                var values = new List<int>();

                for (int j = 0; j < i + 1; j++)
                {
                    if (j == 0 || j == i)
                    {
                        values.Add(1);
                    }
                    else
                    {
                        values.Add(result[i - 1][j - 1] + result[i - 1][j]);
                    }
                }

                result.Add(values);
            }

            return result.ElementAt(rowIndex);
        }

        /// <summary>
        /// 121. Best Time to Buy and Sell Stock. Tags: Array, Dynamic Programming
        /// </summary>
        /// [7,1,5,3,6,4]
        /// [7,6,4,3,1]
        public static int MaxProfit1(int[] prices)
        {
            var n = prices.Length;
            if (n == 1)
            {
                return 0;
            }

            int[][] values = new int[n][];

            for (int i = 0; i < n; i++)
            {
                var price = prices[i];

                values[i] = new int[] { price };
            }
            return 0;
        }

        /// <summary>
        /// 125. Valid Palindrome
        /// </summary>
        public static bool IsPalindrome(string s)
        {
            var rgx = new System.Text.RegularExpressions.Regex("[^a-zA-Z0-9]");
            s = rgx.Replace(s, "").ToLower();

            int start = 0, end = s.Length;

            while (start < end)
            {
                if (s[start] != s[end - 1])
                {
                    return false;
                }

                start++;
                end--;
            }

            return true;
        }

        /// <summary>
        /// 136. Single Number. Tags: Array, Bit Manipulation
        /// </summary>
        public static int SingleNumber(int[] nums)
        {
            var array = new Dictionary<int, bool>();

            foreach (var num in nums)
            {
                if (!array.TryAdd(num, true))
                {
                    array[num] = false;
                } 
            }

            foreach (var item in array)
            {
                if (item.Value == true)
                {
                    return item.Key;
                }
            }

            return 0;
        }

        /// <summary>
        /// 172. Factorial Trailing Zeroes. Tags: Math
        /// </summary>
        public static int TrailingZeroes(int n)
        {
            int multi = 5;
            int k = 1 * multi;
            int counter = 0;

            while (n / k != 0)
            {
                counter += n / k;
                k *= multi;
            }
            return counter;
        }

        /// <summary>
        /// 189. Rotate Array. Tags: Array, Math, Two Pointers
        /// </summary>
        public static void Rotate(int[] nums, int k)
        {
            var n = nums.Length;
            while (k >= n)
            {
                k -= n;
            }

            if (k == 0)
            {
                return;
            }

            var list = new List<int>();
            list.AddRange(nums[(n - k)..]);
            list.AddRange(nums[..(n - k)]);

            for (int i = 0; i < n; i++)
            {
                nums[i] = list.ElementAt(i);
            }
        }
    }
}
