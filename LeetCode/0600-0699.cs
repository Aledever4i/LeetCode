using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class _0600_0699
    {
        /// <summary>
        /// 643. Maximum Average Subarray I. Tags: Array, Sliding Window
        /// </summary>
        public static double FindMaxAverage(int[] nums, int k)
        {
            var n = nums.Length;

            double windowValue = 0;
            for (int i = 0; i < k; i++)
            {
                windowValue += nums[i];
            }
            double maxValue = windowValue;

            for (int i = k; i < n; i++)
            {
                windowValue += nums[i] - nums[i - k];
                maxValue = Math.Max(maxValue, windowValue);
            }

            return maxValue / k;
        }

        /// <summary>
        /// 645. Set Mismatch
        /// </summary>
        public static int[] FindErrorNums(int[] nums)
        {
            var n = nums.Length;
            var intHash = new HashSet<int>();
            var duplicate = 0;

            foreach (int i in nums)
            {
                if (!intHash.Add(i))
                {
                    duplicate = i;
                }
            }

            return new int[] { duplicate, Enumerable.Range(1, n).Except(intHash).First() };
        }

        /// <summary>
        /// 647. Palindromic Substrings
        /// </summary>
        public static int CountSubstrings(string s)
        {
            var n = s.Length;
            var result = 0;

            var dp = new Dictionary<string, HashSet<int>>();

            for (int i = 0; i < n; i++)
            {
                var stringBuilder = new StringBuilder();
                for (int j = i; j < n; j++)
                {
                    stringBuilder.Append(s[j]);
                    var current = stringBuilder.ToString();
                    if (!dp.TryAdd(current, new HashSet<int>() { j }))
                    {
                        dp[current].Add(j);
                    }
                }
            }

            for (int i = n - 1; i >= 0; i--)
            {
                var stringBuilder = new StringBuilder();
                for (int j = i; j >= 0; j--)
                {
                    stringBuilder.Append(s[j]);
                    var current = stringBuilder.ToString();

                    if (current.Length == 1)
                    {
                        result++;
                    }
                    else
                    {
                        if (dp.TryGetValue(current, out var x))
                        {
                            if (x.Contains(j + current.Length - 1))
                            {
                                result++;
                            }
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 673. Number of Longest Increasing Subsequence
        /// </summary>
        public static int FindNumberOfLIS(int[] nums)
        {
            var n = nums.Length;

            var lis = new int[n];
            var count = new int[n];

            var dp = new int[n];

            return 0;
        }

        /// <summary>
        /// 687. Longest Univalue Path
        /// </summary>
        public static int LongestUnivaluePath(TreeNode root)
        {
            var result = 0;

            if (root != null)
            {
                Dfs(root, int.MinValue, 0);
            }

            return result;

            void Dfs(TreeNode node, int prevValue, int count)
            {
                if (node.val == prevValue)
                {
                    count++;
                }
                else
                {
                    count = 1;
                }

                result = Math.Max(result, count);

                if (node.left != null)
                {
                    Dfs(node.left, node.val, count);
                }

                if (node.right != null)
                {
                    Dfs(node.right, node.val, count);
                }
            }
        }
    }
}
