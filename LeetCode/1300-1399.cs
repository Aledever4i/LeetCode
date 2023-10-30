using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
