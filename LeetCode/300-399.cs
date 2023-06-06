using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class _300_399
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
