using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class _800_899
    {
        /// <summary>
        /// 837. New 21 Game. Tags: Math, Dynamic Programming, Sliding Window, Probability and Statistics
        /// </summary>
        public static double New21Game(int n, int k, int maxPts)
        {
            return 0.0;
        }

        /// <summary>
        /// 859. Buddy Strings. Tags: Hash Table, String
        /// </summary>
        public static bool BuddyStrings(string s, string goal)
        {
            var sInEqual = new List<char>();
            var goalInEqual = new List<char>();

            if (s.Length != goal.Length)
            {
                return false;
            }

            for (int i = 0; i < s.Length; i++)
            {
                var sChar = s[i];
                var goalChar = goal[i];

                if (sChar != goalChar)
                {
                    sInEqual.Add(sChar);
                    goalInEqual.Add(goalChar);
                }
            }

            if (sInEqual.Count() == 2 && !sInEqual.Except(goalInEqual).Any())
            {
                return true;
            }
            else if (sInEqual.Count() == 1)
            {
                return false;
            }
            else if (sInEqual.Count() > 2)
            {
                return false;
            }
            else if (!sInEqual.Any())
            {
                return s.GroupBy(c => c).Any(gr => gr.Count() > 1);
            }

            return false;
        }

        /// <summary>
        /// 877. Stone Game. Tags: Array, Math, Dynamic Programming, Game Theory
        /// </summary>
        public static bool StoneGame(int[] piles)
        {
            int count = piles.Length;

            var dp = new int[count + 2][];
            for (int y = 0; y < count + 2; y++)
            {
                dp[y] = new int[count + 2];
            }

            var first = 0;
            var second = 0;
            var step = 0;

            for (int x = 0, y = count - 1; step < count; step++)
            {
                var who = (x + y % 2);
                var left1 = piles[x] + GetMAxPoint(x + 2, y);
                var right = piles[y] + GetMAxPoint(x, y - 2);

                if (left1 > right)
                {
                    if (who == 1)
                    {
                        first += piles[x];
                    }
                    else
                    {
                        second += piles[x];
                    }
                    x = x + 1;
                }
                else
                {
                    if (who == 1)
                    {
                        first += piles[y];
                    }
                    else
                    {
                        second += piles[y];
                    }
                    y = y - 1;
                }
            }

            return first > second;

            int GetMAxPoint(int x, int y)
            {
                if (x > y || y < x || x < 0 || y < 0)
                {
                    return 0;
                }

                if (dp[x][y] > 0)
                {
                    return dp[x][y];
                }

                if (x == y || Math.Abs(x - y) == 1)
                {
                    dp[x][y] = Math.Max(piles[x], piles[y]);

                    return dp[x][y];
                }
                else
                {
                    var left1 = piles[x] + GetMAxPoint(x + 2, y);
                    var right2 = piles[y] + GetMAxPoint(x, y - 2);
                    
                    dp[x][y] = Math.Max(left1, right2);
                }

                return dp[x][y];
            }
        }
    }
}
