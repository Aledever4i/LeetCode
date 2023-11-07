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

            var time = new double[n];
            for (int i = 0; i < n; i++)
            {
                time[i] = (1.0 * dist[i]) / (1.0 * speed[i]);
            }

            Array.Sort(time);

            for (int i = 0; i < n; i++)
            {
                if (time[i] <= i)
                {
                    break;
                }
                result++;
            }

            return result;
        }
    }
}
