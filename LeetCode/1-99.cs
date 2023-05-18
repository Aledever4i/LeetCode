using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class _1_99
    {
        /// <summary>
        /// 9. Palindrome Number. Tags: Math
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static bool IsPalindrome(int x)
        {
            if (x < 0)
            {
                return false;
            }

            return (x.ToString() == string.Join("", x.ToString().Reverse()));
        }

        /// <summary>
        /// 15. 3Sum. Tags: Array, Two Pointers, Sorting
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            var orderedNums =
                nums
                    .GroupBy(num => num)
                    .SelectMany(group =>
                    {
                        var count = group.Count();
                        if (count == 1)
                        {
                            return new int[] { group.Key };
                        }
                        else if (count == 2)
                        {
                            return new int[] { group.Key, group.Key };
                        }
                        else
                        {
                            return new int[] { group.Key, group.Key, group.Key };
                        }
                    })
                    .OrderBy(nums => nums)
                    .ToList();
            var firstPositive = orderedNums.Select((num, index) => new { num, index }).FirstOrDefault(a => a.num >= 0)?.index;
            var hashTable = new Dictionary<string, IList<int>>();

            if (!firstPositive.HasValue)
            {
                return System.Array.Empty<IList<int>>();
            }

            var result = new List<IList<int>>();
            var dict = new Dictionary<int, List<int[]>>();

            var stepX = 0;
            using (var iterX = orderedNums.GetRange(stepX, firstPositive.Value).GetEnumerator())
            {
                while (iterX.MoveNext())
                {
                    var xValue = iterX.Current;

                    using (var iterY = orderedNums.GetRange(stepX + 1, firstPositive.Value - stepX - 1).GetEnumerator())
                    {
                        while (iterY.MoveNext())
                        {
                            var yValue = iterY.Current;
                            if (!dict.ContainsKey(xValue + yValue))
                            {
                                dict.Add(xValue + yValue, new List<int[]>() { new int[] { xValue, yValue } });
                            }
                            else
                            {
                                var item = dict[xValue + yValue];
                                item.Add(new int[] { xValue, yValue });
                            }
                        }
                    }

                    stepX++;
                }
            }

            stepX = firstPositive.Value;
            using (var iterX = orderedNums.GetRange(stepX, orderedNums.Count() - stepX).GetEnumerator())
            {
                while (iterX.MoveNext())
                {
                    var xValue = iterX.Current;

                    using (var iterY = orderedNums.GetRange(stepX + 1, orderedNums.Count() - stepX - 1).GetEnumerator())
                    {
                        while (iterY.MoveNext())
                        {
                            var yValue = iterY.Current;
                            if (!dict.ContainsKey(xValue + yValue))
                            {
                                dict.Add(xValue + yValue, new List<int[]>() { new int[] { xValue, yValue } });
                            }
                            else
                            {
                                var item = dict[xValue + yValue];
                                item.Add(new int[] { xValue, yValue });
                            }
                        }
                    }

                    stepX++;
                }
            }

            foreach (var negative in orderedNums)
            {
                var dictKey = -1 * negative;
                if (negative == 0)
                {
                    continue;
                }

                if (dict.ContainsKey(dictKey))
                {
                    var keys = dict[dictKey];

                    foreach (var key in keys)
                    {
                        var temp = key.ToList();
                        temp.Add(negative);
                        var ordered = temp.OrderBy(num => num);
                        var hash = string.Join("+", ordered);

                        if (!hashTable.ContainsKey(hash))
                        {
                            hashTable.Add(hash, ordered.ToList());
                        }
                    }
                }
            }

            if (dict.ContainsKey(0))
            {
                if (dict[0].Count >= 2)
                {
                    hashTable.Add("0+0+0", new int[] { 0, 0, 0 });
                }
            }

            return hashTable.Values.ToList();
        }

        /// <summary>
        /// 24. Swap Nodes in Pairs. Tags: Linked List, Recursion
        /// </summary>
        /// <param name="head"></param>
        public static ListNode SwapPairs(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            ListNode result = head.next;

            ListNode forward = head;
            ListNode forward2 = null;

            ListNode currentElement = head;


            forward = currentElement.next;
            forward2 = forward.next;
            currentElement.next = forward2;
            forward.next = currentElement;

            while (currentElement != null)
            {
                forward = currentElement.next;

                if (forward == null)
                {
                    break;
                }

                forward2 = forward.next;

                if (forward2 == null)
                {
                    break;
                }

                forward.next = forward2.next;
                currentElement.next = new ListNode(forward2.val, forward);
                currentElement = forward;
            }

            return result;
        }

        /// <summary>
        /// 26. Remove Duplicates from Sorted Array. Tags: Array, Two Pointers
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int RemoveDuplicates(int[] nums)
        {
            var x = nums.Distinct().ToList();
            for (int i = 0; i < x.Count; i++)
            {
                nums[i] = x[i];
            }

            return x.Count;
        }

        /// <summary>
        /// 27. Remove Element. Tags: Array, Two Pointers
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="val"></param>
        public static int RemoveElement(int[] nums, int val)
        {
            var values = nums.Where(num => num != val);
            var valueLength = values.Count();

            for (int i = 0; i < nums.Length; i++)
            {
                if (i < valueLength)
                {
                    nums[i] = values.ElementAt(i);
                }
                else
                {
                    nums[i] = 0;
                }
            }

            return valueLength;
        }

        /// <summary>
        /// 67. Add Binary. Tags: Math, String, Bit Manipulation, Simulation
        /// Задача простая но нужная
        /// </summary>
        public static string AddBinary(string a, string b)
        {
            var charA = a.Reverse().Select(c => Convert.ToInt32(c)).ToArray();
            var charB = b.Reverse().Select(c => Convert.ToInt32(c)).ToArray();

            var aLength = charA.Length;
            var bLength = charB.Length;

            var stringBuilder = new StringBuilder();
            var bonus = 0;

            for (int i = 0; i < Math.Max(aLength, bLength); i++)
            {
                var charByteA = 48;
                var charByteB = 48;

                if (i < aLength)
                {
                    charByteA = charA[i];
                }

                if (i < bLength)
                {
                    charByteB = charB[i];
                }

                if (charByteA == 48 && charByteB == 48 && bonus == 0)
                {
                    stringBuilder.Append(0);
                }
                else if (charByteA == 49 && charByteB == 49 && bonus == 0)
                {
                    stringBuilder.Append(0);
                    bonus = 1;
                }
                else if (bonus == 0 && charByteA != charByteB)
                {
                    stringBuilder.Append(1);
                }
                else if (bonus == 1 && charByteA == 48 && charByteB == 48)
                {
                    stringBuilder.Append(1);
                    bonus = 0;
                }
                else if (bonus == 1 && charByteA == 49 && charByteB == 49)
                {
                    stringBuilder.Append(1);
                    bonus = 1;
                }
                else if (bonus == 1 && charByteA != charByteB)
                {
                    stringBuilder.Append(0);
                    bonus = 1;
                }
            }

            if (bonus == 1)
            {
                stringBuilder.Append(1);
            }

            return string.Join("", stringBuilder.ToString().Reverse());
        }
    }
}
