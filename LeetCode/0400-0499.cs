using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class _0400_0499
    {
        /// <summary>
        /// 401. Binary Watch
        /// </summary>
        public static IList<string> ReadBinaryWatch(int turnedOn)
        {
            var result = new List<string>();
            for (var h = 0; h < 12; h++)
            {
                for (var m = 0; m < 60; m++)
                {
                    if (BitOperations.PopCount((uint)h) + BitOperations.PopCount((uint)m) == turnedOn)
                    {
                        result.Add($"{h}:{m:D2}");
                    }
                }
            }

            return result;
        }


        /// <summary>
        /// 435. Non-overlapping Intervals. TagsL Array, Dynamic Programming, Greedy, Sorting
        /// </summary>
        public static int EraseOverlapIntervals(int[][] intervals)
        {
            //var dp = new int[intervals.Length];
            var dp = new int[intervals.Length][];
            for (var i = 0; i < intervals.Length; i++)
            {
                var negative = new int[2] { -1, -1 };
                dp[i] = negative;
            }
            System.Array.Sort(intervals, (a, b) => a[0] - b[0]);

            var result = Math.Min(bfs(0, 1), bfs(0, 0));

            return result;

            int bfs(int currentIndex, int isPick)
            {
                if (currentIndex == intervals.Length)
                {
                    return 0;
                }

                if (dp[currentIndex][isPick] > -1)
                {
                    return dp[currentIndex][isPick];
                }

                var endValue = intervals[currentIndex][1];
                var nextIndex = findIndex(currentIndex, endValue);
                dp[currentIndex][1] = nextIndex - currentIndex - 1 + Math.Min(bfs(nextIndex, 0), bfs(nextIndex, 1));
                dp[currentIndex][0] = 1 + Math.Min(bfs(currentIndex + 1, 0), bfs(currentIndex + 1, 1));

                return dp[currentIndex][isPick];
            }

            int findIndex(int currentIndex, int value)
            {
                int left = currentIndex, right = intervals.Length;

                while (left < right)
                {
                    var mid = (left + right) / 2;
                    var midValue = intervals[mid];

                    if (value > midValue[0])
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
        /// 441. Arranging Coins
        /// </summary>
        public static int ArrangeCoins(int n)
        {
            var result = 0;
            var iter = 1;

            while (n > 0)
            {
                n -= iter;
                if (n >= 0)
                {
                    result++;
                    iter++;
                }
            }

            return result;
        }

        /// <summary>
        /// 445. Add Two Numbers II. Tags: Linked List, Math, Stack
        /// </summary>
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var firstValue = new List<int>();
            var secondValue = new List<int>();
            var resultList = new List<int>();

            while (l1 != null)
            {
                firstValue.Add(l1.val);
                l1 = l1.next;
            }
            while (l2 != null)
            {
                secondValue.Add(l2.val);
                l2 = l2.next;
            }

            var first = firstValue.Count;
            var second = secondValue.Count;
            var discharge = 0;

            for (int i = 1; i <= Math.Max(first, second); i++)
            {
                var value = 0;
                if (first - i >= 0)
                {
                    value = firstValue[first - i];
                }
                if (second - i >= 0)
                {
                    value += secondValue[second - i];
                }
                if (discharge == 1)
                {
                    value++;
                }

                discharge = value / 10;
                resultList.Add(value % 10);
            }

            if (discharge == 1)
            {
                resultList.Add(1);
            }

            ListNode head = new ListNode(resultList[resultList.Count - 1]);
            var result = head;
            for (int i = 2; i <= resultList.Count; i++)
            {
                head.next = new ListNode(resultList[resultList.Count - i]);
                head = head.next;
            }

            return result;
        }

        /// <summary>
        /// 448. Find All Numbers Disappeared in an Array. Tags: Array, Hash Table
        /// </summary>
        public static IList<int> FindDisappearedNumbers(int[] nums)
        {
            var n = nums.Length;
            var currentNumber = 1;
            var result = new List<int>();
            System.Array.Sort(nums);

            for (int i = 0; i < n; i++)
            {
                var temp = nums[i];
                if (currentNumber == temp)
                {
                    currentNumber++;
                    continue;
                }

                if (currentNumber < temp)
                {
                    result.Add(currentNumber);
                    currentNumber++;
                    i--;
                    continue;
                }

                if (currentNumber > temp)
                {
                    continue;
                }
            }

            if (currentNumber - 1 < n)
            {
                result.AddRange(Enumerable.Range(currentNumber, n - currentNumber + 1));
            }

            return result;
        }

        /// <summary>
        /// 455. Assign Cookies
        /// </summary>
        public static int FindContentChildren(int[] g, int[] s)
        {
            System.Array.Sort(s, (a, b) => b.CompareTo(a));
            System.Array.Sort(g, (a, b) => b.CompareTo(a));

            var result = 0;
            int indexG = 0;
            int indexS = 0;

            var nG = g.Length;
            var nS = s.Length;

            while (indexG < nG && indexS < nS)
            {
                var vG = g[indexG];
                var vS = s[indexS];

                if (vS >= vG)
                {
                    result++;
                    indexG++;
                    indexS++;
                }
                else
                {
                    indexG++;
                }
            }

            return result;
        }

        /// <summary>
        /// 456. 132 Pattern
        /// </summary>
        public static bool Find132pattern(int[] nums)
        {
            var n = nums.Length;
            if (n < 3)
            {
                return false;
            }
            var stack = new Stack<int>();
            int[] min = new int[n];
            min[0] = nums[0];
            for (int i = 1; i < n; i++)
            {
                min[i] = Math.Min(min[i - 1], nums[i]);
            }
            for (int j = n - 1; j >= 0; j--)
            {
                if (nums[j] > min[j])
                {
                    while (stack.Count > 0 && stack.Peek() <= min[j])
                    {
                        stack.Pop();

                    }
                    if (stack.Count > 0 && stack.Peek() < nums[j])
                    {
                        return true;
                    }

                    stack.Push(nums[j]);
                }
            }
            return false;
        }

        /// <summary>
        /// 458. Poor Pigs
        /// </summary>
        public static int PoorPigs(int buckets, int minutesToDie, int minutesToTest)
        {
            var time = minutesToTest / minutesToDie;
            var pigs = 0;

            while (Math.Pow(time + 1, pigs) < buckets)
            {
                pigs++;
            }

            return pigs;
        }

        /// <summary>
        /// 459. Repeated Substring Pattern
        /// </summary>
        public static bool RepeatedSubstringPattern(string s)
        {
            var result = false;
            var n = s.Length;

            check(s[0]);

            return result;

            void check(int index)
            {
                if (index > n / 2)
                {
                    return;
                }

                var current = s[0..index];

                for (int i = index; i < n; i += index)
                {
                    var indexEnd = i + index;

                    var cheched = s[i..indexEnd];
                }
            }
        }

        /// <summary>
        /// 463. Island Perimeter
        /// </summary>
        public static int IslandPerimeter(int[][] grid)
        {
            var n = grid.Length;
            var m = grid[0].Length;

            var visited = new int[n][];
            for (int i = 0; i < n; i++)
            {
                visited[i] = new int[m];
            }

            var isFound = false;
            var queue = new Queue<(int, int)>();

            for (int i = 0; i < n && !isFound; i++)
            {
                for (int y = 0; y < m && !isFound; y++)
                {


                    if (grid[i][y] == 1)
                    {
                        queue.Enqueue((i, y));
                        isFound = true;
                    }
                }
            }

            while (queue.Count > 0)
            {

            }

            return 0;
        }
    }
}
