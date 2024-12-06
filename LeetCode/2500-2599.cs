using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LeetCode
{
    public static class _2500_2599
    {
        public class MaxScoreElement
        {
            public MaxScoreElement(int score, int factor)
            {
                this.score = score;
                this.factor = factor;
            }

            public int score;

            public int factor;
        }

        /// <summary>
        /// 2516. Take K of Each Character From Left and Right
        /// </summary>
        public static int TakeCharacters(string s, int k)
        {
            int[] count = new int[3];
            int n = s.Length;
            var a = s.ToArray();

            // Count total occurrences
            foreach (var c in s)
            {
                count[c - 'a']++;
            }

            if (count.Any(i => i < k))
            {
                return -1;
            }

            int[] window = new int[3];
            int left = 0, maxWindow = 0;

            for (int right = 0; right < n; right++)
            {
                window[a[right] - 'a']++;
                while (
                    left <= right &&
                    (count[0] - window[0] < k ||
                        count[1] - window[1] < k ||
                        count[2] - window[2] < k)
                )
                {
                    window[a[left] - 'a']--;
                    left++;
                }

                maxWindow = Math.Max(maxWindow, right - left + 1);
            }

            return n - maxWindow;
        }

        /// <summary>
        /// 2540. Minimum Common Value
        /// </summary>
        public static int GetCommon(int[] nums1, int[] nums2)
        {
            var common1 = common(nums1, nums2);

            return common1.Any() ? common1.Min() : -1;

            IEnumerable<int> common(int[] nums3, int[] nums4)
            {
                var set = new HashSet<int>(nums3);

                foreach (var n in nums4)
                {
                    if (set.Remove(n))
                    {
                        yield return n;
                    }
                }

            }
        }

        /// <summary>
        /// 2542. Maximum Subsequence Score. Tags: Array, Greedy, Sorting, Heap(Priority Queue)
        /// </summary>
        public static long MaxScore(int[] nums1, int[] nums2, int k)
        {
            int n = nums1.Length;
            MaxScoreElement[] nums = new MaxScoreElement[n];

            for (int i = 0; i < n; i++)
            {
                nums[i] = new MaxScoreElement(nums1[i], nums2[i]);
            }

            System.Array.Sort(nums, (a, b) => {
                return b.factor - a.factor;
            });

            PriorityQueue<int, int> queue = new();
            long res = 0, sum = 0;

            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(nums[i].score, nums[i].score);
                sum += nums[i].score;

                if (queue.Count > k) sum -= queue.Dequeue();
                if (queue.Count == k) res = Math.Max(res, sum * nums[i].factor);
            }

            return res;
        }

        /// <summary>
        /// 2551. Put Marbles in Bags
        /// </summary>
        public static long PutMarbles(int[] weights, int k)
        {
            var n = weights.Length;
            if (k >= n)
            {
                return 0;
            }

            var pair = new long[n - 1];
            for (int i = 0; i < n - 1; i++)
            {
                pair[i] = weights[i] + weights[i + 1];
            }

            return pair.OrderByDescending(v => v).Take(k - 1).Sum() - pair.OrderBy(v => v).Take(k - 1).Sum();
        }

        /// <summary>
        /// 2554. Maximum Number of Integers to Choose From a Range I
        /// </summary>
        public static int MaxCount(int[] banned, int n, int maxSum)
        {
            var elements = Enumerable.Range(1, n);

            var filtered = elements.Except(banned).OrderBy(e => e).ToArray();

            var result = 0;

            for (int i = 0; i < filtered.Length; i++)
            {
                result += filtered[i];

                if (result > maxSum)
                {
                    return i;
                }
            }

            return filtered.Length;
        }

        /// <summary>
        /// 2563. Count the Number of Fair Pairs
        /// </summary>
        public static long CountFairPairs1(int[] nums, int lower, int upper)
        {
            long result = 0;

            Array.Sort(nums);
            var startIndex = 0;

            var endIndex = nums.Length - 1;
            var endValue = nums[endIndex];
            var returnCount = 0;

            while (startIndex < endIndex)
            {
                var startValue = nums[startIndex];

                while (startValue + endValue > upper && endIndex > 0)
                {
                    endIndex--;
                    endValue = nums[endIndex];
                }

                while (startValue + endValue >= lower && startIndex < endIndex && endIndex > 0)
                {
                    endIndex--;
                    returnCount++;
                    endValue = nums[endIndex];
                    result += 1;
                }

                endIndex += returnCount;
                endValue = nums[endIndex];
                returnCount = 0;
                startIndex++;
            }

            return result;
        }

        /// <summary>
        /// 2563. Count the Number of Fair Pairs
        /// </summary>
        public static long CountFairPairs2(int[] nums, int lower, int upper)
        {
            Array.Sort(nums);
            return Bound(nums, upper + 1) - Bound(nums, lower);

            long Bound(int[] nums, int value)
            {
                int left = 0, right = nums.Length - 1;
                long result = 0;
                while (left < right)
                {
                    int sum = nums[left] + nums[right];
                    if (sum < value)
                    {
                        result += (right - left);
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// 2577. Minimum Time to Visit a Cell In a Grid
        /// </summary>
        public static int MinimumTime(int[][] grid)
        {
            if (grid[0][1] > 1 && grid[1][0] > 1)
            {
                return -1;
            }

            int n = grid.Length;
            int m = grid[0].Length;

            bool[][] visited = new bool[n][];
            for (int i = 0; i < n; i++)
            {
                visited[i] = new bool[m];
            }

            var priority = new PriorityQueue<(int, int, int), int>();
            priority.Enqueue((0, 0, 0), int.MaxValue);

            while (priority.Count > 0)
            {
                var point = priority.Dequeue();

                if (point.Item1 == n - 1 && point.Item2 == m - 1)
                {
                    return point.Item3;
                }

                if (visited[point.Item1][point.Item2])
                {
                    continue;
                }
                visited[point.Item1][point.Item2] = true;

                if (IsValid(point.Item1 + 1, point.Item2, visited))
                {
                    var g = grid[point.Item1 + 1][point.Item2];
                    int waitTime = ((g - point.Item3) % 2 == 0) ? 1 : 0;
                    int nextTime = Math.Max(g + waitTime, point.Item3 + 1);
                    priority.Enqueue((point.Item1 + 1, point.Item2, nextTime), nextTime);
                }

                if (IsValid(point.Item1, point.Item2 + 1, visited))
                {
                    var g = grid[point.Item1][point.Item2 + 1];
                    int waitTime = ((g - point.Item3) % 2 == 0) ? 1 : 0;
                    int nextTime = Math.Max(g + waitTime, point.Item3 + 1);
                    priority.Enqueue((point.Item1, point.Item2 + 1, nextTime), nextTime);
                }

                if (IsValid(point.Item1, point.Item2 - 1, visited))
                {
                    var g = grid[point.Item1][point.Item2 - 1];
                    int waitTime = ((g - point.Item3) % 2 == 0) ? 1 : 0;
                    int nextTime = Math.Max(g + waitTime, point.Item3 + 1);
                    priority.Enqueue((point.Item1, point.Item2 - 1, nextTime), nextTime);
                }

                if (IsValid(point.Item1 - 1, point.Item2, visited))
                {
                    var g = grid[point.Item1 - 1][point.Item2];
                    int waitTime = ((g - point.Item3) % 2 == 0) ? 1 : 0;
                    int nextTime = Math.Max(g + waitTime, point.Item3 + 1);
                    priority.Enqueue((point.Item1 - 1, point.Item2, nextTime), nextTime);
                }
            }

            return -1;

            bool IsValid(int x, int y, bool[][] visited)
            {
                return (x < grid.Length && x >= 0 && y < grid[0].Length && y >= 0 && !visited[x][y]);
            }
        }

        /// <summary>
        /// 2582. Pass the Pillow
        /// </summary>
        public static int PassThePillow(int n, int time)
        {
            var position = time % ((n - 1) * 2);

            if (position < n - 1)
            {
                return position + 1;
            }

            return n - (position - n);
        }
    }
}
