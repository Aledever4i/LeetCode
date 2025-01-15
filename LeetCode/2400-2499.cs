using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LeetCode
{
    public static class _2400_2499
    {
        /// <summary>
        /// 2402. Meeting Rooms III
        /// </summary>
        public static int MostBooked(int n, int[][] meetings)
        {
            var roomUsed = new int[n];
            var timer = 0;
            var meetingQueue = new PriorityQueue<int, int>();
            var room = new PriorityQueue<int, int>();
            var unused = new PriorityQueue<int, int>();

            for (int i = 0; i < n; i++)
            {
                unused.Enqueue(i, i);
            }

            foreach (var meeting in meetings)
            {
                meetingQueue.Enqueue(meeting[1] - meeting[0], meeting[0]);
            }

            while (meetingQueue.Count > 0)
            {
                while (
                    (
                        (unused.Count > 0)
                        || (room.TryPeek(out int element, out int priority) && priority <= timer)
                    )
                    && meetingQueue.TryPeek(out int q, out int mP)
                    && mP <= timer
                )
                {
                    while (room.TryPeek(out int element1, out int priority1) && priority1 <= timer)
                    {
                        room.Dequeue();
                        unused.Enqueue(element1, element1);
                    }
                
                    var currentMeeting = meetingQueue.Dequeue();
                    var roomNumber = unused.Dequeue();
                    roomUsed[roomNumber]++;
                    room.Enqueue(roomNumber, q + timer);
                }

                timer++;
            }

            return roomUsed.Select((x, index) => new { Number = x, Index = index }).MaxBy(x => x.Number).Index;
        }

        /// <summary>
        /// 2418. Sort the People
        /// </summary>
        public static string[] SortPeople(string[] names, int[] heights)
        {
            return
                names
                    .Select((n, index) => new { N = n, I = index })
                    .Join(heights.Select((n, index) => new { N = n, I = index }), name => name.I, height => height.I, (name, height) => new { Name = name, Height = height })
                    .OrderByDescending(v => v.Height.N)
                    .Select(v => v.Name.N)
                    .ToArray();
        }

        /// <summary>
        /// 2429. Minimize XOR
        /// </summary>
        public static int MinimizeXor(int num1, int num2)
        {
            int result = 0;
            int targetSetBitsCount = BitOperations.PopCount((uint)num2);
            int setBitsCount = 0;
            int currentBit = 31;

            while (setBitsCount < targetSetBitsCount)
            {
                if (isSet(num1, currentBit) || (targetSetBitsCount - setBitsCount > currentBit))
                {
                    result = setBit(result, currentBit);
                    setBitsCount++;
                }
                currentBit--;
            }

            return result;

            bool isSet(int x, int bit)
            {
                return (x & (1 << bit)) != 0;
            }

            int setBit(int x, int bit)
            {
                return x | (1 << bit);
            }
        }

        /// <summary>
        /// 2433. Find The Original Array of Prefix Xor
        /// </summary>
        public static int[] FindArray(int[] pref)
        {
            var n = pref.Length;

            for (int i = n - 1; i > 0; i--)
            {
                pref[i] = pref[i] ^ pref[i - 1];
            }

            return pref;
        }

        /// <summary>
        /// 2444. Count Subarrays With Fixed Bounds
        /// </summary>
        public static long CountSubarrays(int[] nums, int minK, int maxK)
        {
            long result = 0;

            return result;
        }

        /// <summary>
        /// 2448. Minimum Cost to Make Array Equal. Tags: Array, Binary Search, Greedy, Sorting, Prefix Sum
        /// </summary>
        public static long MinCost(int[] nums, int[] cost)
        {
            long getCost(int[] nums, int[] cost, int b) {
                long result = 0;
                for (int i = 0; i < nums.Length; ++i)
                {
                    result += 1L * Math.Abs(nums[i] - b) * cost[i];
                }    
                return result;
            }

            long answer = getCost(nums, cost, nums[0]);
            int left = nums.Min();
            int right = nums.Max();

            while (left < right)
            {
                int mid = (left + right) / 2;

                long cost1 = getCost(nums, cost, mid);
                long cost2 = getCost(nums, cost, mid + 1);

                answer = Math.Min(cost1, cost2);

                if (cost1 > cost2)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return answer;

            //var dict = new Dictionary<(int, int), ulong>();
            //var uniqueValues = nums.Distinct();
            //ulong minCost = ulong.MaxValue;
            //ulong currentSum = 0;

            //for (int i = 0; i < nums.Length; i++)
            //{
            //    dict.Add((nums[i], i), Convert.ToUInt64(cost[i]));
            //}

            //var array = dict.OrderByDescending(value => value.Value).ToArray();

            //foreach (var value in uniqueValues.OrderByDescending(value => value))
            //{
            //    foreach (var element in array)
            //    {
            //        currentSum += Convert.ToUInt64((Math.Abs(element.Key.Item1 - value))) * element.Value;

            //        if (currentSum >= minCost)
            //        {
            //            break;
            //        }
            //    }

            //    minCost = Math.Min(minCost, currentSum);
            //    currentSum = 0;
            //}

            //return Convert.ToInt64(minCost);

            //var dict = new (int, int)[nums.Length];
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    dict[i] = (nums[i], cost[i]);
            //}

            //var sortedArray = dict.OrderBy(x => x.Item1).ToArray();

            //long[] prefixCost = new long[nums.Length];
            //prefixCost[0] = sortedArray[0].Item2;

            //for (int i = 1; i < nums.Length; i++)
            //{
            //    prefixCost[i] = 1l * sortedArray[0].Item2 + prefixCost[i - 1];
            //}

            //long totalCost = 0;
            //for (int i = 1; i < nums.Length; i++)
            //{
            //    totalCost += 1l * sortedArray[i].Item2 * (sortedArray[i].Item1 - sortedArray[0].Item1);
            //}

            //long answer = totalCost;

            //for (int i = 1; i < nums.Length; i++)
            //{
            //    int gap = sortedArray[i].Item1 - sortedArray[i - 1].Item1;
            //    totalCost += 1l * prefixCost[i - 1] * gap;
            //    totalCost -= 1l * (prefixCost[nums.Length - 1] - prefixCost[i - 1]) * gap;
            //    answer = Math.Min(answer, totalCost);
            //}

            //return answer;
        }

        /// <summary>
        /// 2461. Maximum Sum of Distinct Subarrays With Length K
        /// </summary>
        public static long MaximumSubarraySum(int[] nums, int k)
        {
            var hashSet = new Dictionary<int, int>();
            long prefix = 0;
            long result = 0; 

            for (int i = 0; i < k; i++)
            {
                var v = nums[i];
                if (!hashSet.TryAdd(v, 1))
                {
                    hashSet[v] += 1;
                }
                prefix += v;
            }

            if (hashSet.Keys.Count == k)
            {
                result = prefix;
            }

            for (int i = k; i < nums.Length; i++)
            {
                var prev = nums[i - k];
                var current = nums[i];

                if (hashSet[prev] == 1)
                {
                    hashSet.Remove(prev);
                }
                else
                {
                    hashSet[prev] -= 1;
                }

                if (!hashSet.TryAdd(current, 1))
                {
                    hashSet[current] += 1;
                }

                prefix += current - prev;
                if (hashSet.Count == k)
                {
                    result = Math.Max(prefix, result);
                }
            }

            return result;
        }

        /// <summary>
        /// 2462. Total Cost to Hire K Workers
        /// </summary>
        public static long TotalCost(int[] costs, int k, int candidates)
        {
            var n = costs.Length;
            long result = 0;
            var used = new int[n];

            for (int i = 0; i < k; i++)
            {
                var minIndex = int.MaxValue;
                var minValue = int.MaxValue;

                int startCandidates = 0;
                int startIndex = 0;
                while (startCandidates < candidates)
                {
                    if (startIndex >= n)
                    {
                        startCandidates++;
                    }
                    else if (used[startIndex] == 0)
                    {
                        var value = costs[startIndex];

                        if (value < minValue || (value == minValue && startIndex < minIndex))
                        {
                            minValue = value;
                            minIndex = startIndex;
                        }

                        startCandidates++;
                    }

                    startIndex++;
                }

                int endCandidates = 0;
                int endIndex = n - 1;
                while (endCandidates < candidates)
                {
                    if (endIndex < 0)
                    {
                        endCandidates++;
                    }
                    else if (used[endIndex] == 0)
                    {
                        var value = costs[endIndex];

                        if (value < minValue || (value == minValue && endIndex < minIndex))
                        {
                            minValue = value;
                            minIndex = endIndex;
                        }

                        endCandidates++;
                    }

                    endIndex--;
                }

                result += minValue;
                used[minIndex] = 1;
            }

            return result;
        }

        /// <summary>
        /// 2466. Count Ways To Build Good Strings.
        /// Первый вариант оказался рабочим но медленным.
        /// Итоговое решение посмотрел, сделал несколько Excel, но так и не смог додуматься какая формула вшита. 
        /// То что я возвращаюсь на 1 элемент когда оказывается то количество шагов, которое требовалось искомо, это удивительно.
        /// </summary>
        public static int CountGoodStrings(int low, int high, int zero, int one)
        {
            int[] cache = new int[high + 1];
            cache[0] = 1;

            for (int i = 1; i <= high; i++)
            {
                if (i - zero >= 0)
                {
                    cache[i] += cache[i - zero];
                }

                if (i - one >= 0)
                {
                    cache[i] += cache[i - one];
                }

                cache[i] %= 1_000_000_007;
            }

            int result = 0;
            for (int i = low; i <= high; i++)
            {
                result = (result + cache[i]) % 1_000_000_007;
            }

            return result;
        }

        /// <summary>
        /// 2485. Find the Pivot Integer
        /// </summary>
        public static int PivotInteger(int n)
        {
            if (n == 1)
            {
                return 1;
            }

            var sum = new int[n + 1];
            var prefixSum = 0;
            for (int i = 1; i < n + 1; i++)
            {
                prefixSum += i;
                sum[i] = prefixSum;
            }

            var postfixSum = 0;
            for (int i = n; i > 0; i--)
            {
                postfixSum += i;
                if (postfixSum == sum[i])
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// 2486. Append Characters to String to Make Subsequence
        /// </summary>
        public static int AppendCharacters(string s, string t)
        {
            var sIndex = 0;
            var tIndex = 0;
            var isFound = false;

            for (; tIndex < t.Length && sIndex < s.Length; tIndex++)
            {
                var current = t[tIndex];
                for (; sIndex < s.Length; sIndex++)
                {
                    if (current == s[sIndex])
                    {
                        sIndex++;
                        isFound = true;
                        break;
                    }
                    else
                    {
                        isFound = false;
                    }
                }
            }

            return (t.Length == tIndex && isFound) ? 0 : t.Length - tIndex + (isFound ? 0 : 1);
        }

        /// <summary>
        /// 2490. Circular Sentence
        /// </summary>
        public static bool IsCircularSentence(string sentence)
        {
            if (sentence[0] != sentence[sentence.Length - 1])
            {
                return false;
            }

            var words = sentence.Split(' ');

            for (int i = 0; i < words.Length - 1; i++)
            {
                if (words.ElementAt(i)[words[i].Length - 1] != words.ElementAt(i + 1)[0])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 2491. Divide Players Into Teams of Equal Skill
        /// </summary>
        public static long DividePlayers(int[] skill)
        {
            var skillDictionary = skill.GroupBy(x => x).ToDictionary(x => (decimal)x.Key, x => x.Count());
            var maxPower = skillDictionary.Keys.Min() + skillDictionary.Keys.Max();
            decimal result = 0;

            foreach (var key in skillDictionary.Keys) {
                if (!skillDictionary.TryGetValue(maxPower - key, out int count) || skillDictionary[key] != count)
                {
                    return -1;
                }

                result += ((key / 2) * (maxPower - key) * count);
            }

            return (long)(result);
        }
    }
}
