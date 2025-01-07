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
        /// 921. Minimum Add to Make Parentheses Valid
        /// </summary>
        public static int MinAddToMakeValid(string s)
        {
            var result = 0;
            var open = 0;

            foreach (char c in s)
            {
                if (c == ')' && open == 0)
                {
                    result++;
                }
                else if (c == ')')
                {
                    open--;
                }
                else
                {
                    open++;
                }
            }

            return result + open;
        }

        /// <summary>
        /// 930. Binary Subarrays With Sum
        /// </summary>
        public static int NumSubarraysWithSum(int[] nums, int goal)
        {
            return slidingWindowAtMost(nums, goal) - slidingWindowAtMost(nums, goal - 1);

            int slidingWindowAtMost(int[] nums, int goal)
            {
                int start = 0, currentSum = 0, totalCount = 0;

                for (int end = 0; end < nums.Length; end++)
                {
                    currentSum += nums[end];
                    while (start <= end && currentSum > goal)
                    {
                        currentSum -= nums[start++];
                    }
                    totalCount += end - start + 1;
                }

                return totalCount;
            }
        }
        public static int NumSubarraysWithSum2(int[] nums, int goal)
        {
            int start = 0;
            int prefixZeros = 0;
            int currentSum = 0;
            int totalCount = 0;

            for (int end = 0; end < nums.Length; end++)
            {
                currentSum += nums[end];

                while (start < end && (nums[start] == 0 || currentSum > goal))
                {
                    if (nums[start] == 1)
                    {
                        prefixZeros = 0;
                        currentSum -= 1;
                    }
                    else
                    {
                        prefixZeros++;
                    }

                    start++;
                }

                if (currentSum == goal)
                {
                    totalCount += 1 + prefixZeros;
                }
            }

            return totalCount;
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
        /// 948. Bag of Tokens
        /// </summary>
        public static int BagOfTokensScore(int[] tokens, int power)
        {
            int n = tokens.Length;
            int count = 0, result = 0;
            if (tokens.Length == 0)
            {
                return result;
            }

            Array.Sort(tokens);

            int start = 0, end = tokens.Length;
            bool isMoved = true;

            while (start < n && power > tokens[start])
            {
                power = power - tokens[start];
                start++;
                count++;
            }

            result = count;

            while (start < n && isMoved)
            {
                var next = tokens[start];
                isMoved = false;

                if (power < next && start < end && count > 0)
                {
                    power += tokens[end - 1];
                    count--;
                    end--;
                    isMoved = true;
                }

                while (power >= next && start < end)
                {
                    power -= next;
                    count++;
                    next = tokens[++start];
                    isMoved = true;
                }

                result = Math.Max(result, count);
            }

            return result;
        }

        /// <summary>
        /// 950. Reveal Cards In Increasing Order
        /// </summary>
        public static int[] DeckRevealedIncreasing(int[] deck)
        {
            System.Array.Sort(deck);
            var list = new List<int>() { deck[deck.Length - 1] };

            for (int i = deck.Length - 2; i >= 0; i--)
            {
                var card = deck[i];
                swap(list);
                list.Insert(0, card);
            }

            void swap(List<int> list)
            {
                int tmp = list[list.Count - 1];
                list.RemoveAt(list.Count - 1);
                list.Insert(0, tmp);
            }

            return list.ToArray();
        }

        /// <summary>
        /// 956. Tallest Billboard. Tags: Array, Dynamic Programming
        /// </summary>
        public static int TallestBillboard(int[] rods)
        {
            return 0;
        }

        /// <summary>
        /// 962. Maximum Width Ramp
        /// </summary>
        public static int MaxWidthRamp(int[] nums)
        {
            var result = 0;

            var postfix = new int[nums.Length + 1];
            postfix[nums.Length] = int.MinValue;

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                postfix[i] = Math.Max(postfix[i + 1], nums[i]);
            }

            for (int i = 0; i + result < nums.Length; i++)
            {
                var num = nums[i];
                int j = i + result + 1;
                var post = postfix[j];
                
                while (post >= num && j + 1 < postfix.Length)
                {
                    j++;
                    post = postfix[j];
                }

                result = Math.Max(j - i - 1, result);
            }

            return result;
        }

        /// <summary>
        /// 976. Largest Perimeter Triangle
        /// </summary>
        public static int LargestPerimeter(int[] nums)
        {
            var sides = nums.OrderByDescending(n => n).ToArray();

            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (sides[i] < sides[i + 1] + sides[i + 2])
                {
                    return sides[i] + sides[i + 1] + sides[i + 2];
                }
            }

            return 0;
        }

        /// <summary>
        /// 977. Squares of a Sorted Array
        /// </summary>
        public static int[] SortedSquares(int[] nums)
        {
            return nums.OrderBy(n => Math.Abs(n)).Select(n => (int)Math.Pow(n, 2)).ToArray();
        }

        /// <summary>
        /// 988. Smallest String Starting From Leaf
        /// </summary>
        public static string SmallestFromLeaf(TreeNode root)
        {
            var queue = new Queue<TreeNode>();
            var list = new List<int>();
            var nodeList = new List<TreeNode>();
            
            queue.Enqueue(root);

            while (queue.Count >= 0)
            {
                if (queue.Count == 0)
                {

                }
            }
            
            
            while (root != null) { }

            return string.Empty;
        }

        /// <summary>
        /// 992. Subarrays with K Different Integers
        /// </summary>
        public static int SubarraysWithKDistinct(int[] nums, int k)
        {
            return Calc(nums, k) - Calc(nums, k - 1);

            int Calc(int[] nums, int k)
            {
                var result = 0;
                var n = nums.Length;
                var occurs = new Dictionary<int, int>();

                for (int left = 0, right = 0; right < n; right++)
                {
                    var current = nums[right];

                    occurs[current] = occurs.TryGetValue(current, out int value) ? value + 1 : 1;

                    while (occurs.Count > k)
                    {
                        occurs[nums[left]]--;
                        if (occurs[nums[left]] == 0)
                        {
                            occurs.Remove(nums[left]);
                        }
                        left++;
                    }
                    result += right - left + 1;
                }

                return result;
            }
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
