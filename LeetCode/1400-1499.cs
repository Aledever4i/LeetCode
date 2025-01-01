using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LeetCode
{
    public static class _1400_1499
    {
        /// <summary>
        /// 1420. Build Array Where You Can Find The Maximum Exactly K Comparisons
        /// </summary>
        public static int NumOfArrays(int n, int m, int k)
        {
            int MOD = (int)1e9 + 7;

            var memo = new int[n][][]; // new int[n][m + 1][k + 1];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= m; j++)
                {
                    System.Array.Fill(memo[i][j], -1);
                }
            }

            return dp(0, 0, k);

            int dp(int i, int maxSoFar, int remain)
            {
                if (i == n)
                {
                    if (remain == 0)
                    {
                        return 1;
                    }

                    return 0;
                }

                if (remain < 0)
                {
                    return 0;
                }

                if (memo[i][maxSoFar][remain] != -1)
                {
                    return memo[i][maxSoFar][remain];
                }

                int ans = 0;
                for (int num = 1; num <= maxSoFar; num++)
                {
                    ans = (ans + dp(i + 1, maxSoFar, remain)) % MOD;
                }

                for (int num = maxSoFar + 1; num <= m; num++)
                {
                    ans = (ans + dp(i + 1, num, remain - 1)) % MOD;
                }

                memo[i][maxSoFar][remain] = ans;
                return ans;
            }
        }

        /// <summary>
        /// 1422. Maximum Score After Splitting a String
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int MaxScore(string s)
        {
            var ones = s.Where(c => c == '1').Count();
            var zeros = 0;
            var result = 0;
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s[i] == '0')
                {
                    zeros++;
                }
                else
                {
                    ones--;
                }

                result = Math.Max(result, zeros + ones);
            }

            return result;
        }

        /// <summary>
        /// 1425. Constrained Subsequence Sum
        /// </summary>
        public static int ConstrainedSubsetSum(int[] nums, int k)
        {
            var queue = new ArrayList();
            var dp = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                if (queue.Count > 0 && i - (int)queue[0] > k)
                {
                    queue.RemoveAt(0);
                }

                dp[i] = (queue.Count > 0 ? dp[(int)queue[0]] : 0) + nums[i];

                while (queue.Count > 0 && dp[(int)queue[queue.Count - 1]] < dp[i])
                {
                    queue.RemoveAt(queue.Count - 1);
                }

                if (dp[i] > 0)
                {
                    queue.Add(i);
                }
            }

            int ans = int.MinValue;
            foreach (int num in dp)
            {
                ans = Math.Max(ans, num);
            }

            return ans;
        }

        /// <summary>
        /// 1441. Build an Array With Stack Operations
        /// </summary>
        public static IList<string> BuildArray(int[] target, int n)
        {
            var result = new List<string>();
            int currentNumber = 1;

            foreach (var item in target)
            {
                while (currentNumber < item)
                {
                    result.Add("Push");
                    result.Add("Pop");
                    currentNumber++;
                }

                result.Add("Push");
                currentNumber++;
            }

            return result;
        }

        /// <summary>
        /// 1455. Check If a Word Occurs As a Prefix of Any Word in a Sentence
        /// </summary>
        public static int IsPrefixOfWord(string sentence, string searchWord)
        {
            var x = sentence.Split(" ").Select((w, index) => new { index, searchResult = $" {w}".IndexOf($" {searchWord}") }).Where(g => g.searchResult != -1);

            return x.Any() ? x.Select(v => v.index).Min() + 1 : -1;
        }

        /// <summary>
        /// 1456. Maximum Number of Vowels in a Substring of Given Length
        /// </summary>
        public static int MaxVowels(string s, int k)
        {
            var chars = s.ToCharArray();
            var n = chars.Length;

            var values = new int[n];
            System.Array.Fill(values, -1);

            int currentWindowValue = 0;
            var result = 0;

            for (int i = 0; i < k; i++)
            {
                currentWindowValue += (new char[] { 'a', 'e', 'i', 'o', 'u' }).Contains(chars[i]) ? 1 : 0;
            }
            result = currentWindowValue;

            for (int i = k; i < n; i++)
            {
                currentWindowValue += (new char[] { 'a', 'e', 'i', 'o', 'u'}).Contains(chars[i]) ? 1 : 0;
                currentWindowValue -= (new char[] { 'a', 'e', 'i', 'o', 'u' }).Contains(chars[i - k]) ? 1 : 0;

                result = Math.Max(result, currentWindowValue);
            }

            return result;
        }

        /// <summary>
        /// 1463. Cherry Pickup II
        /// </summary>
        public static int CherryPickup(int[][] grid)
        {
            var moves = new (int, int)[3] { (1, -1), (1, 0), (1, 1) };
            return 0;
        }

        /// <summary>
        /// 1480. Running Sum of 1d Array. Tags: Array, Sliding Window
        /// </summary>
        public static int[] RunningSum(int[] nums)
        {
            var result = new int[nums.Length];
            var windowValue = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                windowValue += nums[i];
                result[i] = windowValue;
            }

            return result;
        }

        /// <summary>
        /// 1481. Least Number of Unique Integers after K Removals
        /// </summary>
        public static int FindLeastNumOfUniqueInts(int[] arr, int k)
        {
            var result = 0;
            var newArray = arr.GroupBy(x => x).Select(x => new { Key = x, Count = x.Count() }).OrderBy(x => x.Count);

            foreach (var item in newArray)
            {
                if (item.Count > k)
                {
                    k -= item.Count;
                    result++;
                }
                else if (k > 0)
                {
                    k -= item.Count;
                }
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
        /// 1493. Longest Subarray of 1's After Deleting One Element
        /// </summary>
        public static int LongestSubarray(int[] nums)
        {
            int currentNumber = nums[0];
            int current = 0;
            int left = 0;
            int n = nums.Length;
            int result = 0;
            int indexPass = 0;

            bool isFirstPassed = false;
            bool hasOtherNumber = false;

            while (left < n)
            {
                if (currentNumber == 0)
                {
                    left++;
                    current = 0;

                    if (left == n)
                    {
                        break;
                    }

                    currentNumber = nums[left];
                    if (currentNumber != 0)
                    {
                        hasOtherNumber = true;
                    }
                }
                else if (currentNumber == nums[left])
                {
                    current++;
                    result = Math.Max(result, current);
                    left++;
                }
                else
                {
                    hasOtherNumber = true;

                    if (!isFirstPassed)
                    {
                        isFirstPassed = true;
                        indexPass = left;
                        left++;
                    }
                    else
                    {
                        result = Math.Max(result, current);

                        if (indexPass + 1 == left)
                        {
                            left = indexPass;
                        }
                        else
                        {
                            left = indexPass + 1;
                        }

                        currentNumber = nums[left];
                        current = 0;
                        isFirstPassed = false;
                    }
                }

            }

            if (!hasOtherNumber)
            {
                return (result - 1 <= 0) ? 0 : result - 1;
            }

            return result;
        }

        /// <summary>
        /// 1494. Parallel Courses II
        /// доделать
        /// </summary>
        public static int MinNumberOfSemesters(int n, int[][] relations, int k)
        {
            var waiting = new Dictionary<int, List<int>>();

            var priorityLen = new Dictionary<int, int>();
            var priorityCost = new Dictionary<int, int>();

            var visited = new HashSet<int>();
            

            for (int i = 1; i <= n; i++)
            {
                waiting[i] = new List<int>();
            }

            foreach (var relation in relations)
            {
                var prev = relation[0];
                var next = relation[1];

                waiting[next].Add(prev);
                
                calculatePriorityLen(prev);
                calculatePriorityCost(prev);
            }

            for (int i = 1; i <= n; i++)
            {
                if (!priorityLen.ContainsKey(i))
                {
                    priorityLen.Add(i, 0);
                }

                if (!priorityCost.ContainsKey(i))
                {
                    priorityCost.Add(i, 0);
                }
            }

            var result = 0;

            while (visited.Count < n)
            {
                result++;

                var nonVisitedCourses =
                    waiting
                        .Where(w => !visited.Contains(w.Key))
                        .Where(w => !w.Value.Except(visited.ToArray()).Any());

                var prioritized =
                    from non in nonVisitedCourses
                    orderby priorityLen[non.Key] descending
                    select new
                    {
                        Value = non.Key,
                        Rank = (
                            from o in nonVisitedCourses
                            where priorityLen[o.Key] > priorityLen[non.Key]
                            select o
                        ).Count() + 1
                    };


                var withMaxLen =
                    prioritized
                    .Where(p => p.Rank <= k)
                    .OrderByDescending(v => priorityCost[v.Value])
                    .Take(k)
                    .Select(v => v.Value);

                foreach (var visit in withMaxLen)
                {
                    visited.Add(visit);
                }
            }

            int calculatePriorityLen(int course)
            {
                if (priorityLen.ContainsKey(course))
                {
                    return priorityLen[course];
                }

                var maxLen = 0;
                foreach (var relation in relations.Where(r => r[0] == course).Select(r => r[1]))
                {
                    maxLen = Math.Max(maxLen, calculatePriorityLen(relation) + 1);
                }

                priorityLen.Add(course, maxLen);

                return priorityLen[course];
            }

            int calculatePriorityCost(int course)
            {
                if (priorityCost.ContainsKey(course))
                {
                    return priorityCost[course];
                }

                var maxLen = 1;
                foreach (var relation in relations.Where(r => r[0] == course).Select(r => r[1]))
                {
                    maxLen += calculatePriorityLen(relation);
                }

                priorityCost.Add(course, maxLen);

                return priorityCost[course];
            }

            return result;
        }

        /// <summary>
        /// 1497. Check If Array Pairs Are Divisible by k
        /// </summary>
        public static bool CanArrange(int[] arr, int k)
        {
            var extended = arr.Select(x => ((x % k) + k) % k).GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

            if (extended.TryGetValue(0, out var count) && count % 2 != 0)
            {
                return false;
            }

            foreach (var key in extended.Keys.Where(x => x > 0))
            {
                var isExists1 = extended.TryGetValue(key, out var count1);
                var isExists2 = extended.TryGetValue(k - key, out var count2);

                if (key == k - key && count1 % 2 == 1)
                {
                    return false;
                }
                else if (isExists1 && isExists2 && count1 != count2)
                {
                    return false;
                }
                else if (isExists1 && !isExists2)
                {
                    return false;
                }
                else if (!isExists1 && isExists2)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
