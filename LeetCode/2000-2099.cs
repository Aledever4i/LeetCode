using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    public static class _2000_2099
    {
        /// <summary>
        /// 2009. Minimum Number of Operations to Make Array Continuous
        /// </summary>
        public static int MinOperations(int[] nums)
        {
            var initialN = nums.Length;
            System.Array.Sort(nums);

            var newNums = nums.Distinct().ToArray();

            var n = newNums.Length;
            var ans = initialN;

            var j = 0;
            for (int i = 0; i < n; i++)
            {
                var vMax = newNums[i] + initialN;
                while (j < n && newNums[j] < vMax)
                {
                    j++;
                }

                ans = Math.Min(ans, initialN - j + i);
            }

            return ans;
        }

        /// <summary>
        /// 2024. Maximize the Confusion of an Exam
        /// </summary>
        public static int MaxConsecutiveAnswers(string answerKey, int k)
        {
            var array = answerKey.ToCharArray();
            var n = array.Length;

            var maxSum = 0;
            var left = 0;
            var right = 0;
            var frequency = 0;

            for (int i = 0; i < n; i++)
            {
                var value = array[i];
                right++;

                if (value == 'F')
                {
                    frequency++;

                    while (frequency > k)
                    {
                        maxSum = Math.Max(maxSum, right - left - 1);
                        value = array[left];
                        left++;
                        if (value == 'F')
                        {
                            frequency--;
                        }
                    }
                }
            }
            maxSum = Math.Max(maxSum, right - left);

            left = 0;
            right = 0;
            frequency = 0;
            for (int i = 0; i < n; i++)
            {
                var value = array[i];
                right++;

                if (value == 'T')
                {
                    frequency++;

                    while (frequency > k)
                    {
                        maxSum = Math.Max(maxSum, right - left - 1);
                        value = array[left];
                        left++;
                        if (value == 'T')
                        {
                            frequency--;
                        }
                    }
                }
            }
            maxSum = Math.Max(maxSum, right - left);

            return maxSum;
        }

        /// <summary>
        /// 2038. Remove Colored Pieces if Both Neighbors are the Same Color
        /// </summary>
        public static bool WinnerOfGame(string colors)
        {
            var aliceMoves = 0;
            var bobMoves = 0;
            var n = colors.Length;

            if (n <= 2)
            {
                return false;
            }

            var aliceIndexes = new Queue<int>();
            var bobIndexes = new Queue<int>();

            for (int i = 0; i < n; i++)
            {
                var color = colors[i];

                if (color == 'A')
                {
                    aliceIndexes.Enqueue(i);
                }
                else
                {
                    bobIndexes.Enqueue(i);
                }
            }

            int prevIndex;
            int prevCount;

            if (aliceIndexes.Any())
            {
                prevIndex = aliceIndexes.Dequeue();
                prevCount = 1;

                while (aliceIndexes.Count > 0)
                {
                    var index = aliceIndexes.Dequeue();

                    if (prevIndex + 1 == index)
                    {
                        prevIndex = index;
                        prevCount++;
                    }
                    else
                    {
                        aliceMoves += (prevCount > 2) ? prevCount - 2 : 0;
                        prevCount = 1;
                        prevIndex = index;
                    }
                }

                aliceMoves += (prevCount > 2) ? prevCount - 2 : 0;
            }
            else
            {
                return false;
            }

            if (aliceMoves == 0)
            {
                return false;
            }

            if (bobIndexes.Any())
            {
                prevIndex = bobIndexes.Dequeue();
                prevCount = 1;

                while (bobIndexes.Count > 0)
                {
                    var index = bobIndexes.Dequeue();

                    if (prevIndex + 1 == index)
                    {
                        prevIndex = index;
                        prevCount++;
                    }
                    else
                    {
                        bobMoves += (prevCount > 2) ? prevCount - 2 : 0;
                        prevCount = 1;
                        prevIndex = index;
                    }
                }

                bobMoves += (prevCount > 2) ? prevCount - 2 : 0;
            }

            return (aliceMoves > bobMoves);
        }

        /// <summary>
        /// 2050. Parallel Courses III
        /// </summary>
        public static int MinimumTime(int n, int[][] relations, int[] time)
        {
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; i++)
            {
                graph.Add(i, new List<int>());
            }

            int[] indegree = new int[n];
            foreach (int[] edge in relations)
            {
                int x = edge[0] - 1;
                int y = edge[1] - 1;
                graph[x].Add(y);
                indegree[y]++;
            }

            Queue<int> queue = new Queue<int>();
            int[] maxTime = new int[n];

            for (int node = 0; node < n; node++)
            {
                if (indegree[node] == 0)
                {
                    queue.Enqueue(node);
                    maxTime[node] = time[node];
                }
            }

            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                foreach (int neighbor in graph[node])
                {
                    maxTime[neighbor] = Math.Max(maxTime[neighbor], maxTime[node] + time[neighbor]);
                    indegree[neighbor]--;
                    if (indegree[neighbor] == 0)
                    {
                        queue.Enqueue(neighbor);
                    }
                }
            }

            int ans = 0;
            for (int node = 0; node < n; node++)
            {
                ans = Math.Max(ans, maxTime[node]);
            }

            return ans;
        }

        /// <summary>
        /// 2058. Find the Minimum and Maximum Number of Nodes Between Critical Points
        /// </summary>
        public static int[] NodesBetweenCriticalPoints(ListNode head)
        {
            var answers = new List<int>();
            var prev = head;
            var current = head.next;
            var next = current.next;
            var position = 2;

            while (next != null)
            {
                if (current.val < prev.val && current.val < next.val)
                {
                    answers.Add(position);
                }
                if (current.val > prev.val && current.val > next.val)
                {
                    answers.Add(position);
                }
                position++;
                prev = current;
                current = next;
                next = next.next;
            }
            if (answers.Count <= 1)
            {
                return new int[] { -1, -1 };
            }
            var max = answers.Max() - answers.Min();
            var min = int.MaxValue;
            for (int i = 0; i < answers.Count - 1; i++)
            {
                min = Math.Min(min, answers.ElementAt(i + 1) - answers.ElementAt(i));
            }
            return new int[] { min, max };
        }

        /// <summary>
        /// 2073. Time Needed to Buy Tickets
        /// </summary>
        public static int TimeRequiredToBuy(int[] tickets, int k)
        {
            var count = tickets[k];
            var countRemove = 0;
            if (k + 1 < tickets.Length)
            {
                countRemove = tickets[(k + 1)..].Where(x => x >= count).Count();
            }
            return tickets.Sum(x => Math.Min(x, count)) - countRemove;
        }

        /// <summary>
        /// 2090. K Radius Subarray Averages. Tags: Array, Sliding Window
        /// </summary>
        public static int[] GetAverages(int[] nums, int k)
        {
            var n = nums.Length;
            if (2 * k >= n)
            {
                System.Array.Fill(nums, -1);
                return nums;
            }

            var decimals = new int[n];
            System.Array.Fill(decimals, -1);

            decimal currentWindowValue = 0.0M;

            for (int i = 0; i < n; i++)
            {
                currentWindowValue += nums[i];

                if (i >= 2 * k + 1)
                {
                    currentWindowValue -= nums[i - ((2 * k) + 1)];
                }

                if (i - (2 * k) >= 0)
                {
                    decimals[i - k] = Convert.ToInt32(currentWindowValue / (2 * k + 1));
                }
            }

            return decimals;
        }

        /// <summary>
        /// 2096. Step-By-Step Directions From a Binary Tree Node to Another
        /// </summary>
        public static string GetDirections(TreeNode root, int startValue, int destValue)
        {

        }
    }
}
