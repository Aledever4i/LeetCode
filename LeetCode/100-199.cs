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
        public static int MaxProfit1(int[] prices)
        {
            var n = prices.Length;
            if (n == 1)
            {
                return 0;
            }

            int[] values = new int[n];

            int[] maxValues = new int[n];
            var currentMaxValue = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                var price = prices[i];
                currentMaxValue = Math.Max(price, currentMaxValue);
                maxValues[i] = currentMaxValue;
            }

            for (int i = 0; i < n - 1; i++)
            {
                values[i] = maxValues[i + 1] - prices[i];
            }
            
            return values.Max();
        }

        /// <summary>
        /// 122. Best Time to Buy and Sell Stock II. Tags: Array, Dynamic Programming, Greedy
        /// </summary>
        public static int MaxProfit2(int[] prices)
        {
            var n = prices.Length;
            if (n == 1)
            {
                return 0;
            }

            var dp = new int[n + 1][];
            for (int i = 0; i < n + 1; i++)
            {
                dp[i] = new int[2];

                for (int j = 0; j < 2; j++)
                {
                    dp[i][j] = 0;
                }
            }

            for (int i = n - 1; i >= 0; i--)
            {
                for (int buy = 0; buy < 2; buy++)
                {
                    if (buy == 1)
                    {
                        dp[i][1] = Math.Max(-prices[i] + dp[i + 1][0], dp[i + 1][1]);
                    }
                    else
                    {
                        dp[i][0] = Math.Max(prices[i] + dp[i + 1][1], dp[i + 1][0]);
                    }
                }
            }

            return dp[0][1];
        }

        /// <summary>
        /// 123. Best Time to Buy and Sell Stock III. Tags: Array, Dynamic Programming
        /// </summary>
        public static int MaxProfit3(int[] prices)
        {
            int n = prices.Length;
            if (n <= 1)
            {
                return 0;
            }

            int[] left = new int[n];
            int[] right = new int[n];

            int minLeft = prices[0];
            for (int i = 1; i < n; i++)
            {
                minLeft = Math.Min(minLeft, prices[i]);
                left[i] = Math.Max(left[i - 1], prices[i] - minLeft);
            }

            int maxRight = prices[n - 1];
            for (int i = n - 2; i >= 0; i--)
            {
                maxRight = Math.Max(maxRight, prices[i]);
                right[i] = Math.Max(right[i + 1], maxRight - prices[i]);
            }

            int maxProfit = 0;
            for (int i = 0; i < n; i++)
            {
                maxProfit = Math.Max(maxProfit, left[i] + right[i]);
            }

            return maxProfit;
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
