using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Contest
{
    /// <summary>
    /// 12.11.2023
    /// </summary>
    public static class _371
    {
        public static int MaximumStrongPairXor(int[] nums)
        {
            System.Array.Sort(nums);

            var listPair = new List<(int, int)>();
            var n = nums.Length;

            for (int i = 0; i < n; i++)
            {
                var value1 = nums[i];

                listPair.Add((value1, value1));

                for (int j = i + 1; j < n; j++)
                {
                    var value2 = nums[j];

                    if (Math.Min(value2, value1) >= value2 - value1)
                    {
                        listPair.Add((value1, value2));
                    }
                }
            }

            var result = 0;

            foreach (var pair in listPair)
            {
                result = Math.Max(pair.Item1 ^ pair.Item2, result);
            }

            return result;
        }

        public static IList<string> FindHighAccessEmployees(IList<IList<string>> access_times)
        {
            var dict = new Dictionary<string, List<(int, int)>>();

            foreach (var item in access_times)
            {
                if (!dict.TryAdd(item.ElementAt(0), new List<(int, int)>() { (int.Parse(item.ElementAt(1).Substring(0, 2)), int.Parse(item.ElementAt(1).Substring(2, 2))) }))
                {
                    dict[item.ElementAt(0)].Add((int.Parse(item.ElementAt(1).Substring(0, 2)), int.Parse(item.ElementAt(1).Substring(2, 2))));
                }
            }

            var result = new List<string>();
            foreach (var access in dict)
            {
                var schedule = access.Value.OrderBy(v => v.Item1).ThenBy(v => v.Item2);

                for (int i = 0; i < access.Value.Count - 2; i++)
                {
                    var start = schedule.ElementAt(i);
                    var end = schedule.ElementAt(i + 2);

                    if (
                        (end.Item1 - start.Item1 == 1 && (60 - start.Item2) + end.Item2 <= 59)
                        || (end.Item1 == start.Item1 && end.Item2 > start.Item2)
                    )
                    {
                        result.Add(access.Key);
                        break;
                    }
                }
            }

            return result;
        }


        public static int MinOperations(int[] nums1, int[] nums2)
        {
            var n = nums1.Length;

            var lastNums1 = nums1[n - 1];
            var lastNums2 = nums2[n - 1];

            var countWithoutLastSwap = 0;
            for (int i = n - 2; i >= 0; i--)
            {
                var curNums1 = nums1[i];
                var curNums2 = nums2[i];

                if (lastNums1 >= curNums1 && lastNums2 >= curNums2)
                {
                    continue;
                }
                else if ((lastNums1 < curNums1 || lastNums2 < curNums2) && lastNums1 >= curNums2 && lastNums2 >= curNums1)
                {
                    countWithoutLastSwap++;
                }
                else
                {
                    return -1;
                }
            }

            var countWithLastSwap = 1;
            lastNums1 = nums2[n - 1];
            lastNums2 = nums1[n - 1];
            for (int i = n - 2; i >= 0; i--)
            {
                var curNums1 = nums1[i];
                var curNums2 = nums2[i];

                if (lastNums1 >= curNums1 && lastNums2 >= curNums2)
                {
                    continue;
                }
                else if ((lastNums1 < curNums1 || lastNums2 < curNums2) && lastNums1 >= curNums2 && lastNums2 >= curNums1)
                {
                    countWithLastSwap++;
                }
                else
                {
                    return -1;
                }
            }

            return Math.Min(countWithLastSwap, countWithoutLastSwap);
        }
        public static int MaximumStrongPairXor2(int[] nums)
        {
            System.Array.Sort(nums);

            var listPair = new List<(int, int)>();
            var n = nums.Length;

            for (int i = 0; i < n; i++)
            {
                var value1 = nums[i];
                for (int j = i + 1; j < n; j++)
                {
                    var value2 = nums[j];

                    if (Math.Min(value2, value1) >= value2 - value1)
                    {
                        listPair.Add((value1, value2));
                    }
                }
            }

            var result = 0;

            foreach (var pair in listPair.Take(100))
            {
                result = Math.Max(pair.Item1 ^ pair.Item2, result);
            }

            return result;
        }
    }
}
