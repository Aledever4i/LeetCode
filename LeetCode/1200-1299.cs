using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace LeetCode
{
    public static class _1200_1299
    {
        /// <summary>
        /// 1200. Minimum Absolute Difference
        /// </summary>
        public static IList<IList<int>> MinimumAbsDifference(int[] arr)
        {
            Array.Sort(arr);

            var result = new List<IList<int>>();
            var min = int.MaxValue;

            for (int i = 1; i < arr.Length; i++)
            {
                var value = arr[i];
                var diff = value - arr[i - 1];

                if (diff < min)
                {
                    min = diff;
                    result.Clear();

                    result.Add(new List<int>() { value - min, value });
                }
                else if (diff == min)
                {
                    result.Add(new List<int>() { value - min, value });
                }
            }

            return result;
        }

        /// <summary>
        /// 1207. Unique Number of Occurrences
        /// </summary>
        public static bool UniqueOccurrences(int[] arr)
        {
            var group = arr.GroupBy(num => num).ToDictionary(num => num.Key, num => num.Count());

            var hash = new HashSet<int>();

            foreach ( var item in group)
            {
                if (!hash.Add(item.Value))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 1218. Longest Arithmetic Subsequence of Given Difference
        /// </summary>
        public static int LongestSubsequence(int[] arr, int difference)
        {
            var n = arr.Length;
            var result = new Dictionary<int, int>();

            if (n == 1)
            {
                return 1;
            }

            for (int i = 0; i < n; i++)
            {
                var value = arr[i];

                if (result.TryGetValue(value - difference, out int count))
                {
                    result[value] = count + 1;
                }
                else
                {
                    result[value] = 1;
                }
            }

            return result.Values.Max();
        }

        /// <summary>
        /// 1220. Count Vowels Permutation
        /// </summary>
        public static int CountVowelPermutation(int n)
        {
            var mod = 1000000007;
            var dict = new Dictionary<int, List<int>>()
            {
                { 1, new List<int>() { 2 } },
                { 2, new List<int>() { 1, 3 } },
                { 3, new List<int>() { 1, 2, 4, 5 } },
                { 4, new List<int>() { 3, 5 } },
                { 5, new List<int>() { 1 } }
            };

            var chars = new int[5] { 1, 2, 3, 4, 5 };

            var dp = new int[n + 1][];
            for (int i = 0; i < n + 1; i++)
            {
                dp[i] = new int[6];
            }

            dp[1][1] = 1;
            dp[1][2] = 1;
            dp[1][3] = 1;
            dp[1][4] = 1;
            dp[1][5] = 1;

            for (int i = 2; i < n + 1; i++)
            {
                foreach (var x in chars)
                {
                    var list = dict[x];
                    foreach (var s in list)
                    {
                        dp[i][s] = (dp[i][s] + dp[i - 1][x]) % mod;
                    }
                }
            }

            var result = 0;
            foreach (var x in dp[n])
            {
                result = (result + x) % mod;
            }

            return result;
        }

        /// <summary>
        /// 1232. Check If It Is a Straight Line. Tags: Array, Math, Geometry
        /// </summary>
        public static bool CheckStraightLine(int[][] coordinates)
        {
            if (coordinates.Length == 2)
            {
                return true;
            }

            var point1X = coordinates[0][0];
            var point1Y = coordinates[0][1];

            var point2X = coordinates[1][0];
            var point2Y = coordinates[1][1];

            if (point1X == point2X)
            {
                return !coordinates.Any(coordinate => coordinate[0] != point1X);
            }
            else if (point1Y == point2Y)
            {
                return !coordinates.Any(coordinate => coordinate[1] != point1Y);
            }


            double xStep = Math.Abs( - point2X);
            double yStep = Math.Abs(point1Y - point2Y);

            return !coordinates.Any(coordinate => (coordinate[0] - point1X) / (point2X - point1X) != (coordinate[1] - point1Y) / (point2Y - point1Y));
        }

        /// <summary>
        /// 1239. Maximum Length of a Concatenated String with Unique Characters
        /// </summary>
        public static int MaxLength(IList<string> arr)
        {
            var dp = new Dictionary<int, int>();
            var hash = new HashSet<char>();


            return 0;
        }

        /// <summary>
        /// 1249. Minimum Remove to Make Valid Parentheses
        /// </summary>
        public static string MinRemoveToMakeValid(string s)
        {
            var listToPass = new List<int>();
            var temp = new List<int>();

            var count = 0;

            for (int i = 0; i < s.Length; i++)
            {
                var c = s[i];

                if (c == ')' && count == 0)
                {
                    listToPass.Add(i);
                }
                else if (c == ')')
                {
                    temp.RemoveAt(temp.Count - 1);
                    count--;
                }
                else if (c == '(')
                {
                    temp.Add(i);
                    count++;
                }
            }

            listToPass.AddRange(temp);

            var builder = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                if (!listToPass.Contains(i))
                {
                    builder.Append(s[i]);
                }
            }

            return builder.ToString();
        }

        /// <summary>
        /// 1269. Number of Ways to Stay in the Same Place After Some Steps
        /// </summary>
        public static int NumWays(int steps, int arrLen)
        {
            var modulo = 1000000007;
            var dp = new double[steps][];
            for (int i = 0; i < steps; i++)
            {
                dp[i] = new double[steps + 1];
            }

            var result = checkMove(0, steps);
            return (int)result;

            double checkMove(int position, int remain)
            {
                if (position >= arrLen)
                {
                    return 0;
                }

                if (position < 0)
                {
                    return 0;
                }

                if (position > remain)
                {
                    return 0;
                }

                if (dp[position][remain] != 0)
                {
                    return dp[position][remain];
                }

                if (position == 0 && remain == 0)
                {
                    return 1;
                }

                dp[position][remain] += checkMove(position, remain - 1) % modulo;
                dp[position][remain] += checkMove(position + 1, remain - 1) % modulo;
                dp[position][remain] += checkMove(position - 1, remain - 1) % modulo;
                dp[position][remain] %= modulo;

                return dp[position][remain];
            }
        }

        /// <summary>
        /// 1275. Find Winner on a Tic Tac Toe Game
        /// </summary>
        public static string Tictactoe(int[][] moves)
        {
            if (moves.Length <= 4)
            {
                return "Pending";
            }

            int[][] winCombinations = new int[][]
            {
                new[] {0,1,2}, new[] {3,4,5}, new[] {6,7,8}, // verticals
                new[] {0,4,8}, new[] {2,4,6},                // diagonals
                new[] {0,3,6}, new[] {1,4,7}, new[] {2,5,8}  // horizontals
            };
            int[] x = new int[9];
            int[] o = new int[9];

            for (int i = 0; i < moves.Length; i++)
            {
                var index = moves[i][0] + moves[i][1] * 3;

                if (i % 2 == 0)
                {
                    x[index] = 1;
                }
                else
                {
                    o[index] = 1;
                }
            }

            foreach (var combination in winCombinations)
            {
                if (combination.All(i => x[i] == 1)) return "A";
                if (combination.All(i => o[i] == 1)) return "B";
            }

            return moves.Length == 9 ? "Draw" : "Pending";
        }

        /// <summary>
        /// 1291. Sequential Digits
        /// </summary>
        public static IList<int> SequentialDigits(int low, int high)
        {
            var numbers = "123456789";
            var sequences = new List<int>();

            for (int i = 2; i <= 9; i++)
            {
                var start = int.Parse(numbers[..i]);
                sequences.Add(start);
                for (int y = 0; y < 9 - i; y++)
                {
                    start += int.Parse(string.Join("", Enumerable.Repeat(1, i)));
                    sequences.Add(start);
                }
            }

            return sequences.Where(n => n >= low && n <= high).ToList();
        }
    }
}
