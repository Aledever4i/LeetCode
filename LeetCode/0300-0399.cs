using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
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


    public static class _0300_0399
    {
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
        /// 347. Top K Frequent Elements. Tags: Array, Hash Table, Divide and Conquer, Sorting, Heap(Priority Queue), Bucket Sort, Counting, Quickselect
        /// </summary>
        public static int[] TopKFrequent(int[] nums, int k)
        {
            return nums.GroupBy(n => n).OrderByDescending(g => g.Count()).Take(k).Select(g => g.Key).ToArray();
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
