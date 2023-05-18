using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class _1500_1599
    {
        /// <summary>
        /// 1558. Minimum Numbers of Function Calls to Make Target Array. Graph
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <returns></returns>
        public static IList<int> FindSmallestSetOfVertices(int n, IList<IList<int>> edges)
        {
            if (n <= 1)
            {
                return new List<int>();
            }

            var result = new List<int>();

            var seconds = edges.Select(edge => edge.ElementAt(1)).Distinct();

            var empty = Enumerable.Range(0, n).Except(seconds).ToList();

            return empty;
        }
    }
}
