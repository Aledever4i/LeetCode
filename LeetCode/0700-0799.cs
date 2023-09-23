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
                    +0,s = mid + 1;
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
    }
}
