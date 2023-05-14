using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class _1700_1799
    {
        /// <summary>
        /// 1799. Maximize Score After N Operations. Tags: Array, Math, Dynamic Programming, Backtracking, Bit Manipulation, Number Theory, Bitmask
        /// Падаем на [415,230,471,705,902,87]
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int MaxScore(int[] nums)
        {
            //(int gcd, int iter, int elementToRemove1, int elementToRemove2) GetElement(List<int> numsList, int element, int tempIter, int tempElement, int tempGCD)
            //{
            //    for (int y = 0; y < numsList.Count; y++)
            //    {
            //        var valueY = numsList[y];
            //        if (valueY == element)
            //        {
            //            continue;
            //        }
            //        else if (valueY == tempElement)
            //        {
            //            continue;
            //        }

            //        var (tempGCDy, tempIterY) = (element == 0) ? (valueY, 0) : GCD(valueY, element);

            //        if (tempGCDy > tempGCD)
            //        {
            //            tempGCD = tempGCDy;
            //            tempIter = tempIterY;
            //            tempElement = valueY;
            //        }
            //        else if (tempGCD == tempGCDy && tempIterY < tempIter)
            //        {
            //            return GetElement(numsList.Where(num => num != element).ToList(), valueY, tempIterY, valueY, tempGCD);
            //        }
            //    }

            //    return (tempGCD, tempIter, element, tempElement);
            //}

            //(int, int) GCD(int num1, int num2)
            //{
            //    int Remainder;
            //    int iter = 0;

            //    while (num2 != 0)
            //    {
            //        Remainder = num1 % num2;
            //        num1 = num2;
            //        num2 = Remainder;
            //        iter++;
            //    }

            //    return (num1, iter);
            //}

            //    var element = numsList[0];
            //    var gcd = 0;
            //    var elementForRemoveIndex = 0;
            //    var initialElementRemove = 0;
            //    var iter = int.MaxValue;

            //    (int returnGCD, int returnIter, int elementToRemove1, int elementToRemove2) = GetElement(numsList, element, iter, element, gcd);

            //    gcdList.Add(returnGCD);
            //    numsList.Remove(elementToRemove1);
            //    numsList.Remove(elementToRemove2);

            //    if (numsList.Count == 0)
            //    {
            //        break;
            //    }

            //var numsList = nums.OrderByDescending(num => num).ToList();
            int GCD(int num1, int num2)
            {
                int Remainder;

                while (num2 != 0)
                {
                    Remainder = num1 % num2;
                    num1 = num2;
                    num2 = Remainder;
                }

                return num1;
            }

            var numsList = nums.ToList();
            var gcdList = new List<int>();
            var gcdDictionary = new Dictionary<(int, int), int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var element = nums[i];

                foreach (var element2 in nums.Where((num, index) => index != i))
                {
                    if (element == element2 && !gcdDictionary.ContainsKey((element, element2)))
                    {
                        gcdDictionary.TryAdd((element, element2), element);
                    }
                    else
                    {
                        if (!gcdDictionary.ContainsKey((element, element2)) && !gcdDictionary.ContainsKey((element2, element)))
                        {
                            var gcd = GCD(element, element2);

                            gcdDictionary.TryAdd((element, element2), gcd);
                        }
                    }
                }
            }

            while (true)
            {
                if (gcdDictionary.Count == 0)
                {
                    break;
                }

                var key = gcdDictionary.OrderByDescending(value => value.Value).First();

                if (numsList.Contains(key.Key.Item1) && numsList.Contains(key.Key.Item2))
                {
                    var values = gcdDictionary.Where(
                        value =>
                            value.Value == key.Value
                            && numsList.Contains(value.Key.Item1) 
                            && numsList.Contains(value.Key.Item2)
                    );

                    if (values.Count() == 1)
                    {
                        numsList.Remove(key.Key.Item1);
                        numsList.Remove(key.Key.Item2);
                    }
                    else
                    {
                        var redeemValues = values.Select(value => value.Key.Item1).Union(values.Select(value => value.Key.Item2)).Distinct();

                        var values1 = redeemValues.Select(searchMinimal =>
                        {
                            var searchValue = gcdDictionary
                                .Where(
                                    value =>
                                    (value.Key.Item1 == searchMinimal || value.Key.Item2 == searchMinimal)
                                    && (value.Value < key.Value || value.Value == 1)
                                    && numsList.Contains(value.Key.Item1)
                                    && numsList.Contains(value.Key.Item2)
                                ).Max(value => value.Value);

                            return (searchMinimal, searchValue);
                        }).OrderBy(v => v.searchValue);

                        var top2 = values1.Take(2).ToList();

                        numsList.Remove(top2.ElementAt(0).searchMinimal);
                        numsList.Remove(top2.ElementAt(1).searchMinimal);
                    }

                    gcdList.Add(key.Value);
                }
                else
                {
                    gcdDictionary.Remove(key.Key);
                }
            }

            return gcdList.OrderBy(gcd => gcd).Select((gcd, index) => (index + 1) * gcd).Sum();
        }
    }
}