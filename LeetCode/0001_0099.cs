using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class _0001_0099
    {
        /// <summary>
        /// 1. Two Sum
        /// </summary>
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
        /// 2. Add Two Numbers
        /// </summary>
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var hasDecimal = false;
            ListNode result = null;
            var list = new List<int>();

            while (l1 != null && l2 != null)
            {
                var a = l1.val;
                l1 = l1.next;

                var b = l2.val;
                l2 = l2.next;

                var value = a + b + (hasDecimal ? 1 : 0);

                hasDecimal = (value > 9);
                value %= 10;
                list.Add(value);
            }

            while (l1 != null)
            {
                var a = l1.val;
                l1 = l1.next;
                var value = a + (hasDecimal ? 1 : 0);
                hasDecimal = (value > 9);
                value %= 10;
                list.Add(value);
            }

            while (l2 != null)
            {
                var a = l2.val;
                l2 = l2.next;
                var value = a + (hasDecimal ? 1 : 0);
                hasDecimal = (value > 9);
                value %= 10;
                list.Add(value);
            }

            if (hasDecimal)
            {
                list.Add(1);
            }

            for (int i = list.Count - 1; i >= 0; i--)
            {
                result = new ListNode(list.ElementAt(i), result);
            }

            return result;
        }

        /// <summary>
        /// 3. Longest Substring Without Repeating Characters
        /// </summary>
        public static int LengthOfLongestSubstring(string s)
        {
            var chars = s.ToCharArray();
            var n = chars.Length;
            var dict = new HashSet<char>();

            int left = 0, right = 0;
            int longestLength = 0;

            while (right < n)
            {
                var c = chars[right];

                if (!dict.Contains(c))
                {
                    dict.Add(c);
                    right++;
                    longestLength = Math.Max(longestLength, dict.Count());
                }
                else
                {
                    while (dict.Contains(c))
                    {
                        var removeChar = chars[left];
                        dict.Remove(removeChar);
                        left++;
                    }
                }
            }

            return longestLength;
        }

        /// <summary>
        /// 5. Longest Palindromic Substring
        /// </summary>
        public static string LongestPalindrome(string s)
        {
            if (s.Distinct().Count() == 1)
            {
                return s;
            }

            int[] ans = new int[] { 0, 0 };

            for (int i = 0; i < s.Length; i++)
            {
                int oddLength = expand(i, i, s);
                if (oddLength > ans[1] - ans[0] + 1)
                {
                    int dist = oddLength / 2;
                    ans[0] = i - dist;
                    ans[1] = i + dist;
                }

                int evenLength = expand(i, i + 1, s);
                if (evenLength > ans[1] - ans[0] + 1)
                {
                    int dist = (evenLength / 2) - 1;
                    ans[0] = i - dist;
                    ans[1] = i + 1 + dist;
                }
            }

            int start = ans[0];
            int end = ans[1] + 1;
            return s[start..end];

            int expand(int i, int j, string s)
            {
                int left = i;
                int right = j;

                while (left >= 0 && right < s.Length && s.ElementAt(left) == s.ElementAt(right))
                {
                    left--;
                    right++;
                }

                return right - left - 1;
            }
        }

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
        /// 7. Reverse Integer
        /// </summary>
        public static int Reverse(int x)
        {
            var result = 0;

            while (x != 0)
            {
                var remainder = x % 10;
                var temp = result * 10 + remainder;

                if ((temp - remainder) / 10 != result)
                {
                    return 0;
                }

                result = temp;
                x /= 10;
            }

            return result;
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
        /// 11. Container With Most Water
        /// </summary>
        public static int MaxArea(int[] height)
        {
            var n = height.Length;
            int left = 0, right = n - 1;
            var result = 0;

            while (left < right)
            {
                result = Math.Max(result, Math.Min(height[left], height[right]) * (right - left));

                if (height[left] > height[right])
                {
                    right--;
                }
                else
                {
                    left++;
                }
            }

            return result;
        }

        /// <summary>
        /// 13. Roman to Integer
        /// </summary>
        public static int RomanToInt(string s)
        {
            var result = 0;

            while (s.Length > 0)
            {
                if (s.IndexOf("MMM") > -1)
                {
                    result += 3000;
                    s = s.Remove(s.IndexOf("MMM"), 3);
                }
                else if (s.IndexOf("MM") > -1)
                {
                    result += 2000;
                    s = s.Remove(s.IndexOf("MM"), 2);
                }
                else if (s.IndexOf("CM") > -1)
                {
                    result += 900;
                    s = s.Remove(s.IndexOf("CM"), 2);
                }
                else if (s.IndexOf("M") > -1)
                {
                    result += 1000;
                    s = s.Remove(s.IndexOf("M"), 1);
                }
                else if (s.IndexOf("DCCC") > -1)
                {
                    result += 800;
                    s = s.Remove(s.IndexOf("DCCC"), 4);
                }
                else if (s.IndexOf("DCC") > -1)
                {
                    result += 700;
                    s = s.Remove(s.IndexOf("DCC"), 3);
                }
                else if (s.IndexOf("DC") > -1)
                {
                    result += 600;
                    s = s.Remove(s.IndexOf("DC"), 2);
                }
                else if (s.IndexOf("CD") > -1)
                {
                    result += 400;
                    s = s.Remove(s.IndexOf("CD"), 2);
                }
                else if (s.IndexOf("D") > -1)
                {
                    result += 500;
                    s = s.Remove(s.IndexOf("D"), 1);
                }
                else if (s.IndexOf("CCC") > -1)
                {
                    result += 300;
                    s = s.Remove(s.IndexOf("CCC"), 3);
                }
                else if (s.IndexOf("CC") > -1)
                {
                    result += 200;
                    s = s.Remove(s.IndexOf("CC"), 2);
                }
                else if (s.IndexOf("XC") > -1)
                {
                    result += 90;
                    s = s.Remove(s.IndexOf("XC"), 2);
                }
                else if (s.IndexOf("C") > -1)
                {
                    result += 100;
                    s = s.Remove(s.IndexOf("C"), 1);
                }
                else if (s.IndexOf("LXXX") > -1)
                {
                    result += 80;
                    s = s.Remove(s.IndexOf("LXXX"), 4);
                }
                else if (s.IndexOf("LXX") > -1)
                {
                    result += 70;
                    s = s.Remove(s.IndexOf("LXX"), 3);
                }
                else if (s.IndexOf("LX") > -1)
                {
                    result += 60;
                    s = s.Remove(s.IndexOf("LX"), 2);
                }
                else if (s.IndexOf("XL") > -1)
                {
                    result += 40;
                    s = s.Remove(s.IndexOf("XL"), 2);
                }
                else if (s.IndexOf("L") > -1)
                {
                    result += 50;
                    s = s.Remove(s.IndexOf("L"), 1);
                }
                else if (s.IndexOf("XXX") > -1)
                {
                    result += 30;
                    s = s.Remove(s.IndexOf("XXX"), 3);
                }
                else if (s.IndexOf("XX") > -1)
                {
                    result += 20;
                    s = s.Remove(s.IndexOf("XX"), 2);
                }
                else if (s.IndexOf("IX") > -1)
                {
                    result += 9;
                    s = s.Remove(s.IndexOf("IX"), 2);
                }
                else if (s.IndexOf("X") > -1)
                {
                    result += 10;
                    s = s.Remove(s.IndexOf("X"), 1);
                }
                else if (s.IndexOf("VIII") > -1)
                {
                    result += 8;
                    s = s.Remove(s.IndexOf("VIII"), 4);
                }
                else if (s.IndexOf("VII") > -1)
                {
                    result += 7;
                    s = s.Remove(s.IndexOf("VII"), 3);
                }
                else if (s.IndexOf("VI") > -1)
                {
                    result += 6;
                    s = s.Remove(s.IndexOf("VI"), 2);
                }
                else if (s.IndexOf("IV") > -1)
                {
                    result += 4;
                    s = s.Remove(s.IndexOf("IV"), 2);
                }
                else if (s.IndexOf("V") > -1)
                {
                    result += 5;
                    s = s.Remove(s.IndexOf("V"), 1);
                }
                else if (s.IndexOf("III") > -1)
                {
                    result += 3;
                    s = s.Remove(s.IndexOf("III"), 3);
                }
                else if (s.IndexOf("II") > -1)
                {
                    result += 2;
                    s = s.Remove(s.IndexOf("II"), 2);
                }
                else if (s.IndexOf("I") > -1)
                {
                    result += 1;
                    s = s.Remove(s.IndexOf("I"), 1);
                }
            }

            return result;
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
        /// 19. Remove Nth Node From End of List
        /// </summary>
        public static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var count = 0;

            var current = head;
            while (current.next != null)
            {
                current = current.next;
                count++;
            }

            int removeCount = count - n - 1;

            if (removeCount == -1)
            {
                return head.next;
            }

            current = head;
            for (int i = 0; i < removeCount; i++)
            {
                current = current.next;
            }

            current.next = current.next.next;
            return head;
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
        /// 43. Multiply Strings
        /// </summary>
        public static string Multiply(string num1, string num2)
        {
            var n1 = BigInteger.Parse(num1);
            var n2 = BigInteger.Parse(num2);

            return (n1 * n2).ToString();
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
        /// 46. Permutations
        /// </summary>
        public static IList<IList<int>> Permute(int[] nums)
        {
            var result = new List<IList<int>>();

            Backtrack(new List<int>(), result, nums);

            return result;

            void Backtrack(List<int> curr, List<IList<int>> ans, int[] nums)
            {
                if (curr.Count == nums.Length)
                {
                    ans.Add(new List<int>(curr));
                    return;
                }

                foreach (int num in nums)
                {
                    if (!curr.Contains(num))
                    {
                        curr.Add(num);
                        Backtrack(curr, ans, nums);
                        curr.RemoveAt(curr.Count - 1);
                    }
                }
            }
        }

        /// <summary>
        /// 47. Permutations II
        /// </summary>
        public static IList<IList<int>> PermuteUnique(int[] nums)
        {
            var dict = new HashSet<string>();
            var n = nums.Length;
            var result = new List<IList<int>>();
            var indexVisited = new HashSet<int>();

            Backtrack(new List<int>(), string.Empty, nums);

            void Backtrack(List<int> curr, string pattern, int[] nums)
            {
                if (curr.Count == nums.Length)
                {
                    result.Add(new List<int>(curr));
                    return;
                }

                for (int i = 0; i < nums.Length; i++)
                {
                    var value = nums[i];
                    var newPattern = $"{pattern}{value}";

                    if (!indexVisited.Contains(i) && dict.Add(newPattern))
                    {
                        curr.Add(value);
                        indexVisited.Add(i);
                        Backtrack(curr, newPattern, nums);
                        curr.RemoveAt(curr.Count - 1);
                        indexVisited.Remove(i);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 49. Group Anagrams
        /// </summary>
        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var dict = new Dictionary<string, List<string>>();

            foreach (var str in strs)
            {
                var ordered = string.Concat(str.OrderBy(s => s).TakeWhile(char.IsLetter));

                if (dict.ContainsKey(ordered))
                {
                    dict[ordered].Add(str);
                }
                else
                {
                    dict.Add(ordered, new List<string>() { str });
                }
            }

            return dict.Keys.Select(key => (IList<string>)dict[key]).ToList();
        }

        /// <summary>
        /// 50. Pow(x, n). Tags: Math, Recursion
        /// </summary>
        public static double MyPow(double x, long n)
        {
            if (n == 0)
            {
                return 1;
            }
            else if (n < 0)
            {
                return 1 / MyPow(x, -n);
            }
            else
            {
                if (n % 2 == 0)
                {
                    return MyPow(x * x, n / 2);
                }
                else
                {
                    return x * MyPow(x * x, (n - 1) / 2);
                }
            }
        }

        /// <summary>
        /// 54. Spiral Matrix
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static IList<int> SpiralOrder(int[][] matrix)
        {
            var x = matrix[0].Length;
            var y = matrix.Length;
            var result = new List<int>();

            var xCicle = 0;
            var yCicle = 0;
            var xReturnCicle = 0;
            var yReturnCicle = 0;

            var positionX = 0;
            var positionY = 0;

            var canContinueX = true;
            var canContinueY = false;

            while (true)
            {
                if (canContinueX)
                {
                    if ((xCicle > 0 && positionX + xCicle < x - 1) || xCicle == 0)
                    {
                        positionX = xCicle;

                        result.Add(matrix[positionY][positionX]);

                        canContinueY = true;
                    }

                    for (int ixright = positionX + 1; ixright < x - xCicle - 1; ++ixright)
                    {
                        positionX = ixright;

                        result.Add(matrix[positionY][positionX]);

                        canContinueY = true;
                    }

                    if (positionX < x - xCicle)
                    {
                        if (positionX + 1 + xCicle < x)
                        {
                            positionX += 1;
                            result.Add(matrix[positionY][positionX]);

                            canContinueY = true;
                        }
                    }
                }
                canContinueX = false;
                xCicle += 1;

                if (canContinueY)
                {
                    for (int yxdown = positionY + 1; yxdown < y - yCicle - 1; ++yxdown)
                    {
                        positionY = yxdown;

                        result.Add(matrix[positionY][positionX]);

                        canContinueX = true;
                    }

                    if (positionY < y - yCicle - 1)
                    {
                        positionY += 1;
                        result.Add(matrix[positionY][positionX]);

                        canContinueX = true;
                    }
                }
                canContinueY = false;
                yCicle += 1;

                if (canContinueX)
                {
                    for (int ixright = positionX - 1; ixright > xReturnCicle; --ixright)
                    {
                        positionX = ixright;

                        result.Add(matrix[positionY][positionX]);

                        canContinueY = true;
                    }

                    if (positionX - xReturnCicle > 0)
                    {
                        positionX -= 1;
                        result.Add(matrix[positionY][positionX]);

                        canContinueY = true;
                    }
                }

                canContinueX = false;
                xReturnCicle += 1;

                if (canContinueY)
                {
                    for (int yxdown = positionY - 1; yxdown > yReturnCicle; --yxdown)
                    {
                        positionY = yxdown;

                        result.Add(matrix[positionY][positionX]);

                        canContinueX = true;
                    }
                }

                canContinueY = false;
                yReturnCicle += 1;

                if (xCicle + yCicle > x + y)
                {
                    break;
                }
            }

            return result;
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

        // 58. Length of Last Word
        public static int LengthOfLastWord(string s)
        {
            return (s.Trim().Split().Reverse().First()).Length;
        }

        /// <summary>
        /// 59. Spiral Matrix II
        /// </summary>
        public static int[][] GenerateMatrix(int n)
        {
            int[][] result = new int[n][];
            for (int i = 0; i < n; i++)
            {
                result[i] = new int[n];
            }

            var elements = n * n;
            var value = 1;

            var x = 0;
            var y = 0;
            var dx = 1;
            var dy = 1;

            while (value <= elements)
            {
                result[x][y] = value;

                if (y == dy - 1 && x < n - dx)
                {
                    x++;
                }
                else if (x == n - dx && y < n - dy)
                {
                    y++;
                }
                else if (x > dx - 1)
                {
                    x--;
                }
                else if (y > dy)
                {
                    y--;
                    if (y == dy && x == dx - 1)
                    {
                        dx++;
                        dy++;
                    }
                }

                value++;
            }

            int[][] pivot = new int[n][];
            for (int i = 0; i < n; i++)
            {
                pivot[i] = new int[n];
            }
            for (int yp = 0; yp < n; yp++)
            {
                for (int xp = 0; xp < n; xp++)
                {
                    pivot[yp][xp] = result[xp][yp];
                }
            }

            return pivot;
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
        /// 70. Climbing Stairs
        /// Эта задача кроссылка с задачи 2466 на форуме. Неожиданно для себя осознал что это последовательность фибоначчи.
        /// </summary>
        public static int ClimbStairs(int n)
        {
            var cache = new int[n + 1];
            cache[0] = 1;
            cache[1] = 2;

            for (int i = 2; i <= n; i++)
            {
                cache[i] = cache[i - 1] + cache[i - 2];
            }

            return cache[n];
        }

        /// <summary>
        /// 75. Sort Colors
        /// </summary>
        public static void SortColors(int[] nums)
        {
            var dict = new Dictionary<int, int>();
            dict[0] = 0;
            dict[1] = 0;
            dict[2] = 0;

            foreach (var num in nums)
            {
                dict[num]++;
            }

            var index = 0;
            foreach (var v in dict.Keys)
            {
                for (int i = 0; i < dict[v]; i++)
                {
                    nums[index] = v;
                    index++;
                }
            }
        }

        /// <summary>
        /// 76. Minimum Window Substring
        /// </summary>
        public static string MinWindow(string s, string t)
        {
            if (t.Length > s.Length)
            {
                return string.Empty;
            }

            int[] map = new int[128];
            int nt = t.Length;
            int start = 0, end = 0, minLen = int.MaxValue, startIndex = 0;

            foreach (int i in t)
            {
                map[i]++;
            }

            while (end < s.Length)
            {
                if (map[s[end++]]-- > 0)
                {
                    nt--;
                }

                while (nt == 0)
                {
                    if (end - start < minLen)
                    {
                        startIndex = start;
                        minLen = end - start;
                    }

                    if (map[s[start++]]++ == 0)
                    {
                        nt++;
                    }
                }
            }

            return minLen == int.MaxValue ? string.Empty : s.Substring(startIndex, minLen);
        }

        /// <summary>
        /// 77. Combinations
        /// </summary>
        public static IList<IList<int>> Combine(int n, int k)
        {
            IList<IList<int>> result = new List<IList<int>>();

            for (int i = 1; i <= n - k; i++)
            {
                var newElement = new List<int>();
                var range = Enumerable.Range(i, k - 1 + i);
            }

            return result;
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
        /// 86. Partition List
        /// </summary>
        public static ListNode Partition(ListNode head, int x)
        {
            var before = new Queue<ListNode>();
            var after = new Queue<ListNode>();

            if (head == null)
            {
                return head;
            }

            var current = head;
            while (current != null)
            {
                if (current.val < x)
                {
                    before.Enqueue(current);
                }
                else
                {
                    after.Enqueue(current);
                }

                current = current.next;
            }

            ListNode resultHead = null;
            ListNode result = null;

            while (before.Count > 0)
            {
                var value = before.Dequeue();

                if (result == null)
                {
                    result = value;
                    resultHead = result;
                }
                else
                {
                    result.next = value;
                    result = result.next;
                }
            }

            while (after.Count > 0)
            {
                var value = after.Dequeue();

                if (result == null)
                {
                    result = value;
                    resultHead = result;
                }
                else
                {
                    result.next = value;
                    result = result.next;
                }
            }

            result.next = null;

            return resultHead;
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
        /// 91. Decode Ways
        /// </summary>
        public static int NumDecodings(string s)
        {
            if (string.IsNullOrEmpty(s) || s[0] == '0')
            {
                return 0;
            }

            int n = s.Length;
            int[] dp = new int[n + 1];
            dp[0] = 1;
            dp[1] = 1;

            for (int i = 2; i <= n; ++i)
            {
                int oneDigit = s[i - 1] - '0';
                int twoDigits = int.Parse(s.Substring(i - 2, 2));

                if (oneDigit != 0)
                {
                    dp[i] += dp[i - 1];
                }

                if (10 <= twoDigits && twoDigits <= 26)
                {
                    dp[i] += dp[i - 2];
                }
            }

            return dp[n];
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
