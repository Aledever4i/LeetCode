using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace LeetCode.Array
{
    public static class ArraySolutions
    {
        /// <summary>
        /// 309. Best Time to Buy and Sell Stock with Cooldown
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public static int MaxProfit(int[] prices)
        {
            var hasStock = false;
            int? currentPrice = null;
            int? currentElementPrice = null;
            int? prevElementPrice = null;

            foreach (var price in prices)
            {
                currentElementPrice = price;

                if (currentElementPrice < prevElementPrice)
                {
                    Console.WriteLine("");
                }
            }

            return 0;
        }

        /// <summary>
        /// 1. Two Sum
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static int[] TwoSum(int[] nums, int target)
        {
            var valueDictionary = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var currentElement = nums[i];
                var search = target - currentElement;

                if (valueDictionary.ContainsKey(search))
                {
                    return new int[] { valueDictionary[search], i };
                }
                else
                {
                    if (!valueDictionary.ContainsKey(currentElement))
                    {
                        valueDictionary.Add(currentElement, i);
                    }
                }
            }

            throw new Exception();
        }

        /// <summary>
        /// 1035. Uncrossed Lines
        /// Высчитывал через матрицу + таблица для кеширования результатов.
        /// TODO: Изучить более легкий алгоритм https://leetcode.com/problems/uncrossed-lines/solutions/3510389/easy-and-fast-c-solution-with-explanation/?orderBy=most_votes&languageTags=csharp
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public static int MaxUncrossedLines(int[] nums1, int[] nums2)
        {
            var cacheTable = new int?[nums1.Length, nums2.Length];

            var coincidences = new int?[nums1.Length][];
            for(int i = 0; i < nums1.Length; i++)
            {
                coincidences[i] = new int?[nums2.Length];
            }

            for (int num1 = 0; num1 < nums1.Length; num1++)
            {
                for (int num2 = 0; num2 < nums2.Length; num2++)
                {
                    coincidences[num1][num2] = (nums1[num1] == nums2[num2]) ? num2 : -1;
                }
            }

            int coincidence(int num1Index, int num2Index)
            {
                var value = cacheTable[num1Index, num2Index];
                if (value == default)
                {
                    int? nearestIndex = coincidences[num1Index].Where(num2 => num2 >= num2Index).FirstOrDefault();

                    if (nearestIndex != null)
                    {
                        if (nearestIndex == nums2.Length - 1 || num1Index == nums1.Length - 1)
                        {
                            value = 1;
                        }
                        else
                        {
                            var tempResultWith = 0;

                            for (int next = num1Index + 1; next < nums1.Length; next++)
                            {
                                var x = coincidence(next, nearestIndex.Value + 1);

                                tempResultWith = (x > tempResultWith) ? x : tempResultWith;
                            }
                                                      
                            value = 1 + tempResultWith;
                        }
                    }
                    else
                    {
                        if (nearestIndex == nums2.Length - 1 || num1Index == nums1.Length - 1)
                        {
                            value = 0;
                        }
                        else
                        {
                            var next = num1Index + 1;
                            value = coincidence(next, nearestIndex ?? num2Index);
                        }
                    }

                    cacheTable[num1Index, num2Index] = value;
                }

                return value ?? 0;
            }

            int result = 0;
            for (int num1 = 0; num1 < nums1.Length; num1++)
            {
                var count = coincidence(num1, 0);

                result = (count > result) ? count : result;
            }
            

            return result;
        }

        /// <summary>
        /// 1491. Average Salary Excluding the Minimum and Maximum Salary
        /// </summary>
        /// <param name="salary"></param>
        /// <returns></returns>
        public static double Average(int[] salary)
        {
            double sum = 0;

            int firstSalary = salary[0];
            int secondSalary = salary[1];

            int minSalary = (firstSalary > secondSalary) ? secondSalary : firstSalary;
            int biggestSalary = (firstSalary > secondSalary) ? firstSalary : secondSalary;

            for (var i = 2; i < salary.Length; i++)
            {
                var iterSalary = salary[i];

                if (iterSalary < minSalary)
                {
                    sum += minSalary;
                    minSalary = iterSalary;
                    continue;
                }
                else if (iterSalary > biggestSalary)
                {
                    sum += biggestSalary;
                    biggestSalary = iterSalary;
                    continue;
                }
                else
                {
                    sum += iterSalary;
                }
            }

            return sum / (salary.Length - 2);
        }

        /// <summary>
        /// 2140. Solving Questions With Brainpower
        /// По аналогии с задачей 1035 попробывал решить через матрицу. В принципе решение прикольное, но не проходит по памяти.
        /// Поэтому старый подход с алгоритмом фибоначчи и кеширующей таблицей подошел.
        /// </summary>
        /// <param name="questions"></param>
        /// <returns></returns>
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
    }
}
