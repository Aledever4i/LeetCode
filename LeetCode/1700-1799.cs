﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class _1700_1799
    {
        /// <summary>
        /// 1700. Number of Students Unable to Eat Lunch
        /// </summary>
        public static int CountStudents(int[] students, int[] sandwiches)
        {
            var zeroStudentCount = students.Where(n => n == 0).Count();
            var oneStudentCount = students.Length - zeroStudentCount;

            foreach (var sandwich in sandwiches)
            {
                if (sandwich == 0 && zeroStudentCount == 0)
                {
                    return oneStudentCount;
                }

                if (sandwich == 1 && oneStudentCount == 0)
                {
                    return zeroStudentCount;
                }

                if (sandwich == 0)
                {
                    zeroStudentCount--;
                }
                else
                {
                    oneStudentCount--;
                }
            }

            return 0;
        }

        /// <summary>
        /// 1701. Average Waiting Time
        /// </summary>
        public static double AverageWaitingTime(int[][] customers)
        {
            double result = 0;
            int currentTime = 0;

            foreach (var customer in customers)
            {
                var arrivalTime = customer[0];
                var cookingTime = customer[1];

                if (currentTime <= arrivalTime)
                {
                    currentTime = arrivalTime + cookingTime;
                    result += cookingTime;
                }
                else
                {
                    currentTime += cookingTime;
                    result += currentTime - arrivalTime;
                }
            }

            return result / customers.Length;
        }

        /// <summary>
        /// 1704. Determine if String Halves Are Alike
        /// </summary>
        public static bool HalvesAreAlike(string s)
        {
            var result = 0;

            bool isVowel(char c)
            {
                return (new char[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' }).Contains(c); 
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (isVowel(s[i]))
                {

                    if (i < s.Length / 2)
                    {
                        result++;
                    }
                    else
                    {
                        result--;
                    }
                }
            }

            return result == 0;
        }

        /// <summary>
        /// 1717. Maximum Score From Removing Substrings
        /// </summary>
        public static int MaximumGain(string s, int x, int y)
        {
            if (x < y)
            {
                (y, x) = (x, y);
                s = new string(s.Reverse().ToArray());
            }

            int aCount = 0, bCount = 0, totalPoints = 0;
            for (int i = 0; i < s.Length; ++i)
            {
                char currentChar = s[i];

                if (currentChar == 'a')
                {
                    ++aCount;
                }
                else if (currentChar == 'b')
                {
                    if (aCount > 0)
                    {
                        --aCount;
                        totalPoints += x;
                    }
                    else
                    {
                        ++bCount;
                    }
                }
                else
                {
                    totalPoints += Math.Min(bCount, aCount) * y;
                    aCount = bCount = 0;
                }
            }
            totalPoints += Math.Min(bCount, aCount) * y;
            return totalPoints;
        }

        /// <summary>
        /// 1721. Swapping Nodes in a Linked List. Tags: Linked List, Two Pointers
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static ListNode SwapNodes(ListNode head, int k)
        {
            var list = new List<ListNode>();
            list.Add(head);

            ListNode endElement = head.next;

            while (endElement != null) {
                list.Add(endElement);

                endElement = endElement.next;
            }

            var endIndex = list.Count - k;

            var firstItem = list[k - 1];
            var endItem = list[endIndex];

            var temp = firstItem.val;
            firstItem.val = endItem.val;
            endItem.val = temp;

            return head;
        }

        /// <summary>
        /// 1732. Find the Highest Altitude. Tags: Array, Prefix Sum
        /// </summary>
        public static int LargestAltitude(int[] gain)
        {
            var maxAltitude = 0;
            var currentAltitude = 0;

            foreach (var step in gain)
            {
                currentAltitude += step;

                maxAltitude = Math.Max(maxAltitude, currentAltitude);
            }

            return maxAltitude;
        }

        /// <summary>
        /// 1743. Restore the Array From Adjacent Pairs
        /// </summary>
        public static int[] RestoreArray(int[][] adjacentPairs)
        {
            var n = adjacentPairs.Length;
            var dict = new Dictionary<int, List<int>>();

            foreach (var pair in adjacentPairs)
            {
                if (!dict.TryAdd(pair[0], new List<int>() { pair[1] }))
                {
                    dict[pair[0]].Add(pair[1]);
                }

                if (!dict.TryAdd(pair[1], new List<int>() { pair[0] }))
                {
                    dict[pair[1]].Add(pair[0]);
                }
            }

            int root = 0;
            foreach (var pair in dict)
            {
                if (pair.Value.Count == 1)
                {
                    root = pair.Key;
                    break;
                }
            }

            int curr = root;
            var result = new List<int>() { root };
            int prev = int.MinValue;

            while (result.Count < dict.Count)
            {
                foreach (var neigbor in dict[curr])
                {
                    if (neigbor != prev)
                    {
                        result.Add(neigbor);
                        prev = curr;
                        curr = neigbor;
                        break;
                    }
                }
            }

            return result.ToArray();
        }

        /// <summary>
        /// 1750. Minimum Length of String After Deleting Similar Ends
        /// </summary>
        public static int MinimumLength(string s)
        {
            if (s.Length == 1)
            {
                return 1;
            }

            int start = 0, end = s.Length - 1;
            while (true && start != end)
            {
                var startChar = s[start];

                if (startChar == s[end])
                {
                    while (end >= start && startChar == s[end])
                    {
                        end--;
                    }

                    while (start <= end && startChar == s[start])
                    {
                        start++;
                    }

                    if (start > end)
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            return (start == end) ? 1 : (end > start) ? end - start + 1 : 0;
        }

        /// <summary>
        /// 1751. Maximum Number of Events That Can Be Attended II
        /// </summary>
        public static int MaxValue(int[][] events, int k)
        {
            System.Array.Sort(events, (a, b) => a[0] - b[0]);
            var dp = new int[k + 1][];
            for (int i = 0; i < k + 1; i++)
            {
                dp[i] = new int[events.Length];
                System.Array.Fill(dp[i], -1);
            }
            return dfs(0, k);

            int dfs(int currentIndex, int count)
            {
                if (currentIndex == events.Length || count == 0)
                {
                    return 0;
                }

                if (dp[count][currentIndex] != -1)
                {
                    return dp[count][currentIndex];
                }

                var nextIndex = bisectRight(events, events[currentIndex][1]);
                dp[count][currentIndex] = Math.Max(events[currentIndex][2] + dfs(nextIndex, count - 1), dfs(currentIndex + 1, count));

                return dp[count][currentIndex];

            }

            int bisectRight(int[][] events, int target)
            {
                int left = 0, right = events.Length;
                while (left < right)
                {
                    int mid = (left + right) / 2;
                    if (events[mid][0] <= target)
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
        }

        /// <summary>
        /// 1752. Check if Array Is Sorted and Rotated
        /// </summary>
        public static bool Check(int[] nums)
        {
            var isSecond = false;
            var prev = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                var next = nums[i];

                if (prev <= next)
                {
                    prev = next;
                }
                else if (!isSecond)
                {
                    prev = next;
                    isSecond = true;
                }
                else
                {
                    return false;
                }
            }

            if (nums[nums.Length - 1] > nums[0] && isSecond)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 1759. Count Number of Homogenous Substrings
        /// </summary>
        public static int CountHomogenous(string s)
        {
            var mod = 1000000007;
            var currentCharLength = 1;
            var currentChar = s[0];
            var n = s.Length;
            var dict = new Dictionary<int, int>();
            double result = 0;

            for (int i = 1; i < n; i++)
            {
                var temp = s[i];

                if (temp == currentChar)
                {
                    currentCharLength++;
                }
                else
                {
                    if (!dict.TryAdd(currentCharLength, 1))
                    {
                        dict[currentCharLength]++;
                    }

                    currentChar = temp;
                    currentCharLength = 1;
                }
            }

            if (!dict.TryAdd(currentCharLength, 1))
            {
                dict[currentCharLength]++;
            }

            foreach (int k in dict.Keys)
            {
                double temp = ((double)k * ((double)k + 1) / 2.0);
                temp %= mod;
                temp *= dict[k] % mod;

                result += (int)temp;
                result %= mod;
            }

            return (int)result;
        }

        /// <summary>
        /// 1768. Merge Strings Alternately
        /// </summary>
        public static string MergeAlternately(string word1, string word2)
        {
            var n1 = word1.Length;
            var n2 = word2.Length;
            int i = 0;
            var result = new StringBuilder();
            while (i < n1 && i < n2)
            {
                result.Append(word1[i]);
                result.Append(word2[i]);
                i++;
            }

            while (i < n1)
            {
                result.Append(word1[i]);
                i++;
            }

            while (i < n2)
            {
                result.Append(word2[i]);
                i++;
            }

            return result.ToString();
        }

        /// <summary>
        /// 1769. Minimum Number of Operations to Move All Balls to Each Box
        /// </summary>
        public static int[] MinOperations(string boxes)
        {
            int n = boxes.Length;
            int[] answer = new int[n];

            int ballsToLeft = 0, movesToLeft = 0;
            int ballsToRight = 0, movesToRight = 0;

            for (int i = 0; i < n; i++)
            {
                answer[i] += movesToLeft;
                ballsToLeft += boxes[i] == '1' ? 1 : 0;
                movesToLeft += ballsToLeft;

                int j = n - 1 - i;
                answer[j] += movesToRight;
                ballsToRight += boxes[j] == '1' ? 1 : 0;
                movesToRight += ballsToRight;
            }

            return answer;
        }

        /// <summary>
        /// 1790. Check if One String Swap Can Make Strings Equal
        /// </summary>
        public static bool AreAlmostEqual(string s1, string s2)
        {
            var diff = new List<int>();
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[i]) diff.Add(i);

                if (diff.Count == 3)
                {
                    return false;
                }
            }

            if (diff.Count == 0)
            {
                return true;
            }

            if (diff.Count == 2)
            {
                var e1 = diff[0];
                var e2 = diff[1];

                if (s1[e1] == s2[e2] && s1[e2] == s2[e1])
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 1793. Maximum Score of a Good Subarray
        /// </summary>
        public static int MaximumScore(int[] nums, int k)
        {
            //var n = nums.Length;

            //var dpForward = new int[n];
            //var dpBack = new int[k + 1];

            //dpBack[k] = nums[k];
            //dpForward[k] = nums[k];

            //if (k >= 1)
            //{
            //    for (int i = k - 1; i >= 0; i--)
            //    {
            //        dpBack[i] = Math.Min(dpBack[i + 1], nums[i]);
            //    }
            //}

            //for (int i = k + 1; i < n; i++)
            //{
            //    dpForward[i] = Math.Min(dpForward[i - 1], nums[i]);
            //}

            //var rightMax = 0;
            //var rightIndex = k;

            //for (int i = k; i < n; i++)
            //{
            //    var temp = (i - k + 1) * dpForward[i];
            //    if (temp >= rightMax)
            //    {
            //        rightMax = temp;
            //        rightIndex = i;
            //    }
            //}

            //var rValue = dpForward[rightIndex];
            //var result = 0;
            //for (int i = k; i >= 0; i--)
            //{
            //    result = Math.Max(result, Math.Min(dpBack[i], rValue) * (rightIndex - i + 1));
            //}

            //return result;

            int n = nums.Length;
            int left = k;
            int right = k;
            int ans = nums[k];
            int currMin = nums[k];

            while (left > 0 || right < n - 1)
            {
                if ((left > 0 ? nums[left - 1] : 0) < (right < n - 1 ? nums[right + 1] : 0))
                {
                    right++;
                    currMin = Math.Min(currMin, nums[right]);
                }
                else
                {
                    left--;
                    currMin = Math.Min(currMin, nums[left]);
                }

                ans = Math.Max(ans, currMin * (right - left + 1));
            }

            return ans;
        }

        /// <summary>
        /// 1799. Maximize Score After N Operations. Tags: Array, Math, Dynamic Programming, Backtracking, Bit Manipulation, Number Theory, Bitmask
        /// </summary>
        /// <param name="nums"></param>
        /// TODO: Изучить тему с рекурсией и битовыми масками
        public static int MaxScore(int[] nums)
        {
            Dictionary<string, int> dp = new Dictionary<string, int>();
            Dictionary<string, int> cache = new Dictionary<string, int>();
            return Util(nums, new bool[nums.Length], nums.Length / 2);

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

            int Util(int[] arr, bool[] taken, int operations)

            {

                if (operations == 0)

                {

                    return 0;

                }

                string key = string.Join(",", taken.Select(b => b ? "1" : "0")) + "|" + operations;

                if (dp.ContainsKey(key))

                {

                    return dp[key];

                }

                int max = int.MinValue;

                for (int i = 0; i < arr.Length; i++)

                {

                    for (int j = i + 1; j < arr.Length; j++)

                    {

                        if (!taken[i] && !taken[j])

                        {

                            taken[i] = taken[j] = true;



                            var gcdKey = $"{arr[i]}|{arr[j]}";

                            if (!cache.TryGetValue(gcdKey, out int gcdValue))

                            {

                                gcdValue = GCD(arr[i], arr[j]);

                                cache.Add(gcdKey, gcdValue);

                            }



                            int val = (operations * gcdValue) + Util(arr, taken, operations - 1);

                            max = Math.Max(max, val);

                            taken[i] = taken[j] = false;

                        }

                    }

                }

                dp[key] = max;

                return max;

            }

        }
    }
}