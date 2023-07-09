using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    public static class _2200_2300
    {
        /// <summary>
        /// 2272. Substring With Largest Variance
        /// </summary>
        public static int LargestVariance(string s)
        {
            var n = s.Length;
            var chars = s.ToCharArray();
            var charDistinct = chars.Distinct().ToList();

            var pairs = new List<(char a, char b)>();

            while (charDistinct.Count() > 1)
            {
                var firstChar = charDistinct.ElementAt(0);

                foreach (var secondChar in charDistinct)
                {
                    if (firstChar != secondChar)
                    {
                        pairs.Add((firstChar, secondChar));
                    }
                }

                charDistinct.RemoveAt(0);
            }

            var result = 0;
            int mainResult;
            int secondResult;
            int restResult;

            foreach (var (a, b) in pairs)
            {
                mainResult = 0;
                secondResult = 0;
                restResult = chars.Where(c => c == b).Count();
                for (int i = 0; i < n; i++)
                {
                    if (a == chars[i])
                    {
                        mainResult++;
                    }
                    else if (b == chars[i])
                    {
                        secondResult++;
                        restResult--;
                    }

                    if (secondResult > 0)
                    {
                        result = Math.Max(result, mainResult - secondResult);
                    }

                    if (mainResult - secondResult < 0 && restResult > 0)
                    {
                        mainResult = 0;
                        secondResult = 0;
                    }
                }

                mainResult = 0;
                secondResult = 0;
                restResult = chars.Where(c => c == a).Count();
                for (int i = 0; i < n; i++)
                {
                    if (b == chars[i])
                    {
                        mainResult++;
                    }
                    else if (a == chars[i])
                    {
                        secondResult++;
                        restResult--;
                    }

                    if (secondResult > 0)
                    {
                        result = Math.Max(result, mainResult - secondResult);
                    }

                    if (mainResult - secondResult < 0 && restResult > 0)
                    {
                        mainResult = 0;
                        secondResult = 0;
                    }
                }
            }

            return result;
        }
    }
}
