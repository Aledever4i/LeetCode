using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Contest
{
    public static class _377
    {
        public static int[] NumberGame(int[] nums)
        {
            System.Array.Sort(nums);

            var arr = new List<int>();

            for (int i = 0; i < nums.Length; i += 2)
            {
                arr.Add(nums[i + 1]);
                arr.Add(nums[i]);
            }

            return arr.ToArray();
        }
        public static int MaximizeSquareArea(int m, int n, int[] hFences, int[] vFences)
        {
            var mod = 10e9 + 7;

            return 1;
        }


        public static long MinimumCost(string source, string target, char[] original, char[] changed, int[] cost)
        {
            var dict = new Dictionary<(char, char), int>();
            for (int i = 0; i < original.Length; i++)
            {
                dict.Add((original[i], changed[i]), cost[i]);
            }

            foreach (char o in original)
            {
                var hash = new HashSet<char>() { o };

                foreach (char c in changed)
                {
                    if (hash.Contains(c))
                    {
                        return -1;
                    }
                }
            }

            return 0;
        }
    }
}
