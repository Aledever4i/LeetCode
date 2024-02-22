using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;

namespace LeetCode
{
    public static class _0900_0999
    {
        /// <summary>
        /// 905. Sort Array By Parity
        /// </summary>
        public static int[] SortArrayByParity(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;

            var result = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                var value = nums[i];

                if (value % 2 == 0)
                {
                    result[left] = value;
                    left++;
                }
                else
                {
                    result[right] = value;
                    right--;
                }
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int SumSubarrayMins(int[] arr)
        {
            double mod = 10e8 + 7;
            int n = arr.Length;
            var left = new int[n];
            var right = new int[n];

            Array.Fill(left, -1);
            Array.Fill(right, n);

            var stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                while (stack.Count > 0 && arr[stack.Peek()] >= arr[i])
                {
                    stack.Pop();
                }

                if (stack.Count > 0)
                {
                    left[i] = stack.Peek();
                }

                stack.Push(i);
            }

            stack.Clear();

            for (int i = n - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && arr[stack.Peek()] > arr[i])
                {
                    stack.Pop();
                }
                if (stack.Count > 0)
                {
                    right[i] = stack.Peek();
                }

                stack.Push(i);
            }

            double answer = 0;

            for (int i = 0; i < n; i++)
            {
                answer += (long)(i - left[i]) * (right[i] - i) % mod * arr[i] % mod;
                answer %= mod;
            }

            return (int)answer;
        }


        /// <summary>
        /// 931. Minimum Falling Path Sum
        /// </summary>
        public static int MinFallingPathSum(int[][] matrix)
        {
            var r = matrix.Length;
            var c = matrix[0].Length;

            if (r == 1)
            {
                return matrix[0].Min();
            }

            if (c == 1)
            {
                return matrix.Select(n => n[0]).Sum();
            }

            var dp = new int[r][];
            for (int i = 0; i < r; i++)
            {
                dp[i] = new int[c];
                Array.Fill(dp[i], 100000);
            }

            int minStep(int[][] matrix, int[][] dp, int currRow, int currColumn)
            {
                if (currColumn >= c || currColumn < 0)
                {
                    return 10000000;
                }

                if (currRow == r)
                {
                    return 0;
                }

                if (dp[currRow][currColumn] != 100000)
                {
                    return dp[currRow][currColumn];
                }

                var currValue = matrix[currRow][currColumn];
                var ans = int.MaxValue;

                ans = Math.Min(ans, currValue + minStep(matrix, dp, currRow + 1, currColumn - 1));
                ans = Math.Min(ans, currValue + minStep(matrix, dp, currRow + 1, currColumn));
                ans = Math.Min(ans, currValue + minStep(matrix, dp, currRow + 1, currColumn + 1));

                return dp[currRow][currColumn] = ans;
            }

            var result = int.MaxValue;
            for (int i = 0; i < c; i++)
            {
                result = Math.Min(result, minStep(matrix, dp, 0, i));
            }
            return result;
        }

        /// <summary>
        /// 934. Shortest Bridge. Tags: Array, Depth-First Search, Breadth-First Search, Matrix
        /// </summary>
        public static int ShortestBridge(int[][] grid)
        {
            int[][] dirs = {
                new int[] { 0, -1 },
                new int[] { -1, 0 },
                new int[] { 0, 1 },
                new int[] { 1, 0 }
            };

            return 1;
        }

        /// <summary>
        /// 938. Range Sum of BST
        /// </summary>
        public static int RangeSumBST(TreeNode root, int low, int high)
        {
            return Analize(root, low, high);

            int Analize(TreeNode root, int low, int high)
            {
                int result = 0;

                if (root != null)
                {
                    if (root.val >= low && root.val <= high)
                    {
                        result = root.val;
                    }
                }

                if (root.left != null)
                {
                    result += Analize(root.left, low, high);
                }
                
                if (root.right != null)
                {
                    result += Analize(root.right, low, high);
                }

                return result;
            }
        }

        /// <summary>
        /// 956. Tallest Billboard. Tags: Array, Dynamic Programming
        /// </summary>
        public static int TallestBillboard(int[] rods)
        {
            return 0;
        }

        /// <summary>
        /// 997. Find the Town Judge
        /// </summary>
        public static int FindJudge(int n, int[][] trust)
        {
            var dict = new Dictionary<int, int>();
            var hash = new HashSet<int>();

            for (int i = 1; i <= n; i++)
            {
                dict.Add(i, 0);
            }

            foreach (var tr in trust)
            {
                hash.Add(tr[0]);
                dict[tr[1]]++;
            }

            foreach (var di in dict.Where(di => di.Value == n - 1))
            {
                if (!hash.Contains(di.Key))
                {
                    return di.Key;
                }
            }

            return -1;
        }
    }
}
