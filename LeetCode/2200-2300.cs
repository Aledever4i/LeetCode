using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    public static class _2200_2300
    {
        /// <summary>
        /// 2251. Number of Flowers in Full Bloom
        /// </summary>
        public static int[] FullBloomFlowers(int[][] flowers, int[] people)
        {
            int[] sortedPeople = people.OrderBy(v => v).ToArray();
            System.Array.Sort(flowers, (a, b) => a[0].CompareTo(b[0]));

            var dict = new Dictionary<int, int>();
            var queue = new PriorityQueue<int, int>();

            int i = 0;

            foreach (var person in sortedPeople)
            {
                while (i < flowers.Length && flowers[i][0] <= person)
                {
                    queue.Enqueue(flowers[i][1], flowers[i][1]);
                    i++;
                }

                while (queue.Count > 0 && queue.Peek() < person)
                {
                    queue.Dequeue();
                }

                dict[person] = queue.Count;
            }


            var result = new List<int>();
            foreach (var person in people)
            {
                result.Add(dict[person]);
            }
            return result.ToArray();
        }

        /// <summary>
        /// 2259. Remove Digit From Number to Maximize Result
        /// </summary>
        public static string RemoveDigit(string number, char digit)
        {
            var lastIndex = -1;
            for (int i = 0; i < number.Length; i++)
            {
                var currentChar = number[i];
                if (currentChar == digit)
                {
                    lastIndex = i;

                    if (i + 1 < number.Length)
                    {
                        var nextChar = number[i + 1];
                        if (currentChar != nextChar && char.GetNumericValue(currentChar) < char.GetNumericValue(nextChar))
                        {
                            break;
                        }
                    }
                }
            }

            return number.Remove(lastIndex, 1);
        }

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
