using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LeetCode
{
    public static class _0100_0199
    {
        /// <summary>
        /// 100. Same Tree
        /// </summary>
        public static bool IsSameTree(TreeNode p, TreeNode q)
        {
            var p1 = new List<int?>();
            var p2 = new List<int?>();

            analyzeTree(p, p1);
            analyzeTree(q, p2);

            void analyzeTree(TreeNode p, List<int?> values)
            {
                if (p == null)
                {
                    return;
                }

                values.Add(p.val);

                if (p.left != null)
                {
                    analyzeTree(p.left, values);
                }
                else
                {
                    values.Add(null);
                }

                if (p.right != null)
                {
                    analyzeTree(p.right, values);
                }
                else
                {
                    values.Add(null);
                }
            }

            if (p1.Count != p2.Count)
            {
                return false;
            }

            for (int i = 0; i < p1.Count; i++)
            {
                if (p1.ElementAt(i) != p2.ElementAt(i))
                {
                    return false;
                }
            }

            return true;
        }

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
        /// 128. Longest Consecutive Sequence
        /// </summary>
        public static int LongestConsecutive(int[] nums)
        {
            var n = nums.Length;
            if (n == 0)
            {
                return 0;
            }

            var hash = new HashSet<int>();
            var dp = new Dictionary<int, int>();
            System.Array.Sort(nums);

            var value = nums[0];
            dp.Add(value, 1);
            hash.Add(value);

            for (int i = 1; i < nums.Length; i++)
            {
                value = nums[i];

                if (hash.Add(value))
                {
                    if (dp.TryGetValue(value - 1, out int previous))
                    {
                        dp.Add(value, previous + 1);
                    }
                    else
                    {
                        dp.Add(value, 1);
                    }
                }
            }

            return dp.Values.Max();
        }

        /// <summary>
        /// 146. LRU Cache
        /// </summary>
        public class LRUCache
        {
            private readonly int capacity;
            private readonly Dictionary<int, LinkedListNode<CacheItem>> cacheMap;
            private readonly LinkedList<CacheItem> cacheList;

            public LRUCache(int capacity)
            {
                this.capacity = capacity;
                cacheMap = new Dictionary<int, LinkedListNode<CacheItem>>(capacity);
                cacheList = new LinkedList<CacheItem>();
            }

            public int Get(int key)
            {
                if (cacheMap.TryGetValue(key, out var node))
                {
                    cacheList.Remove(node);
                    cacheList.AddFirst(node);
                    return node.Value.Value;
                }
                return -1;
            }

            public void Put(int key, int value)
            {
                if (cacheMap.TryGetValue(key, out var node))
                {
                    node.Value.Value = value;
                    cacheList.Remove(node);
                    cacheList.AddFirst(node);
                }
                else
                {
                    if (cacheMap.Count >= capacity)
                    {
                        var lastNode = cacheList.Last;
                        cacheMap.Remove(lastNode.Value.Key);
                        cacheList.RemoveLast();
                    }

                    var newNode = new LinkedListNode<CacheItem>(new CacheItem(key, value));
                    cacheMap.Add(key, newNode);
                    cacheList.AddFirst(newNode);
                }
            }

            private class CacheItem
            {
                public int Key { get; }
                public int Value { get; set; }

                public CacheItem(int key, int value)
                {
                    Key = key;
                    Value = value;
                }
            }
        }

        /// <summary>
        /// 111. Minimum Depth of Binary Tree
        /// </summary>
        public static int MinDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            var result = int.MaxValue;
            var queue = new Queue<(TreeNode, int)>();
            queue.Enqueue((root, 1));

            while (queue.Count() > 0)
            {
                var current = queue.Dequeue();
                if (current.Item1.left != null)
                {
                    queue.Enqueue((current.Item1.left, current.Item2 + 1));
                }
                if (current.Item1.right != null)
                {
                    queue.Enqueue((current.Item1.right, current.Item2 + 1));
                }

                if (current.Item1.left == null && current.Item1.right == null)
                {
                    result = Math.Min(result, current.Item2);
                }
            }

            return result;
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
        /// 139. Word Break. Tags: Array, Hash Table, String, Dynamic Programming, Trie, Memoization
        /// </summary>
        public static bool WordBreak(string s, IList<string> wordDict)
        {
            var words = new HashSet<string>(wordDict);
            var queue = new Queue<int>();
            bool[] seen = new bool[s.Length + 1];
            queue.Enqueue(0);

            while (queue.Count > 0)
            {
                int start = queue.Dequeue();
                if (start == s.Length)
                {
                    return true;
                }

                for (int end = start + 1; end <= s.Length; end++)
                {
                    if (seen[end])
                    {
                        continue;
                    }

                    if (words.Contains(s[start..end]))
                    {
                        queue.Enqueue(end);
                        seen[end] = true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 151. Reverse Words in a String
        /// </summary>
        public static string ReverseWords(string s)
        {
            return string.Join(' ', s.Split(' ', StringSplitOptions.RemoveEmptyEntries).Reverse());
        }

        /// <summary>
        /// 167. Two Sum II - Input Array Is Sorted. Tags: Array, Two Pointers, Binary Search
        /// </summary>
        public static int[] TwoSum(int[] numbers, int target)
        {
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                var v = numbers[i];
                if (!dict.TryAdd(v, i))
                {
                    if (v * 2 == target)
                    {
                        return new int[] { i, i + 1 };
                    }
                }
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                var v = numbers[i];

                if (dict.TryGetValue(target - v, out int index))
                {
                    return new int[] { i + 1, index + 1 };
                }
            }

            return new int[] { };
        }

        /// <summary>
        /// 168. Excel Sheet Column Title
        /// </summary>
        public static string ConvertToTitle(long columnNumber)
        {
            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var n = letters.Length;
            var builder = new StringBuilder();
            var redeem = columnNumber;

            while (redeem / n > 0)
            {
                builder.Append(letters[(int)redeem / n - 1]);
                redeem = redeem % n;
            }

            builder.Append(letters[(int)redeem - 1]);

            return builder.ToString();
        }

        /// <summary>
        /// 169. Majority Element
        /// </summary>
        public static int MajorityElement(int[] nums)
        {
            var l = nums.Length;

            if (l == 1)
            {
                return nums[0];
            }

            var dict = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                if (!dict.TryGetValue(num, out int value))
                {
                    dict[num] = 1;
                }

                value += 1;

                if (value > l / 2)
                {
                    return num;
                }

                dict[num] = value;
            }

            throw new Exception();
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
        /// 190. Reverse Bits
        /// </summary>
        public static uint reverseBits(uint n)
        {
            var converted = Convert.ToString(n, 2);
            var len = converted.Length;

            var newConverted = string.Join("", Enumerable.Repeat("0", 32 - len)) + converted;

            var reversed = newConverted.Reverse();

            return Convert.ToUInt32(string.Join("", reversed), 2);
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
