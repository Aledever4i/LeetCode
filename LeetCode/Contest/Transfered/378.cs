using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Contest.Transfered
{
    public static class _378
    {

        public static bool HasTrailingZeros(int[] nums)
        {
            return nums.Where(n => n % 2 == 0).Count() > 1;
        }


        public static int MaximumLength(string s)
        {
            Dictionary<(char, int), int> dict = new Dictionary<(char, int), int>();

            char previewSymbol = s[0];
            int frequency = 1;

            for (int i = 1; i < s.Length; i++)
            {
                var cur = s[i];

                if (cur == previewSymbol)
                {
                    frequency++;
                }
                else
                {
                    if (!dict.TryAdd((previewSymbol, frequency), 1))
                    {
                        dict[(previewSymbol, frequency)] += 1;
                    }

                    frequency = 1;
                    previewSymbol = cur;
                }
            }

            if (!dict.TryAdd((previewSymbol, frequency), 1))
            {
                dict[(previewSymbol, frequency)] += 1;
            }

            var newDict = dict.Select(v => new { Symb = v.Key.Item1, Freq = v.Key.Item2, Count = v.Value }).OrderByDescending(v => v.Freq).ThenByDescending(v => v.Count).Take(26);

            var result = -1;

            foreach (var v in newDict)
            {
                if (v.Count >= 3)
                {
                    result = Math.Max(result, v.Freq);
                }
                else if (dict.ContainsKey((v.Symb, v.Freq - 1)) || v.Count == 2 && v.Freq > 1)
                {
                    result = Math.Max(result, v.Freq - 1);
                }
                else if (v.Freq >= 3)
                {
                    result = Math.Max(result, v.Freq - 2);
                }
            }

            return result;
        }


        public static bool[] CanMakePalindromeQueries(string s, int[][] queries)
        {
            var n = queries.Length;
            var result = new bool[n];

            for (int i = 0; i < n; i++)
            {
                var copy = s.Clone();

                var a = queries[i][0];
                var b = queries[i][1];
                var c = queries[i][2];
                var d = queries[i][3];

                var dictStart = new Dictionary<char, int>();
                var dictEnd = new Dictionary<char, int>();

                for (int y = 0; y < n / 2; y++)
                {
                    var x = s[y];
                    if (!dictStart.TryAdd(x, 1))
                    {
                        dictStart[x] += 1;
                    }
                }

                for (int y = n / 2; y < n; y++)
                {
                    var x = s[y];
                    if (!dictEnd.TryAdd(x, 1))
                    {
                        dictEnd[x] += 1;
                    }
                }

                for (int y = 0; y < n / 2; y++)
                {
                    var end = n - y - 1;
                    var startSymbol = s[y];
                    var endSymbol = s[end];

                    if (
                        y < a || y > b
                        || end < c || end > d
                    )
                    {
                        if (y < a && end > d)
                        {
                            if (startSymbol != endSymbol)
                            {
                                result[i] = false;
                                break;
                            }
                        }
                        else if (y > b && end < c)
                        {
                            if (startSymbol != endSymbol)
                            {
                                result[i] = false;
                                break;
                            }
                        }
                        else if (y < a || y > b)
                        {
                            var countEnd = dictEnd[endSymbol];

                            if (countEnd == 0)
                            {
                                result[i] = false;
                                break;
                            }

                            dictEnd[endSymbol]--;
                        }
                        else if (end < c || end > d)
                        {
                            var countStart = dictStart[startSymbol];

                            if (countStart == 0)
                            {
                                result[i] = false;
                                break;
                            }

                            dictStart[startSymbol]--;
                        }

                    }
                }

                foreach (var item in s.Substring(a, b))
                {

                }
            }

            return result;
        }
    }
}
