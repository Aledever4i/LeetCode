using LeetCode.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        /// 2064. Minimized Maximum of Products Distributed to Any Store
        /// </summary>
        public static int MinimizedMaximum(int n, int[] quantities)
        {
            int left = 1;
            int right = quantities.Max();

            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (CanDistribute(n, quantities, mid))
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return left;

            bool CanDistribute(int n, int[] quantities, int maxProductsPerStore)
            {
                int requiredStores = 0;
                foreach (int quantity in quantities)
                {
                    requiredStores += (quantity + maxProductsPerStore - 1) / maxProductsPerStore;
                    if (requiredStores > n)
                    {
                        return false;
                    }
                }

                return requiredStores <= n;
            }
        }

        /// <summary>
        /// 2070. Most Beautiful Item for Each Query
        /// </summary>
        public static int[] MaximumBeauty(int[][] items, int[] queries)
        {
            var newItems2 = items.Select(x => (x[0], x[1])).OrderBy(x => x.Item1).ToArray();

            var currentPrice = newItems2[0].Item1;
            var currentBeauty = newItems2[0].Item2;

            var itemsList = new List<(int, int)>();

            for (int i = 1; i < newItems2.Length; i++)
            {
                var price = newItems2[i].Item1;
                var beauty = newItems2[i].Item2;

                if (beauty > currentBeauty && price == currentPrice)
                {
                    currentBeauty = beauty;
                }
                else if (currentBeauty >= beauty)
                {
                    continue;
                }
                else if (beauty > currentBeauty && price > currentPrice)
                {
                    itemsList.Add((currentPrice, currentBeauty));
                    currentBeauty = beauty;
                    currentPrice = price;
                }
            }

            var count = itemsList.Count();
            if (count == 0)
            {
                itemsList.Add((currentPrice, currentBeauty));
            }
            else
            {
                var last = itemsList[itemsList.Count() - 1];
                if (currentBeauty > last.Item2 && currentPrice > last.Item1)
                {
                    itemsList.Add((currentPrice, currentBeauty));
                }
            }

            return queries.Select(v => find(v, 0, itemsList.Count() - 1, itemsList.ToArray())).ToArray();

            int find(int price, int left, int right, (int Key, int Value)[] newItems)
            {
                var (Key, Value) = newItems[left];
                if (Key > price)
                {
                    if (left == 0)
                    {
                        return 0;
                    }

                    return newItems[left - 1].Value;
                }
                if (left >= right)
                {
                    return newItems[right].Value;
                }

                var index = (left + right) / 2;
                var element = newItems[index];

                if (element.Key == price)
                {
                    return element.Value;
                }
                else if (element.Key > price)
                {
                    return find(price, left, index, newItems);
                }
                else
                {
                    return find(price, index + 1, right, newItems);
                }
            }
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
            var startPath = new StringBuilder();
            SearchPathByBFS(root, startValue, new StringBuilder(), ref startPath);

            var destinationPath = new StringBuilder();
            SearchPathByBFS(root, destValue, new StringBuilder(), ref destinationPath);

            var (aRemoved, bRemoved) = StringFunctions.LowestCommonAncestorRemove(startPath.ToString(), destinationPath.ToString());
            return $"{string.Join("", Enumerable.Repeat("U", aRemoved.Length))}{bRemoved}";

            void SearchPathByBFS(TreeNode root, int searchValue, StringBuilder path, ref StringBuilder resultPath)
            {
                if (root == null)
                {
                    return;
                }

                if (root.val == searchValue)
                {
                    resultPath.Append(path.ToString());
                    return;
                }

                path.Append("L");
                SearchPathByBFS(root.left, searchValue, path, ref resultPath);
                path.Remove(path.Length - 1, 1);

                path.Append("R");
                SearchPathByBFS(root.right, searchValue, path, ref resultPath);
                path.Remove(path.Length - 1, 1);
            }
        }
    }
}
