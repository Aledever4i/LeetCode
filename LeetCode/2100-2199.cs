using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class _2100_2199
    {

        /// <summary>
        /// 2101. Detonate the Maximum Bombs. Tags: Array, Math, Depth-First Search, Breadth-First Search, Graph, Geometry
        /// </summary>
        public static int MaximumDetonation(int[][] bombs)
        {
            var n = bombs.Length;
            var list = new int[n][];
            var result = new int[n];

            for (int i = 0; i < n; i++)
            {
                List<int> points = new List<int>();

                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    if ((Math.Pow(bombs[i][0] - bombs[j][0], 2) + Math.Pow(bombs[i][1] - bombs[j][1], 2)) <= Math.Pow(bombs[i][2], 2))
                    {
                        points.Add(j);
                    }
                }

                list[i] = points.ToArray();
            }

            for (int i = 0; i < n; i++)
            {
                var visited = new List<int>();
                var booms = new List<int>();

                booms.Add(i);
                boom(i, visited, booms);

                result[i] = booms.Distinct().Count();
            }

            return result.Max();

            void boom(int p, List<int> visited, List<int> booms)
            {
                var newBooms = list[p];
                booms.AddRange(newBooms);
                visited.Add(p);

                foreach (var i in newBooms)
                {
                    if (!visited.Contains(i))
                    {
                        boom(i, visited, booms);
                    }
                }
            }
        }

        /// <summary>
        /// 2108. Find First Palindromic String in the Array
        /// </summary>
        public static string FirstPalindrome(string[] words)
        {
            foreach (var word in words)
            {
                var n = word.Length;
                var left = 0;
                var right = n - 1;
                var isBreak = false;
                while (left <= right && !isBreak)
                {
                    if (word[left] != word[right])
                    {
                        isBreak = true;
                    }
                    left++;
                    right--;
                }

                if (!isBreak)
                {
                    return word;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// 2125. Number of Laser Beams in a Bank
        /// </summary>
        public static int NumberOfBeams(string[] bank)
        {


            return 0;
        }

        /// <summary>
        /// 2140. Solving Questions With Brainpower
        /// По аналогии с задачей 1035 попробывал решить через матрицу. В принципе решение прикольное, но не проходит по памяти.
        /// Поэтому старый подход с алгоритмом фибоначчи и кеширующей таблицей подошел.
        /// </summary>
        public static long MostPoints(int[][] questions)
        {
            var cache = new long[questions.Length];

            long choice(int index)
            {
                if (index >= questions.Length)
                {
                    return 0;
                }

                if (cache[index] != 0)
                {
                    return cache[index];
                }

                var choice1 = questions[index][0] + choice(index + questions[index][1] + 1);
                var choice2 = choice(index + 1);

                cache[index] = Math.Max(choice1, choice2);

                return cache[index];
            }

            long max = 0;
            for (int i = 0; i < questions.Length; i++)
            {
                var result = choice(i);
                max = max > result ? max : result;
            }

            return max;


            //var points = new int[questions.Length, questions.Length];

            //for (int i = 0; i < questions.Length; i++)
            //{
            //    var question = questions[i];

            //    var max = 0;
            //    for (int y = 0; y < i; y++)
            //    {
            //        if (questions[y][1] + y < i)
            //        {
            //            max = max > points[y, i] ? max : points[y, i];
            //        }
            //    }

            //    for (int y = i; y < questions.Length; y++)
            //    {
            //        points[i, y] = question[0] + max;
            //    }
            //}

            //var result = 0;
            //for (int i = 0; i < questions.Length; i++)
            //{
            //    var p = points[i, questions.Length - 1];
            //    result = (p > result) ? p : result;
            //}

            //return result;
        }

        /// <summary>
        /// 2149. Rearrange Array Elements by Sign
        /// </summary>
        public static int[] RearrangeArray(int[] nums)
        {
            var result = new int[nums.Length];

            var positiveIndex = 0;
            var negativeIndex = 1;

            foreach (var num in nums)
            {
                if (num > 0)
                {
                    result[positiveIndex] = num;
                    positiveIndex += 2;
                }
                else
                {
                    result[negativeIndex] = num;
                    negativeIndex += 2;
                }
            }

            return result;
        }
    }
}
