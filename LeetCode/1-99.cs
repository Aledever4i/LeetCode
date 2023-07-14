﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class _1_99
    {
        /// <summary>
        /// 6. Zigzag Conversion
        /// </summary>
        public static string ConvertZigZag(string s, int numRows)
        {
            if (numRows <= 2)
            {
                return s;
            }

            return string.Empty;
        }

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
        /// 20. Valid Parentheses. Tags: String, Stack
        /// </summary>
        public static bool IsValid(string s)
        {
            bool isOpen(char c)
            {
                return (c == '(' || c == '{' || c == '[');
            }

            var chars = s.ToCharArray();
            var n = chars.Length;

            if (n % 2 == 1)
            {
                return false;
            }

            var dict = new Dictionary<char, char>() { { '(', ')' }, { '{', '}' }, { '[', ']' } };

            var stack = new Stack<char>();

            for (int i = 0; i < n; i++)
            {
                var x = chars[i];

                if (isOpen(x))
                {
                    stack.Push(x);
                }
                else
                {
                    if (!stack.TryPop(out char r))
                    {
                        return false;
                    }

                    if (dict[r] != x)
                    {
                        return false;
                    }
                }
            }

            if (stack.Count > 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 21. Merge Two Sorted Lists
        /// </summary>
        public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            var result = new ListNode();
            ListNode head = result;
            var current1 = list1;
            var current2 = list2;

            while (current1 != null)
            {
                while (current2 != null && current2.val < current1.val)
                {
                    result.next = current2;
                    result = result.next;
                    current2 = current2.next;
                }

                result.next = current1;
                result = result.next;
                current1 = current1.next;
            }

            while (current2 != null)
            {
                result.next = current2;
                result = result.next;
                current2 = current2.next;
            }

            return head.next;
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
        /// 35. Search Insert Position. Tags: Array, Binary Search
        /// </summary>
        public static int SearchInsert(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length;

            while (left < right)
            {
                var mid = (left + right) / 2;
                var value = nums[mid];

                if (target == value)
                {
                    return mid;
                }
                else if (target >= value)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return left;
        }

        /// <summary>
        /// 45. Jump Game II
        /// </summary>
        public static int Jump2(int[] nums)
        {
            var currentIndex = 0;
            var result = 0;
            var n = nums.Length;
            var maxJump = 0;

            if (nums.Length == 1)
            {
                return 0;
            }

            if (currentIndex + nums[0] >= n - 1)
            {
                return 1;
            }

            while (currentIndex < n - 1)
            {
                var step = nums[currentIndex];
                var current = currentIndex;

                if (current + step >= n - 1)
                {
                    return result + 1;
                }

                for (int i = current + step; i > current; i--)
                {
                    if (i + nums[i] > maxJump)
                    {
                        maxJump = i + nums[i];
                        currentIndex = i;
                    }
                }

                maxJump = 0;
                result++;
            }

            return result;
        }

        /// <summary>
        /// 50. Pow(x, n). Tags: Math, Recursion
        /// </summary>
        public static double MyPow(double x, long n)
        {
            //if (n == 0)
            //{
            //    return 1;
            //}
            //else if (n < 0)
            //{
            //    return 1 / MyPow(x, -n);
            //}
            //else
            //{
            //    if (n % 2 == 0)
            //    {
            //        return MyPow(x * x, n / 2);
            //    }
            //    else
            //    {
            //        return x * MyPow(x * x, (n - 1) / 2);
            //    }
            //}

            double value = (n < 0) ? 1 / Math.Abs(x) : Math.Abs(x);
            if (n == 0)
            {
                return 1;
            }
            else if (value == 1)
            {
                if (n % 2 == 1)
                {
                    return x;
                }

                return Math.Abs(x);
            }

            long pow = Math.Abs(n);
            double result = value;

            for (long i = 1; i < pow; i++)
            {
                result *= value;
            }

            return (x > 0 || (x < 0 && n % 2 == 0)) ? result : -result;
        }

        /// <summary>
        /// 55. Jump Game
        /// </summary>
        public static bool CanJump(int[] nums)
        {
            var endIndex = nums.Length - 1;
            if (endIndex <= 0)
            {
                return true;
            }
            var results = new Dictionary<int, bool>();
            return CheckJump(0, 0);

            bool CheckJump(int position, int step)
            {
                if (results.ContainsKey(position + step))
                {
                    return results[position + step];
                }

                if (position + step >= endIndex)
                {
                    results[position + step] = true;

                    return results[position + step];
                }

                var jump = nums[position + step];
                var result = false;

                for (int i = jump; i > 0; i--)
                {
                    result |= CheckJump(position + step, i);
                    if (result)
                    {
                        return true;
                    }
                }

                results[position + step] = result;
                return result;
            }
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
        /// 69. Sqrt(x). Tags: Math, Binary Search
        /// </summary>
        public static int MySqrt(int x)
        {
            if (x == 0)
            { return 0; }

            int left = 1;
            int right = x;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int sqrt = x / mid;

                if (sqrt == mid)
                { return mid; }
                else if (sqrt < mid)
                { right = mid - 1; }
                else
                { left = mid + 1; }
            }

            return right;

            //var dict = new Dictionary<ulong, ulong>();
            //for (ulong i = 0; i < 65536; i++)
            //{
            //    dict.Add(i, i * i);
            //}
            //var filtered = dict.Where(value => value.Value <= (ulong)x);
            //return (int)filtered.Last().Key;
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
