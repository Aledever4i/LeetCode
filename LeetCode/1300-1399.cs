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
        /// 1376. Time Needed to Inform All Employees. Tags: Tree, Depth-First Search, Breadth-First Search
        /// </summary>
        public static int NumOfMinutes(int n, int headID, int[] manager, int[] informTime)
        {
            if (n == 1)
            {
                return informTime[0];
            }

            var subordinates = new Dictionary<int, List<int>>();
            var result = 0;

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
