using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class _100_199
    {
        /// <summary>
        /// 104. Maximum Depth of Binary Tree. Tags: Tree, Depth-First Search, Breadth-First Search, Binary Tree
        /// </summary>
        public static int MaxDepth(TreeNode root)
        {
            var result = 0;

            if (root == null)
            {
                return result;
            }

            getLevel(root, 1);

            return result;

            void getLevel(TreeNode root, int l)
            {
                result = Math.Max(result, l);

                if (root.right != null)
                {
                    getLevel(root.right, l + 1);
                }

                if (root.left != null)
                {
                    getLevel(root.left, l + 1);
                }
            }
        }

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
        /// 134. Gas Station
        /// </summary>
        public static int CanCompleteCircuit(int[] gas, int[] cost)
        {
            var n = gas.Length;
            var calculated = new int[n];

            for (int i = 0; i < n; i++)
            {
                calculated[i] = gas[i] - cost[i];
            }

            if (calculated.Sum() < 0)
            {
                return -1;
            }

            for (int i = 0; i < n; i++)
            {
                if (calculated[i] <= 0)
                {
                    continue;
                }

                var startValue = gas[i];
                for (int y = i; y < n + i; y++)
                {
                    var yIndex = y;
                    if (yIndex >= n)
                    {
                        yIndex -= n;
                    }

                    startValue -= cost[yIndex];
                    if (startValue < 0)
                    {
                        break;
                    }

                    yIndex += 1;
                    if (yIndex >= n)
                    {
                        yIndex -= n;
                    }

                    if (yIndex == i)
                    {
                        return i;
                    }

                    startValue += gas[yIndex]; 
                }
            }

            return 0;
        }

        /// <summary>
        /// 135. Candy
        /// </summary>
        public static int Candy(int[] ratings)
        {
            var n = ratings.Length;
            var changed = true;

            if (n == 1) { return 1; }

            while (changed)
            {
                changed = false;

                for (int i = 0; i < n - 1; i++)
                {
                    var value = ratings[i];

                    if (value - ratings[i + 1] > 1)
                    {
                        ratings[i] = value - 1;
                        changed = true;
                    }
                }
            }

            changed = true;
            while (changed)
            {
                changed = false;

                if (ratings[n - 1] - ratings[n - 2] > 1)
                {
                    ratings[n - 1] = ratings[n - 1] - 1;
                    changed = true;
                }
            }

            return ratings.Sum() + n;
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
        /// 137. Single Number II
        /// </summary>
        public static int SingleNumber3(int[] nums)
        {
            var array = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                if (!array.TryAdd(num, 1))
                {
                    array[num] = array[num] + 1;
                }
            }

            foreach (var item in array)
            {
                if (item.Value == 1)
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
        /// 188. Best Time to Buy and Sell Stock IV. Tags: Array, Dynamic Programming
        /// </summary>
        public static int MaxProfit(int k, int[] prices)
        {
            int length = prices.Length;
            var dp = new Dictionary<(int, int, int), int>();

            return processTransaction(0, 0, 1);

            int processTransaction(int i, int transactionId, int isBuy)
            {
                if (i >= length || transactionId > k)
                {
                    return 0;
                }

                if (!dp.ContainsKey((i, transactionId, isBuy)))
                {
                    if (isBuy == 1)
                    {
                        dp[(i, transactionId, isBuy)] = Math.Max(-prices[i] + processTransaction(i + 1, transactionId + 1, 0), processTransaction(i + 1, transactionId, 1));
                    }
                    else
                    {
                        dp[(i, transactionId, isBuy)] = Math.Max(prices[i] + processTransaction(i + 1, transactionId, 1), processTransaction(i + 1, transactionId, 0));
                    }

                }

                return dp[(i, transactionId, isBuy)];
            }
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

        /// <summary>
        /// 198. House Robber
        /// </summary>
        public static int Rob(int[] nums)
        {
            if (nums.Length == 1)
            {
                return nums[0];
            }
            else if (nums.Length == 1)
            {
                return Math.Max(nums[0], nums[1]);
            }

            var dp = new int[nums.Length][];
            for (int i = 0; i < nums.Length; i++)
            {
                dp[i] = new int[2];
            }

            dp[nums.Length - 1][0] = 0;
            dp[nums.Length - 1][1] = nums[nums.Length - 1];

            dp[nums.Length - 2][0] = nums[nums.Length - 1];
            dp[nums.Length - 2][1] = nums[nums.Length - 2];


            for (int i = nums.Length - 3; i >= 0; i--)
            {
                for (int y = 0; y < 2; y++)
                {
                    if (y == 0)
                    {
                        dp[i][0] = Math.Max(dp[i + 1][0], dp[i + 1][1]);
                    }
                    else
                    {
                        dp[i][1] = Math.Max(nums[i] + dp[i + 2][0], nums[i] + dp[i + 2][1]);
                    }
                }
            }
            
            return Math.Max(dp[0][0], dp[0][1]);
        }
    }
}
