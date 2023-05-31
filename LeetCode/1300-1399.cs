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
    }
}
