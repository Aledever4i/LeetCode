﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /// <summary>
    /// 1396. Design Underground System. Tags: Hash Table, String, Design
    /// </summary>
    public class UndergroundSystem
    {
        Dictionary<int, string> stations = new Dictionary<int, string>();
        Dictionary<int, int> times = new Dictionary<int, int>();

        Dictionary<string, List<int>> values = new Dictionary<string, List<int>>();

        public UndergroundSystem()
        {
        }

        public void CheckIn(int id, string stationName, int t)
        {
            stations.Add(id, stationName);
            times.Add(id, t);
        }

        public void CheckOut(int id, string stationName, int t)
        {
            var from = stations[id];
            var time = times[id];

            if (!values.TryGetValue($"{from}-{stationName}", out List<int> roadTimes))
            {
                values.Add($"{from}-{stationName}", new List<int>() { t - time });
            }
            else
            {
                roadTimes.Add(t- time);
            }

            stations.Remove(id);
            times.Remove(id);
        }

        public double GetAverageTime(string startStation, string endStation)
        {
            return values[$"{startStation}-{endStation}"].Average();
        }
    }

    public static class _1300_1399
    {
        /// <summary>
        /// 1318. Minimum Flips to Make a OR b Equal to c. Tags: Bit Manipulation
        /// </summary>
        public static int MinFlips(int a, int b, int c)
        {
            var result = 0;

            var aString = Convert.ToString(a, 2).Reverse();
            var bString = Convert.ToString(b, 2).Reverse();
            var cString = Convert.ToString(c, 2).Reverse();
            for (int i = 0; i < Math.Max(aString.Count(), Math.Max(bString.Count(), cString.Count())); i++)
            {
                var bit = cString.ElementAtOrDefault(i);

                if (bit == '1')
                {
                    if (!(aString.ElementAtOrDefault(i) == '1' || bString.ElementAtOrDefault(i) == '1'))
                    {
                        result++;
                    }
                }
                else
                {
                    if (aString.ElementAtOrDefault(i) == '1')
                    {
                        result++;
                    }

                    if (bString.ElementAtOrDefault(i) == '1')
                    {
                        result++;
                    }
                }
            }

            // Пример другого решения
            //int res = 0;
            //for (int i = 0; i < 32; i++)
            //{
            //    int aBit = 1 << i & a;
            //    int bBit = 1 << i & b;
            //    int cBit = 1 << i & c;

            //    if (cBit == 0)
            //    {
            //        if (aBit != cBit)
            //            res++;
            //        if (bBit != cBit)
            //            res++;
            //    }
            //    else if (aBit != cBit && bBit != cBit)
            //    {
            //        res++;
            //    }
            //}

            return result;
        }

        /// <summary>
        /// 1331. Rank Transform of an Array
        /// </summary>
        public static int[] ArrayRankTransform(int[] arr)
        {
            var newArray = arr.Select((x, i) => new { Pos = i, Value = x }).OrderBy(x => x.Value);

            var start = 1;
            var current = newArray.ElementAt(0);
            var result = new List<(int, int)>() { (start, 0) };

            for (int i = 1; i < newArray.Count(); i++)
            {
                if (current == newArray.ElementAt(i))
                {
                    result.Add((start, i));
                }
                else
                {
                    start++;
                    result.Add((start, i));
                    current = newArray.ElementAt(i);
                }
            }

            return result.OrderBy(x => x.Item2).Select(x => x.Item1).ToArray();
        }

        /// <summary>
        /// 1334. Find the City With the Smallest Number of Neighbors at a Threshold Distance
        /// </summary>
        public static int FindTheCity(int n, int[][] edges, int distanceThreshold)
        {
            return 0;
        }

        /// <summary>
        /// 1346. Check If N and Its Double Exist
        /// </summary>
        public static bool CheckIfExist(int[] arr)
        {
            var hash = new HashSet<int>();

            foreach (int i in arr)
            {
                if (hash.Contains(i * 2))
                {
                    return true;
                }

                if (i % 2 == 0 && hash.Contains(i / 2))
                {
                    return true;
                }

                hash.Add(i);
            }

            return false;
        }

        /// <summary>
        /// 1347. Minimum Number of Steps to Make Two Strings Anagram
        /// </summary>
        public static int MinSteps(string s, string t)
        {
            var sDict = s.GroupBy(c => c).ToDictionary(c => c.Key, c => c.Count());
            var tDict = t.GroupBy(c => c).ToDictionary(c => c.Key, c => c.Count());

            var changes = 0;

            foreach (var sValue in sDict)
            {
                if (tDict.TryGetValue(sValue.Key, out int value))
                {
                    changes += (sValue.Value - value) > 0 ? (sValue.Value - value) : 0;
                }
                else
                {
                    changes += sValue.Value;
                }
            }

            return changes > 0 ? changes : 1;
        }

        /// <summary>
        /// 1353. Maximum Number of Events That Can Be Attended
        /// </summary>
        public static int MaxEvents(int[][] events)
        {
            System.Array.Sort(events, (a, b) => a[0] - b[0]);
            var result = 0;

            return result;

            int bisectRight(int[][] events, int target)
            {
                int left = 0, right = events.Length;
                while (left < right)
                {
                    int mid = (left + right) / 2;
                    if (events[mid][0] <= target)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid;
                    }
                }
                return left;
            }
        }

        /// <summary>
        /// 1356. Sort Integers by The Number of 1 Bits
        /// </summary>
        public static int[] SortByBits(int[] arr)
        {
            System.Array.Sort(arr);
            var dict = new Dictionary<int, List<int>>();

            for (int y = 0; y < arr.Length; y++)
            {
                var value = arr[y];
                var bitCount = 0;

                for (int i = 0; i < 32; i++)
                {
                    if ((value & (1 << i)) > 0)
                    {
                        bitCount++;
                    }
                }

                if (!dict.TryAdd(bitCount, new List<int>() { value }))
                {
                    dict[bitCount].Add(value);
                }
            }

            return dict.OrderBy(x => x.Key).SelectMany(x => x.Value).ToArray();
        }

        /// <summary>
        /// 1368. Minimum Cost to Make at Least One Valid Path in a Grid
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public static int MinCost(int[][] grid)
        {
            var result = 0;



            return result;
        }

        /// <summary>
        /// 1376. Time Needed to Inform All Employees. Tags: Tree, Depth-First Search, Breadth-First Search
        /// </summary>
        public static int NumOfMinutes(int n, int headID, int[] manager, int[] informTime)
        {
            if (n == 1)
            {
                return informTime[0];
            }

            var subordinates = new Dictionary<int, List<int>>();

            for (int i = 0; i < n; i++)
            {
                var managerId = manager[i];

                if (managerId == -1)
                {
                    continue;
                }

                if (subordinates.TryGetValue(managerId, out List<int> value))
                {
                    value.Add(i);
                }
                else
                {
                    subordinates.Add(managerId, new List<int>() { i });
                }
            }

            return getInsideTime(headID);

            int getInsideTime(int managerId)
            {
                var currentSubs = subordinates[managerId];

                var nextMoves = currentSubs.Where(sub => subordinates.TryGetValue(sub, out List<int> values));

                if (nextMoves.Any())
                {
                    return informTime[managerId] + nextMoves.Max(sub => getInsideTime(sub));
                }

                return informTime[managerId];
            }
        }

        /// <summary>
        /// 1380. Lucky Numbers in a Matrix
        /// </summary>
        public static IList<int> LuckyNumbers(int[][] matrix)
        {
            var rows = matrix.Length;
            var cols = matrix[0].Length;
            var result = new List<int>();
            var max = new List<int>();

            for (int i = 0; i < cols; i++)
            {
                max.Add(matrix.Select(r => r[i]).Max());
            }

            for (int i = 0; i < rows; i++)
            {
                var rowMin = matrix[i].Min();
                if (max.Contains(rowMin))
                {
                    result.Add(rowMin);
                }
            }

            return result;
        }
    }
}
