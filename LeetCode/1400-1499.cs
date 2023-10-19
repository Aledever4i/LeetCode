using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
