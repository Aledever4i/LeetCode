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
        /// 621. Task Scheduler
        /// </summary>
        public static int LeastInterval(char[] tasks, int n)
        {
            var dict = tasks.GroupBy(c => c).ToDictionary(c => c, c => c.Count());
            return 0;
        }

        /// <summary>
        /// 623. Add One Row to Tree
        /// </summary>
        public static TreeNode AddOneRow(TreeNode root, int val, int depth)
        {
            if (depth == 1)
            {
                return new TreeNode(val, root);
            }

            var queue = new Queue<(TreeNode, int)>();
            queue.Enqueue((root, 1));

            while (queue.Count > 0)
            {
                var element = queue.Dequeue();

                if (element.Item2 == depth - 1)
                {
                    element.Item1.left = new TreeNode(val, element.Item1.left, null);
                    element.Item1.right = new TreeNode(val, null, element.Item1.right);
                }
                else
                {
                    if (element.Item1.left != null)
                    {
                        queue.Enqueue((element.Item1.left, element.Item2 + 1));
                    }

                    if (element.Item1.right != null)
                    {
                        queue.Enqueue((element.Item1.right, element.Item2 + 1));
                    }
                }
            }

            return root;
        }

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
        /// 650. 2 Keys Keyboard
        /// </summary>
        public static int MinSteps(int n)
        {
            if (n == 1) return 0;

            return 1 + minStepsHelper(1, 1);

            int minStepsHelper(int currLen, int pasteLen)
            {
                if (currLen == n) return 0;
                if (currLen > n) return 1000;

                int opt1 = 2 + minStepsHelper(currLen * 2, currLen);
                int opt2 = 1 + minStepsHelper(currLen + pasteLen, pasteLen);

                return Math.Min(opt1, opt2);
            }
        }

        /// <summary>
        /// 653. Two Sum IV - Input is a BST
        /// </summary>
        public static bool FindTarget(TreeNode root, int k)
        {
            var dict = new HashSet<int>();

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (dict.Contains(k - node.val))
                {
                    return true;
                }

                dict.Add(node.val);

                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }

            return false;
        }

        /// <summary>
        /// 670. Maximum Swap
        /// </summary>
        public static int MaximumSwap(int num)
        {
            var numS = num.ToString();
            var numL = numS.Length;
            var leftest = 10;

            for (int i = numL - 1; i >= 0; i--)
            {
                var c = numS[i];
                if (leftest > c - 'a')
                {
                    leftest = c - 'a';
                }
            }

            if (leftest == 10)
            {
                return num;
            }

            for (int i = 0; i < numL - 1; i++)
            {

            }

            return 0;
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
        /// 678. Valid Parenthesis String
        /// </summary>
        public static bool CheckValidString(string s)
        {
            var count = 0;
            var unique = 0;

            for (var i = s.Length - 1; i >= 0; i--)
            {
                var c = s[i];

                if (c == '(')
                {
                    if (count == 0 && unique == 0)
                    {
                        return false;
                    }
                    else if (count > 0)
                    {
                        count--;
                    }
                    else
                    {
                        unique--;
                    }
                }
                else if (c == '*')
                {
                    unique++;
                }
                else
                {
                    count++;
                }
            }

            count = 0;
            unique = 0;

            for (var i = 0; i < s.Length; i++)
            {
                var c = s[i];

                if (c == ')')
                {
                    if (count == 0 && unique == 0)
                    {
                        return false;
                    }
                    else if (count > 0)
                    {
                        count--;
                    }
                    else
                    {
                        unique--;
                    }
                }
                else if (c == '*')
                {
                    unique++;
                }
                else
                {
                    count++;
                }
            }

            return (unique >= count);
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
