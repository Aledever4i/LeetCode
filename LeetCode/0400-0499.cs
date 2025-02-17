﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        /// 402. Remove K Digits
        /// </summary>
        public static string RemoveKdigits(string num, int k)
        {
            if (num.Length == k)
            {
                return "0"; 
            }

            StringBuilder result = new();
            int digitsToRemove = k;

            foreach (char digit in num)
            {
                while (digitsToRemove > 0 && result.Length > 0 && result[result.Length - 1] > digit)
                {
                    result.Remove(result.Length - 1, 1);
                    digitsToRemove--;
                }
                result.Append(digit);
            }

            while (digitsToRemove > 0)
            {
                result.Remove(result.Length - 1, 1);
                digitsToRemove--;
            }

            while (result.Length > 1 && result[0] == '0')
            {
                result.Remove(0, 1);
            }

            return result.ToString();
        }

        /// <summary>
        /// 404. Sum of Left Leaves
        /// </summary>
        public static int SumOfLeftLeaves(TreeNode root)
        {
            int LeftSum(TreeNode root, bool isLeft)
            {
                if (root == null)
                {
                    return 0;
                }

                if (root.left == null && root.right == null)
                {
                    return isLeft ? root.val : 0; 
                }

                return LeftSum(root.left, true) + LeftSum(root.right, false);
            }

            return LeftSum(root, false);
        }

        /// <summary>
        /// 407. Trapping Rain Water II
        /// </summary>
        public static int TrapRainWater(int[][] heightMap)
        {
            int[] dRow = { 0, 0, -1, 1 };
            int[] dCol = { -1, 1, 0, 0 };

            int numOfRows = heightMap.Length;
            int numOfCols = heightMap[0].Length;

            bool[][] visited = new bool[numOfRows][];
            for (int i = 0; i < visited.Length; i++)
            {
                visited[i] = new bool[numOfCols];
            }

            var boundary = new PriorityQueue<Cell407, int>();
            for (int i = 0; i < numOfRows; i++)
            {
                boundary.Enqueue(new Cell407(heightMap[i][0], i, 0), heightMap[i][0]);
                boundary.Enqueue(new Cell407(heightMap[i][numOfCols - 1], i, numOfCols - 1), heightMap[i][numOfCols - 1]);
                visited[i][0] = visited[i][numOfCols - 1] = true;
            }

            for (int i = 0; i < numOfCols; i++)
            {
                boundary.Enqueue(new Cell407(heightMap[0][i], 0, i), heightMap[0][i]);
                boundary.Enqueue(new Cell407(heightMap[numOfRows - 1][i], numOfRows - 1, i), heightMap[numOfRows - 1][i]);
                visited[0][i] = visited[numOfRows - 1][i] = true;
            }

            int totalWaterVolume = 0;
            while (boundary.Count > 0)
            {
                Cell407 currentCell = boundary.Dequeue();

                int currentRow = currentCell.row;
                int currentCol = currentCell.col;
                int minBoundaryHeight = currentCell.height;

                for (int direction = 0; direction < 4; direction++)
                {
                    int neighborRow = currentRow + dRow[direction];
                    int neighborCol = currentCol + dCol[direction];

                    if (IsValidCell(neighborRow, neighborCol, numOfRows, numOfCols) && !visited[neighborRow][neighborCol])
                    {
                        int neighborHeight = heightMap[neighborRow][neighborCol];

                        if (neighborHeight < minBoundaryHeight)
                        {
                            totalWaterVolume += minBoundaryHeight - neighborHeight;
                        }

                        boundary.Enqueue(new Cell407(Math.Max(neighborHeight, minBoundaryHeight), neighborRow, neighborCol), Math.Max(neighborHeight, minBoundaryHeight));
                        visited[neighborRow][neighborCol] = true;
                    }
                }
            }

            return totalWaterVolume;

            bool IsValidCell(int row, int col, int numOfRows, int numOfCols)
            {
                return row >= 0 && col >= 0 && row < numOfRows && col < numOfCols;
            }
        }

        public class Cell407(int height, int row, int col)
        {
            public readonly int height = height;
            public readonly int row = row;
            public readonly int col = col;
        }

        /// <summary>
        /// 413. Arithmetic Slices
        /// </summary>
        public static int NumberOfArithmeticSlices(int[] nums)
        {
            var result = 0;
            var n = nums.Length;

            for (int i = 0; i < n - 2; i++)
            {
                int diff = nums[i + 1] - nums[i];
                for (int y = i + 2; y < n; y++)
                {
                    if (nums[y] - diff == nums[y - 1])
                    {
                        result += 1;
                    }
                    else
                    {
                        break;
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
        /// 440. K-th Smallest in Lexicographical Order
        /// </summary>
        public static int FindKthNumber(int n, int k)
        {
            var answer = 0;
            var operationCount = 0;
            createChilds(1, 9);
            return answer;

            void createChilds(double startNumber, int count)
            {
                if (startNumber > n || operationCount > k)
                {
                    return;
                }

                for (int i = 0; i < count && operationCount <= k && startNumber + i <= n; i++)
                {
                    var curNum = startNumber + i;
                    operationCount++;
                    if (operationCount == k)
                    {
                        answer = (int)curNum;
                    }

                    if (curNum <= n && curNum * 10 <= n)
                    {
                        createChilds(curNum * 10, 10);
                    }
                }
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
        /// 442. Find All Duplicates in an Array
        /// </summary>
        public static IEnumerable<int> FindDuplicates(int[] nums)
        {
            return Convert(nums).ToList();

            IEnumerable<int> Convert(int[] nums)
            {
                var hash = new HashSet<int>();

                foreach (var i in nums)
                {
                    if (!hash.Add(i))
                    {
                        yield return i;
                    };
                }
            }
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
        /// 446. Arithmetic Slices II - Subsequence
        /// </summary>
        public static int NumberOfArithmeticSlices2(int[] nums)
        {
            var n = nums.Length;
            var result = 0;

            Dictionary<int, int>[] dp = new Dictionary<int, int>[n];
            for (int i = 0; i < n; i++)
            {
                dp[i] = new Dictionary<int, int>();
            }

            for (int i = 0; i < n; i++)
            {
                for (int y = 0; y < i; y++)
                {
                    long diff = (long)nums[i] - nums[y];
                    if (diff > int.MaxValue || diff < int.MinValue)
                    {
                        continue;
                    }

                    if (!dp[i].TryAdd((int)diff, 1))
                    {
                        dp[i][(int)diff] += 1;
                    }

                    if (dp[y].ContainsKey((int)diff))
                    {
                        dp[i][(int)diff] += dp[y][(int)diff];
                        result += dp[y][(int)diff];
                    }
                }
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
        /// 451. Sort Characters By Frequency
        /// </summary>
        public static string FrequencySort(string s)
        {
            var count = new int[128];
            Array.Fill(count, 0);
            foreach (char c in s)
            {
                count[c]++;
            }

            StringBuilder stringBuilder = new StringBuilder();
            foreach (var c in count.Select((v, index) => new { c = v, index = index }).Where(v => v.c > 0).OrderByDescending(v => v.c))
            {
                stringBuilder.Append(string.Join("", Enumerable.Repeat((char)c.index, c.c)));
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// 452. Minimum Number of Arrows to Burst Balloons
        /// </summary>
        public static int FindMinArrowShots(int[][] points)
        {
            void Sort<T>(T[][] data, int col)
            {
                Comparer<T> comparer = Comparer<T>.Default;
                Array.Sort<T[]>(data, (x, y) => comparer.Compare(y[col], x[col]));
            }

            Sort(points, 1);
            var count = 0;
            var stack = new Stack<int[]>();
            foreach (var point in points)
            {
                stack.Push(point);
            }

            while (stack.Count > 0)
            {
                count++;
                var data = stack.Pop();

                while (stack.TryPeek(out int[] result) && result[0] <= data[1])
                {
                    stack.Pop();
                }
            }
            return count;
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

        /// <summary>
        /// 476. Number Complement
        /// </summary>
        public static int FindComplement(int num)
        {
            var c = string.Join("", Convert.ToString(num, 2).Select(c => c == '1' ? '0' : '1'));
            c = c.TrimStart('0');
            return c.Length == 0 ? 0 : Convert.ToInt32(c, 2);
        }

        /// <summary>
        /// 482. License Key Formatting
        /// </summary>
        public static string LicenseKeyFormatting(string s, int k)
        {
            var result = new StringBuilder();
            var charCount = 0;

            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] != '-')
                {
                    if (charCount == k)
                    {
                        result.Append('-');
                        charCount = 0;
                    }

                    result.Append(s[i]);
                    charCount++;
                }
            }

            return (new string(result.ToString().Reverse().ToArray())).ToUpper();
        }

        /// <summary>
        /// 495. Teemo Attacking
        /// </summary>
        public static int FindPoisonedDuration(int[] timeSeries, int duration)
        {
            var result = 0;
            for (int i = 0; i < timeSeries.Length; i++)
            {
                if (i + 1 == timeSeries.Length)
                {
                    result += duration;
                }
                else
                {
                    var current = timeSeries[i];
                    var next = timeSeries[i + 1];

                    result += (current + duration < next) ? duration : next - current;
                }
            }

            return result;
        }
    }
}
