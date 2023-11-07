using System;

namespace LeetCode
{
    public static class _1900_1999
    {
        /// <summary>
        /// 1921. Eliminate Maximum Number of Monsters
        /// </summary>
        public static int EliminateMaximum(int[] dist, int[] speed)
        {
            var result = 0;
            var n = dist.Length;

            var union = new (int, int)[n];
            for (var i = 0; i < n; i++)
            {
                union[i] = (dist[i], speed[i]);
            }

            Array.Sort(union, new Comparison<(int, int)>((a, b) => a.Item1.CompareTo(b.Item2)));

            var time = new double[n];
            for (int i = 0; i < n; i++)
            {
                time[i] = (1.0 * union[i].Item1) / (1.0 * union[i].Item2);
            }

            Array.Sort(time);

            for (int i = 0; i < n; i++)
            {
                if (i < time[i])
                {
                    result++;
                }
                else
                {
                    break;
                }
            }

            return result;
        }
    }
}
