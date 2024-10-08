﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    

    /// <summary>
    /// 380. Insert Delete GetRandom O(1). Tags: Array, Hash Table, Math, Design, Randomized
    /// </summary>
    public class RandomizedSet
    {
        private Random rnd = new();
        private Dictionary<int, int> map = new();
        private List<int> list = new();

        public RandomizedSet() { }

        public bool Insert(int val)
        {
            if (map.ContainsKey(val))
            {
                return false;
            }

            list.Add(val);
            map.Add(val, list.Count - 1);

            return true;
        }
        public bool Remove(int val)
        {
            if (!map.ContainsKey(val))
            { 
                return false;
            }

            int lastVal = list[list.Count - 1];

            list[map[val]] = lastVal;

            map[lastVal] = map[val];

            map.Remove(val);
            list.RemoveAt(list.Count - 1);

            return true;
        }
        public int GetRandom()
        {
            int idx = rnd.Next(0, list.Count);
            return list[idx];
        }
    }

    /// <summary>
    /// 303. Range Sum Query - Immutable
    /// </summary>
    public class NumArray
    {
        private int[] _nums;

        public NumArray(int[] nums)
        {
            _nums = nums;
        }

        public int SumRange(int left, int right)
        {
            int result = 0;

            for (int i = left; i <= right; i++)
            {
                result += _nums[i];
            }

            return result;
        }
    }

    public interface NestedInteger
    {
        public bool IsInteger();
        public int GetInteger();
        public IList<NestedInteger> GetList();
    }

    /// <summary>
    /// 341. Flatten Nested List Iterator
    /// </summary>
    public class NestedIterator
    {
        LinkedList<int> _list = new LinkedList<int>();
        LinkedListNode<int> currentNode;

        public NestedIterator(IList<NestedInteger> nestedList)
        {
            GetValues(nestedList);
            currentNode = _list.First;
        }

        public bool HasNext()
        {
            return currentNode != null;
        }

        public int Next()
        {
            var v = currentNode.Value;
            currentNode = currentNode.Next;
            return v;
        }

        private void GetValues(IList<NestedInteger> list)
        {
            foreach (var v in list)
            {
                if (v.IsInteger())
                {
                    _list.AddLast(v.GetInteger());
                }
                else
                {
                    GetValues(v.GetList());
                }
            }
        }
    }

    public static class _0300_0399
    {
        /// <summary>
        /// 300. Longest Increasing Subsequence
        /// </summary>
        public static int LengthOfLIS(int[] nums)
        {
            var n = nums.Length;
            var dp = new int[n][];
            for (int i = 0; i < n; i++)
            {
                dp[i] = new int[n + 1];
                System.Array.Fill(dp[i], -1);
            }

            var longest = searchLongest(0, n);
            return longest;

            int searchLongest(int index, int lastPickIndex)
            {
                if (index == n)
                {
                    return 0;
                }
                else if (dp[index][lastPickIndex] != -1)
                {
                    return dp[index][lastPickIndex];
                }

                var currentValue = nums[index];
                var lastPickValue = (lastPickIndex == n) ? int.MinValue : nums[lastPickIndex];
                if (lastPickValue >= currentValue)
                {
                    return dp[index][lastPickIndex] = searchLongest(index + 1, lastPickIndex);
                }
                else
                {
                    return dp[index][lastPickIndex] = Math.Max(1 + searchLongest(index + 1, index), searchLongest(index + 1, lastPickIndex));
                }
            }
        }


        /// <summary>
        /// 309. Best Time to Buy and Sell Stock with Cooldown
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public static int MaxProfit(int[] prices)
        {
            var hasStock = false;
            int? currentPrice = null;
            int? currentElementPrice = null;
            int? prevElementPrice = null;

            foreach (var price in prices)
            {
                currentElementPrice = price;

                if (currentElementPrice < prevElementPrice)
                {
                    Console.WriteLine("");
                }
            }

            return 0;
        }

        /// <summary>
        /// 322. Coin Change
        /// </summary>
        public static int CoinChange(int[] coins, int amount)
        {
            var n = coins.Length;
            var dp = new int[n][];

            for (int i = 0; i < dp.Length; i++)
            {
                var value = new int[amount + 1];
                System.Array.Fill(value, -1);
                dp[i] = value;
            }

            var result = numberOfWays(0, amount);
            if (result >= int.MaxValue - 1)
            {
                return -1;
            }
            return result;

            int numberOfWays(int index, int remaining)
            {
                if (index == n || remaining < 0)
                {
                    return Int32.MaxValue - 1;
                }
                else if (dp[index][remaining] != -1)
                {
                    return dp[index][remaining];
                }
                else if (remaining == 0)
                {
                    return 0;
                }

                var op1 = numberOfWays(index, remaining - coins[index]) + 1;
                var op2 = numberOfWays(index + 1, remaining);

                return dp[index][remaining] = Math.Min(op1, op2);
            }
        }

        /// <summary>
        /// 326. Power of Three
        /// </summary>
        public static bool IsPowerOfThree(int n)
        {
            var maxPow = (int)Math.Pow(3, 19);
            return n > 0 && maxPow % n == 0;
        }

        /// <summary>
        /// 338. Counting Bits. Tags: Dynamic Programming, Bit Manipulation
        /// </summary>
        public static int[] CountBits(int n)
        {
            if (n == 0)
            {
                return new int[] { 0 };
            }

            var result = new int[n + 1];
            var repeatPeriod = 2;
            var count = 2;
            result[0] = 0;
            result[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                count--;
                result[i] = result[i - repeatPeriod] + 1;

                if (count == 0)
                {
                    repeatPeriod *= 2;
                    count = repeatPeriod;
                }
            }

            return result;
        }

        /// <summary>
        /// 342. Power of Four
        /// </summary>
        public static bool IsPowerOfFour(int n)
        {
            return (n > 0) && (n & (n - 1)) == 0 && Convert.ToString(n, 2).Length % 2 == 1;
        }

        /// <summary>
        /// 343. Integer Break
        /// </summary>
        public static int IntegerBreak(int n)
        {
            if (n == 2)
            {
                return 1;
            }
            else if (n == 3)
            {
                return 2;
            }
            else if (n == 4)
            {
                return 4;
            }

            var threeCount = 0;
            while (n > 2)
            {
                threeCount++;
                n -= 3;
            }

            if (n == 1)
            {
                threeCount--;
                n += 3;
            }

            return (int)(Math.Pow(3, threeCount) * ((n > 0) ? n : 1));
        }

        /// <summary>
        /// 345. Reverse Vowels of a String
        /// </summary>
        public static string ReverseVowels(string s)
        {
            var n = s.Length;

            var left = 0;
            var right = n - 1;

            while (left < right)
            {
                while (left < n && s[left] is not 'a' and not 'e' and not 'i' and not 'o' and not 'u' and not 'A' and not 'E' and not 'I' and not 'O' and not 'U')
                {
                    left++;
                }

                if (left >= right)
                {
                    break;
                }

                while (right > 0 && s[right] is not 'a' and not 'e' and not 'i' and not 'o' and not 'u' and not 'A' and not 'E' and not 'I' and not 'O' and not 'U')
                {
                    right--;
                }

                if (left < n && right > 0)
                {
                    var temp = s[left];
                    var sb = new StringBuilder(s);
                    sb[left] = sb[right];
                    sb[right] = temp;
                    s = sb.ToString();

                    left++;
                    right--;
                }
            }

            return s;
        }

        /// <summary>
        /// 347. Top K Frequent Elements. Tags: Array, Hash Table, Divide and Conquer, Sorting, Heap(Priority Queue), Bucket Sort, Counting, Quickselect
        /// </summary>
        public static int[] TopKFrequent(int[] nums, int k)
        {
            return nums.GroupBy(n => n).OrderByDescending(g => g.Count()).Take(k).Select(g => g.Key).ToArray();
        }

        /// <summary>
        /// 349. Intersection of Two Arrays
        /// </summary>
        public static int[] Intersection(int[] nums1, int[] nums2)
        {
            return nums1.Intersect(nums2).ToArray();
        }

        /// <summary>
        /// 350. Intersection of Two Arrays II
        /// </summary>
        public static int[] Intersection2(int[] nums1, int[] nums2)
        {
            var dict1 = nums1.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            var dict2 = nums2.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            var result = new List<int>();

            foreach (var key in dict1.Keys)
            {
                if (dict2.TryGetValue(key, out var value))
                {
                    result.AddRange(Enumerable.Repeat(key, Math.Min(value, dict1[key])));
                }
            }

            return result.ToArray();
        }

        /// <summary>
        /// 372. Super Pow
        /// </summary>
        public static int SuperPow(int a, int[] b)
        {
            long result = 1;
            var pows = b.ToArray();
            result *= GetPow(a, pows[0]);

            for (int i = 1; i < b.Length; i++)
            {
                result = GetOneShift(result);
                result *= GetPow(a, pows[i]);
                result %= 1337;
            }

            return (int)result;

            long GetPow(long a, int b)
            {
                long rs = 1L;
                for (int i = 0; i < b; i++)
                {
                    rs *= a;
                    rs %= 1337;
                }
                return rs;
            }

            long GetOneShift(long a)
            {
                var init = a;
                a *= a;
                a %= 1337;
                a *= a;
                a %= 1337;
                a *= init;
                a %= 1337;
                a *= a;
                a %= 1337;
                return a;
            }
        }

        /// <summary>
        /// 373. Find K Pairs with Smallest Sums. Tags: Array, Heap(Priority Queue)
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
        {
            List<IList<int>> result = new List<IList<int>>();

            var queue = new PriorityQueue<(int, int), long>();

            foreach (int i in nums1)
            {
                foreach (int j in nums2)
                {
                    queue.Enqueue((i, j), i + j);
                }
            }

            for (int i = 0; i < k; i++)
            {
                if (queue.TryDequeue(out (int, int) x, out long p))
                {
                    result.Add(new List<int>() { x.Item1, x.Item2 });
                }
                else
                {
                    break;
                }
            }

            return result;
        }



        /// <summary>
        /// 383. Ransom Note. Tags: Hash Table, String, Counting
        /// </summary>
        /// <param name="ransomNote"></param>
        /// <param name="magazine"></param>
        /// <returns></returns>
        public static bool CanConstruct(string ransomNote, string magazine)
        {
            var ransomList = ransomNote.ToCharArray().ToList();

            foreach (char i in magazine)
            {
                ransomList.Remove(i);
            }

            return !ransomList.Any();
        }

        /// <summary>
        /// 386. Lexicographical Numbers
        /// </summary>
        public static IList<int> LexicalOrder(int n)
        {
            var list = new List<int>();
            createChilds(1);
            return list;

            void createChilds(int startNumber)
            {
                if (startNumber > n)
                {
                    return;
                }

                for (int i = 0; i <= ((startNumber == 1) ? 8 : 9); i++)
                {
                    var curNum = startNumber + i;

                    if (curNum <= n)
                    {
                        list.Add(curNum);

                        if (curNum * 10 <= n)
                        {
                            createChilds(curNum * 10);
                        }
                    }

                }
            }
        }

        /// <summary>
        /// 387. First Unique Character in a String. Tags: Hash Table, String, Queue, Counting
        /// </summary>
        public static int FirstUniqChar(string s)
        {
            var dict = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                var key = s[i];

                if (!dict.TryAdd(key, i))
                {
                    dict[key] = -1;
                }
            }

            return dict.Values.Where(v => v > -1).OrderBy(v => v).FirstOrDefault(-1);
        }

        /// <summary>
        /// 389. Find the Difference
        /// </summary>
        public static char FindTheDifference(string s, string t)
        {
            var sortedS = s.OrderBy(v => v);
            var sortedT = t.OrderBy(v => v);

            var count = sortedS.Count();

            for (int i = 0; i < count; i++)
            {
                if (!sortedS.ElementAt(i).Equals(sortedT.ElementAt(i)))
                {
                    return sortedT.ElementAt(i);
                }
            }

            return sortedT.ElementAt(count);
        }

        /// <summary>
        /// 392. Is Subsequence
        /// </summary>
        public static bool IsSubsequence(string s, string t)
        {
            var tIndex = 0;

            for (int i = 0; i < s.Length; i++)
            {
                var sChar = s[i];
                var isFound = false;

                while (!isFound && tIndex < t.Length)
                {
                    var tChar = t[tIndex];

                    if (tChar == sChar)
                    {
                        isFound = true;
                    }

                    tIndex++;
                }

                if (!isFound)
                {
                    return false;
                }
            }

            return true;
        }

        public class NodeConnect
        {
            public string To;

            public double Cost;
        }

        /// <summary>
        /// 399. Evaluate Division. Tags. Array, Depth-First Search, Breadth-First Search, Union Find, Graph, Shortest Path
        /// </summary>
        public static double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {
            var connects = new Dictionary<string, List<NodeConnect>>();
            var result = new double[queries.Count()];

            for (int i = 0; i < equations.Count(); i++)
            {
                if (!connects.TryAdd(equations[i][0], new List<NodeConnect>() { new NodeConnect() { To = equations[i][1], Cost = values[i] } }))
                {
                    connects[equations[i][0]].Add(new NodeConnect() { To = equations[i][1], Cost = values[i] });
                }

                if (!connects.TryAdd(equations[i][1], new List<NodeConnect>() { new NodeConnect() { To = equations[i][0], Cost = 1 / values[i] } }))
                {
                    connects[equations[i][1]].Add(new NodeConnect() { To = equations[i][0], Cost = 1 / values[i] });
                }
            }

            for (int i = 0; i < queries.Count(); i++)
            {
                var startPoint = queries[i][0];
                var endPoint = queries[i][1];
                var visited = new List<string>() { startPoint };

                if (!connects.ContainsKey(startPoint))
                {
                    result[i] = -1.0;
                }
                else if (startPoint.Equals(endPoint))
                {
                    result[i] = 1.0;
                }
                else
                {
                    var cost = FindNode(visited, 1.0, startPoint, endPoint);

                    if (cost == 0.0)
                    {
                        result[i] = -1.0;
                    }
                    else
                    {
                        result[i] = cost;
                    }
                }
            }

            return result;

            double FindNode(List<string> visited, double cost, string from, string to)
            {
                var ways = connects[from];
                double result = cost;
                visited.Add(from);

                var found = ways.Where(way => way.To == to).FirstOrDefault();

                if (found != null)
                {
                    result *= found.Cost;
                }
                else if (ways.Any(w => !visited.Contains(w.To)))
                {
                    result *=
                        ways
                            .Where(w => !visited.Contains(w.To))
                            .Select(
                                w =>
                                {
                                    return FindNode(visited, w.Cost, w.To, to);
                                }
                            )
                            .Max();
                }
                else
                {
                    result *= 0;
                }

                return result;
            }
        }
    }
}
