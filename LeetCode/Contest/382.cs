using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Contest
{
    public static class _382
    {
        public static int CountKeyChanges(string s)
        {
            s = s.ToLower();
            var start = s[0];
            var result = 0;

            foreach (var c in s)
            {
                if (c != start)
                {
                    result++;
                    start = c;
                }
            }

            return result;
        }


        public static int MaximumLength(int[] nums)
        {
            var result = 1;
            var n = nums.Length;

            var dict = nums.GroupBy(n => n).ToDictionary(n => n.Key, n => n.Count());
            
            if (dict.TryGetValue(1, out int oneCount))
            {
                result = (oneCount % 2 == 0) ? oneCount - 1 : oneCount;
                dict.Remove(1);
            }

            var visited = new HashSet<int>();

            if (n > 2)
            {
                foreach (var key in dict.Keys.OrderBy(n => n))
                {
                    if (visited.Contains(key))
                    {
                        continue;
                    }

                    result = Math.Max(Analyze(key, 0), result);
                }
            }

            int Analyze(int key, int value)
            {
                visited.Add(key);

                if (dict.TryGetValue(key, out int temp))
                {
                    if (temp == 1)
                    {
                        return value + 1;
                    }

                    return Analyze((int)Math.Pow(key, 2), value + 2);
                }

                return value - 1;
            }

            return result;
        }


        public static long FlowerGame(int n, int m)
        {
            long result = 0;

            foreach (var x in Enumerable.Range(1, n))
            {
                long mCount = 0;

                if (x % 2 == 1)
                {
                    mCount = m / 2;
                }
                else
                {
                    mCount = (m % 2 == 1) ? m / 2 + 1 : m / 2;
                }

                result += mCount;
            }

            return result;
        }
    }
}
