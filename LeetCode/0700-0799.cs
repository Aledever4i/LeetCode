using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /// <summary>
    /// 705. Design HashSet
    /// </summary>
    public class MyHashSet
    {
        private int currentIndex = 0;
        private int currentSize = 10;

        private int?[] keys;

        public MyHashSet()
        {
            keys = new int?[currentSize];
        }

        public void Add(int key)
        {
            var index = System.Array.IndexOf(keys, key, 0, currentSize);
            if (index >= 0)
            {
                return;
            }

            if (currentIndex >= currentSize)
            {
                resize(currentSize + 2);
                currentSize += 2;
            }

            keys[currentIndex] = key;

            currentIndex++;
        }

        public void Remove(int key)
        {
            var index = System.Array.IndexOf(keys, key);

            if (index >= 0)
            {
                System.Array.Copy(keys, index + 1, keys, index, currentSize - index - 1);
            }
        }

        public bool Contains(int key)
        {
            var index = System.Array.IndexOf(keys, key, 0, currentSize);

            return (index >= 0);
        }

        private void resize(int newSize)
        {
            var newArray = new int?[newSize];
            System.Array.Copy(keys, newArray, currentSize);
            keys = newArray;
        }
    }

    public static class _0700_0799
    {
        /// <summary>
        /// 704. Binary Search
        /// </summary>
        public static int Search(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                var mid = (left + right) / 2;
                var value = nums[mid];

                if (value == target)
                {
                    return mid;
                }

                if (value > target)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return -1;
        }

        /// <summary>
        /// 714. Best Time to Buy and Sell Stock with Transaction Fee. Tags: Array, Dynamic Programming, Greedy
        /// </summary>
        public static int MaxProfit(int[] prices, int fee)
        {
            var length = prices.Length;
            var dp = new Dictionary<(int, int), int>();

            return Math.Max(processTransaction(0, 1), 0);

            int processTransaction(int i, int isBuy)
            {
                if (i >= length)
                {
                    return 0;
                }

                if (dp.ContainsKey((i, isBuy)))
                {
                    return dp[(i, isBuy)];
                }

                var result = 0;

                if (isBuy == 1)
                {
                    dp[(i, isBuy)] = Math.Max(-prices[i] + processTransaction(i + 1, 0), processTransaction(i + 1, 1));
                }
                else
                {
                    dp[(i, isBuy)] = Math.Max(prices[i] - fee + processTransaction(i + 1, 1), processTransaction(i + 1, 0));
                }

                return dp[(i, isBuy)];
            }
        }

        /// <summary>
        /// 726. Number of Atoms
        /// </summary>
        public static string CountOfAtoms(string formula)
        {
            var queue = new Queue<(string, int)>();
            var current = string.Empty;
            var index = 0;
            var dict = new Dictionary<string, int>();

            for (int i = 0; i < formula.Length; i++)
            {
                var symbol = formula[i];

                if (symbol == '(')
                {
                    index++;
                }
                else if (symbol == ')')
                {
                    var multi = string.Empty;
                    int intMulti = 1;

                    while (i + 1 < formula.Length && Char.IsDigit(formula[i + 1]))
                    {
                        multi += formula[i + 1];
                        i++;
                    }

                    if (!string.IsNullOrWhiteSpace(multi))
                    {
                        intMulti = int.Parse(multi);
                    }

                    while (queue.TryPeek(out var result) && result.Item2 == index)
                    {
                        if (!dict.TryAdd(symbol.ToString(), intMulti))
                        {
                            dict[symbol.ToString()] += intMulti;
                        }
                    }


                }
                else if (Char.IsDigit(symbol))
                {

                }
                else if (Char.IsLower(symbol))
                {

                }
                else
                {

                }
            }

            return string.Empty;
        }

        /// <summary>
        /// 735. Asteroid Collision. Tags: Array, Stack, Simulation
        /// </summary>
        public static int[] AsteroidCollision(int[] asteroids)
        {
            var queue = new Stack<int>();
            var result = new List<int>();

            foreach (var asteroid in asteroids)
            {
                if (queue.Count == 0 && asteroid < 0)
                {
                    result.Add(asteroid);
                }
                else if (asteroid > 0)
                {
                    queue.Push(asteroid);
                }
                else if (asteroid < 0)
                {
                    while (queue.Count > 0)
                    {
                        var ast = queue.Pop();

                        if (ast > Math.Abs(asteroid))
                        {
                            queue.Push(ast);
                            break;
                        }
                        else if (ast == Math.Abs(asteroid))
                        {
                            break;
                        }
                        else if (queue.Count == 0)
                        {
                            result.Add(asteroid);
                        }
                    }
                }
            }

            if (queue.Count > 0)
            {
                result.AddRange(queue.Reverse());
            }

            return result.ToArray();
        }

        /// <summary>
        /// 739. Daily Temperatures
        /// </summary>
        public static int[] DailyTemperatures(int[] temperatures)
        {
            var n = temperatures.Length;
            var result = new int[n];
            Array.Fill(result, 0);

            var stack = new Stack<(int, int)>();

            for (int i = 0; i < n; i++)
            {
                var value = temperatures[i];

                while (stack.Count > 0 && stack.TryPeek(out (int, int) stackValue) && stackValue.Item1 < value)
                {
                    result[stackValue.Item2] = i - stackValue.Item2;
                    stack.Pop();
                }

                stack.Push((value, i));
            }

            return result;
        }

        /// <summary>
        /// 744. Find Smallest Letter Greater Than Target. Tags: Array, Binary Search
        /// </summary>
        public static char NextGreatestLetter(char[] letters, char target)
        {
            int s = 0, e = letters.Length - 1;

            if (letters[letters.Length - 1] <= target)
            {
                return letters[0];
            }

            while (s < e)
            {
                int mid = (s + e) / 2;

                if (letters[mid] <= target)
                {
                    s = mid + 1;
                }
                else
                {
                    e = mid;
                }
            }

            return letters[s];


            //var alpha = "abcdefghijklmnopqrstuvwxyz".ToList();
            //var index = alpha.IndexOf(target);

            //for (int i = index + 1; i < alpha.Count; i++)
            //{
            //    var a = alpha[i];

            //    if (letters.Contains(a))
            //    {
            //        return a;
            //    }
            //}

            //return letters[0];
        }

        /// <summary>
        /// 746. Min Cost Climbing Stairs
        /// </summary>
        public static int MinCostClimbingStairs(int[] cost)
        {
            var result = 0;
            var n = cost.Length;
            var dp = new int?[n];

            return Math.Min(GetMinStep(0), GetMinStep(1));

            int GetMinStep(int startIndex)
            {
                if (startIndex >= n)
                {
                    return 0;
                }

                if (dp[startIndex].HasValue)
                {
                    return dp[startIndex].Value;
                }

                dp[startIndex] = cost[startIndex] + Math.Min(GetMinStep(startIndex + 1), GetMinStep(startIndex + 2));

                return dp[startIndex].Value;
            }
        }

        /// <summary>
        /// 767. Reo+rganize String
        /// </summary>
        public static string ReorganizeString(string s)
        {
            var dict = s.ToCharArray().GroupBy(c => c).Select(g => new { k = g.Key, c = g.ToList() }).OrderByDescending(o => o.c).ToList();
            var n = dict.Count;

            if (n == 1 && s.Length > 1)
            {
                return string.Empty;
            }

            return string.Empty;
        }

        /// <summary>
        /// 779. K-th Symbol in Grammar
        /// </summary>
        public static int KthGrammar(int n, int k)
        {
            var power = n - 1;
            var rowCount = Math.Pow(2, power);
            double currentK = k;

            while (currentK > 2)
            {
                var half = rowCount / 2;
                if (currentK > half)
                {
                    if (currentK > half + half / 2 && currentK <= rowCount)
                    {
                        currentK = currentK - half - half / 2;
                    }
                    else
                    {
                        currentK = currentK - half / 2;
                    }

                }
                else
                {
                    rowCount = half;
                }
            }

            return (currentK == 2) ? 1 : 0;
        }

        /// <summary>
        /// 785. Is Graph Bipartite?. Tags: Depth-First Search, Breadth-First Search, Union Find, Graph
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public static bool IsBipartite(int[][] graph)
        {
            var n = graph.Length;

            for (int i = 0; i < n; i++)
            {
                var connects = graph[i];

                var notConnectedX = Enumerable.Range(0, n).Except(connects);

                foreach (var y in notConnectedX)
                {
                    var connectY = graph[y];

                    var notConnectedY = Enumerable.Range(0, n).Except(connects).Except(new int[] { i, y });

                    if (!notConnectedY.Any())
                    {
                        return true;
                    }
                }

            }

            return false;
        }

        /// <summary>
        /// 787. Cheapest Flights Within K Stops
        /// </summary>
        public static int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
        {
            int[] distances = new int[n];
            Array.Fill(distances, int.MaxValue);
            distances[src] = 0;

            for (int i = 0; i <= k; ++i)
            {
                var temp = (int[])distances.Clone();

                foreach (var flight in flights)
                {
                    int from = flight[0];
                    int to = flight[1];
                    int cost = flight[2];
                    if (distances[from] != int.MaxValue && distances[from] + cost < temp[to])
                    {
                        temp[to] = distances[from] + cost;
                    }
                }

                distances = temp;
            }

            return distances[dst] == int.MaxValue ? -1 : distances[dst];
        }
    }
}
