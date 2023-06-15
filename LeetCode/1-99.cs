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
        /// 14. Longest Common Prefix. Tags: String, Trie
        /// </summary>
        public static string LongestCommonPrefix(string[] strs)
        {
            var start = strs[0];
            var currentCommon = start.AsSpan().ToArray();

            if (strs.Length == 1 || start.Length == 0)
            {
                return strs[0];
            }

            for (int i = 1; i < strs.Length; i++)
            {
                var chars = strs[i].AsSpan();
                var list = new List<char>();

                for (int y = 0; y < currentCommon.Length && y < chars.Length; y++)
                {
                    if (currentCommon[y].Equals(chars[y]))
                    {
                        list.Add(chars[y]);
                    }
                    else
                    {
                        break;
                    }
                }

                currentCommon = list.ToArray();
            }

            return string.Join("", currentCommon);
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
        /// 28. Find the Index of the First Occurrence in a String. Tags: Two Pointers, String, String Matching
        /// </summary>
        public static int StrStr(string haystack, string needle)
        {
            var n = needle.Length;
            var h = haystack.Length;

            if (n > h || n == 0)
            {
                return -1;
            }

            for (int i = 0; i <= h - n; i++)
            {
                var end = i + n;
                if (haystack[i] == needle[0] && haystack[i..end].Equals(needle))
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// 66. Plus One. Tags: Array, Math
        /// </summary>
        public static int[] PlusOne(int[] digits)
        {
            // Отличный пример
            //int n = digits.Length;
            //int carry = 1;

            //for (int i = n - 1; i >= 0; i--)
            //{
            //    int sum = digits[i] + carry;
            //    digits[i] = sum % 10;
            //    carry = sum / 10;

            //    if (carry == 0)
            //    {
            //        // No need to carry over to the next digit
            //        break;
            //    }
            //}

            //You do not need to copy the digits to the new array (using digits.CopyTo(result,1)). Because the new array will always have a 1 as the first digit,
            //and a 0 for every digit after that, you can just set result[0] = 1 and then return it.
            //if (carry == 1)
            //{
            //    // Need to add an additional digit
            //    int[] result = new int[n + 1];
            //    result[0] = 1;
            //    return result;
            //}

            //return digits;

            var list = new List<int>();
            bool discharge = true;

            for (int i = digits.Length; i > 0; i--)
            {
                var number = digits[i - 1];

                if (number == 9 && discharge)
                {
                    discharge = true;
                    list.Add(0);
                }
                else if (discharge)
                {
                    discharge = false;
                    list.Add(number + 1);
                }
                else
                {
                    list.AddRange(digits[..i].Reverse());
                    break;
                }
            }

            if (discharge)
            {
                list.Add(1);
            }

            list.Reverse();

            return list.ToArray();
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

        /// <summary>
        /// 80. Remove Duplicates from Sorted Array II. Tags: Array, Two Pointers
        /// </summary>
        public static int RemoveDuplicates2(int[] nums)
        {
            var list = new List<int>();
            bool skip = false;
            var previousNum = int.MinValue;

            foreach (var num in nums)
            {
                if (previousNum != num)
                {
                    skip = false;
                    previousNum = num;
                    list.Add(num);
                }
                else if (!skip)
                {
                    skip = true;
                    list.Add(num);
                }
            }

            for (int i = 0; i < list.Count; i++)
            {
                nums[i] = list[i];
            }

            return list.Count;
        }

        /// <summary>
        /// 83. Remove Duplicates from Sorted List. Tags: Linked List
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            var result = head;
            var currentElement = head;
            var previousValue = head.val;

            while (currentElement.next != null)
            {
                var nextValue = currentElement.next;

                if (previousValue == nextValue.val)
                {
                    currentElement.next = currentElement.next.next;
                }
                else
                {
                    previousValue = nextValue.val;
                    currentElement = currentElement.next;
                }
            }

            return result;
        }

        /// <summary>
        /// 88. Merge Sorted Array. Tags: Array, Two Pointers, Sorting
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>
        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int start = nums1.Count() - 1;
            int nums1Index = m - 1;
            int nums2Index = n - 1;

            for (int i = start; i >= 0; i--)
            {
                var nums1Value = int.MinValue;
                var nums2Value = int.MinValue;

                if (nums1Index >= 0)
                {
                    nums1Value = nums1[nums1Index];
                }
                if (nums2Index >= 0)
                {
                    nums2Value = nums2[nums2Index];
                }

                if (nums1Value >= nums2Value)
                {
                    nums1[i] = nums1Value;
                    nums1Index--;
                }
                else
                {
                    nums1[i] = nums2Value;
                    nums2Index--;
                }
            }
        }

        /// <summary>
        /// 94. Binary Tree Inorder Traversal. Tags: Stack, Tree, Depth-First Search, Binary Tree
        /// </summary>
        public static IList<int> InorderTraversal(TreeNode root)
        {
            var result = new List<int>();
            TreeNode curr = root;
            TreeNode nextRoot = null;

            while (curr != null)
            {
                if (curr.left == null)
                {
                    result.Add(curr.val);
                    curr = curr.right;
                }
                else
                {
                    nextRoot = curr.left;
                    while (nextRoot.right != null)
                    {
                        nextRoot = nextRoot.right;
                    }

                    nextRoot.right = curr;
                    TreeNode temp = curr;
                    curr = curr.left;
                    temp.left = null;
                }
            }

            return result;
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
