using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class _1500_1599
    {
        /// <summary>
        /// 1502. Can Make Arithmetic Progression From Sequence. Tags: Array, Sorting
        /// </summary>
        public static bool CanMakeArithmeticProgression(int[] arr)
        {
            if (arr.Length == 2)
            {
                return true;
            }

            var sorted = arr.OrderBy(value => value);
            var firstElement = sorted.ElementAt(0);
            var step = sorted.ElementAt(1) - firstElement;

            for (int i = 2; i < arr.Length; i++)
            {
                if (sorted.ElementAt(i) != firstElement + step * i)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 1503. Last Moment Before All Ants Fall Out of a Plank
        /// </summary>
        public static int GetLastMoment(int n, int[] left, int[] right)
        {
            var leftMax = left.Length > 0 ? left.Max() : 0;
            var rightMin = right.Length > 0 ? n - right.Min() : 0;

            return Math.Max(leftMax, rightMin);
        }

        /// <summary>
        /// 1509. Minimum Difference Between Largest and Smallest Value in Three Moves
        /// </summary>
        public static int MinDifference(int[] nums)
        {
            if (nums.Length <= 4)
            {
                return 0;
            }

            Array.Sort(nums);

            var answers = new int[] {
                nums[nums.Length - 4] - nums[0],
                nums[nums.Length - 3] - nums[1],
                nums[nums.Length - 2] - nums[2],
                nums[nums.Length - 1] - nums[3]
            };

            return answers.Min();
        }

        /// <summary>
        /// 1512. Number of Good Pairs
        /// </summary>
        public static int NumIdenticalPairs(int[] nums)
        {
            var n = nums.Length;
            var counts = new int[101];
            var fibCount = new int[n + 1];
            fibCount[0] = 0;
            fibCount[1] = 0;

            if (n < 2)
            {
                return 0;
            }

            for (int i = 2; i < n + 1; i++)
            {
                fibCount[i] = fibCount[i - 1] + i - 1;
            }

            var result = 0;

            foreach (var num in nums)
            {
                counts[num]++;
            }

            foreach (var count in counts.Where(val => val > 1))
            {
                result += fibCount[count];
            }

            return result;
        }

        /// <summary>
        /// 1518. Water Bottles
        /// </summary>
        public static int NumWaterBottles(int numBottles, int numExchange)
        {
            var result = numBottles;

            while (numBottles >= numExchange)
            {
                result += numBottles / numExchange;
                numBottles = numBottles % numExchange + numBottles / numExchange;
            }

            return result;
        }

        /// <summary>
        /// 1530. Number of Good Leaf Nodes Pairs
        /// </summary>
        public static int CountPairs(TreeNode root, int distance)
        {
            int result = 0;
            Dfs(root, distance);
            return result;

            List<int> Dfs(TreeNode node, int distance)
            {
                if (node == null) return new List<int>();
                if (node.left == null && node.right == null) return new List<int> { 0 };

                var leftDistances = Dfs(node.left, distance);
                var rightDistances = Dfs(node.right, distance);

                foreach (int l in leftDistances)
                {
                    foreach (int r in rightDistances)
                    {
                        if (l + r + 2 <= distance) result++;
                    }
                }

                var distances = new List<int>();
                foreach (int l in leftDistances) distances.Add(l + 1);
                foreach (int r in rightDistances) distances.Add(r + 1);
                return distances;
            }
        }

        /// <summary>
        /// 1535. Find the Winner of an Array Game
        /// </summary>
        public static int GetWinner(int[] arr, int k)
        {
            var currentWinCount = 0;
            var queue = new Queue<int>(arr);
            var currentItem = queue.Dequeue();
            var hash = new HashSet<int>();

            while (queue.Count > 0)
            {
                var nextItem = queue.Dequeue();

                if (hash.Contains(nextItem))
                {
                    return currentItem;
                }

                if (currentItem > nextItem)
                {
                    currentWinCount++;
                    queue.Enqueue(nextItem);
                    hash.Add(nextItem);
                }
                else
                {
                    currentWinCount = 1;
                    queue.Enqueue(currentItem);
                    hash.Add(currentItem);
                    currentItem = nextItem;
                }

                if (currentWinCount == k)
                {
                    return currentItem;
                }
            }

            return 0;
        }

        /// <summary>
        /// 1544. Make The String Great
        /// </summary>
        public static string MakeGood(string s)
        {
            var list = new List<char>();

            for (int i = 0; i < s.Length; i++)
            {
                var current = s[i];

                if (list.Count == 0)
                {
                    list.Add(current);
                    continue;
                }

                var previous = list[list.Count - 1];

                if (current != previous && Char.ToLower(current) == Char.ToLower(previous))
                {
                    list.RemoveAt(list.Count - 1);
                }
                else
                {
                    list.Add(current);
                }
            }

            return string.Join("", list);
        }

        /// <summary>
        /// 1550. Three Consecutive Odds
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static bool ThreeConsecutiveOdds(int[] arr)
        {
            if (arr.Length <= 2)
            {
                return false;
            }

            int a = arr[0];
            int b = arr[1];
            int c;

            for (int i = 2; i < arr.Length; i++)
            {
                c = arr[i];

                if (a % 2 == 1 && b % 2 == 1 && c % 2 == 1)
                {
                    return true;
                }

                a = b;
                b = c;
            }

            return false;
        }

        /// <summary>
        /// 1556. Thousand Separator
        /// </summary>
        public static string ThousandSeparator(int n)
        {
            return string.Join("", n.ToString().Reverse().Select((x, i) => { return ((i + 1) % 3 == 0 && (i + 1 < n.ToString().Length)) ? $".{x}" : x.ToString(); }).Reverse());
        }

        /// <summary>
        /// 1558. Minimum Numbers of Function Calls to Make Target Array. Graph
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <returns></returns>
        public static IList<int> FindSmallestSetOfVertices(int n, IList<IList<int>> edges)
        {
            if (n <= 1)
            {
                return new List<int>();
            }

            var result = new List<int>();

            var seconds = edges.Select(edge => edge.ElementAt(1)).Distinct();

            var empty = Enumerable.Range(0, n).Except(seconds).ToList();

            return empty;
        }

        /// <summary>
        /// 1560. Most Visited Sector in a Circular Track
        /// </summary>
        public static IList<int> MostVisited(int n, int[] rounds)
        {
            if (n == 1)
            {
                return [1];
            }

            var first = rounds[0];
            var prev = rounds[rounds.Length - 1];

            var result = new List<int>();
            if (prev >= first)
            {
                for (int i = first; i <= prev; i++)
                {
                    result.Add(i);
                }
            }
            else
            {
                for (int i = 1; i <= prev; i++)
                {
                    result.Add(i);
                }

                for (int i = first; i <= n; i++)
                {
                    result.Add(i);
                }
            }

            return result;
        }

        /// <summary>
        /// 1569. Number of Ways to Reorder Array to Get Same BST. Tags: Array, Math, Divide and Conquer, Dynamic Programming, Tree, Union Find, Binary Search Tree, Memoization, Combinatorics, Binary Tree
        /// </summary>
        public static int NumOfWays(int[] nums)
        {
            return 0 % 1_000_000_007;
        }

        public static int CountRoutes(int[] locations, int start, int finish, int fuel)
        {
            int solve(int[] locations, int currCity, int finish, int remainingFuel, int[][] memo)
            {
                if (remainingFuel < 0)
                {
                    return 0;
                }
                if (memo[currCity][remainingFuel] != -1)
                {
                    return memo[currCity][remainingFuel];
                }

                int ans = currCity == finish ? 1 : 0;
                for (int nextCity = 0; nextCity < locations.Length; nextCity++)
                {
                    if (nextCity != currCity)
                    {
                        ans = (ans + solve(locations, nextCity, finish,
                        remainingFuel - Math.Abs(locations[currCity] - locations[nextCity]),
                                           memo)) % 1000000007;
                    }
                }

                return memo[currCity][remainingFuel] = ans;
            }

            int n = locations.Length;
            int[][] memo = new int[n][];
            for (int i = 0; i < n; ++i)
            {
                memo[i] = new int[fuel + 1];
                System.Array.Fill(memo[i], -1);
            }

            return solve(locations, start, finish, fuel, memo);
        }

        /// <summary>
        /// 1572. Matrix Diagonal Sum
        /// </summary>
        public static int DiagonalSum(int[][] matrix)
        {
            var x = matrix[0].Length;
            var y = matrix.Length;

            var elements = x * y;
            var result = 0;
            var res = 0;

            if (elements % 2 == 0)
            {
                var centerDownRight = ((int)Math.Sqrt(elements)) / 2;

                res = matrix[centerDownRight][centerDownRight];
                result += res;
                for (int i = 1; i < centerDownRight; i++)
                {
                    res = matrix[centerDownRight + i][centerDownRight + i];
                    result += res;
                }

                res = matrix[centerDownRight - 1][centerDownRight];
                result += res;
                for (int i = 1; i < centerDownRight; i++)
                {
                    res = matrix[centerDownRight - 1 - i][centerDownRight + i];
                    result += res;
                }

                res = matrix[centerDownRight - 1][centerDownRight - 1];
                result += res;
                for (int i = 1; i < centerDownRight; i++)
                {
                    res = matrix[centerDownRight - 1 - i][centerDownRight - 1 - i];
                    result += res;
                }

                res = matrix[centerDownRight][centerDownRight - 1];
                result += res;
                for (int i = 1; i < centerDownRight; i++)
                {
                    res = matrix[centerDownRight + i][centerDownRight - 1 - i];
                    result += res;
                }

                return result;
            }
            else
            {
                var center = ((int)Math.Sqrt(elements) - 1) / 2;

                for (int i = 1; i <= center; i++)
                {
                    result += matrix[center - i][center - i] + matrix[center + i][center + i] + matrix[center + i][center - i] + matrix[center - i][center + i];
                }

                return result + matrix[center][center];
            }
        }

        /// <summary>
        /// 1574. Shortest Subarray to be Removed to Make Array Sorted
        /// </summary>
        public static int FindLengthOfShortestSubarray(int[] arr)
        {
            int right = arr.Length - 1;
            while (right > 0 && arr[right] >= arr[right - 1])
            {
                right--;
            }

            int ans = right;
            int left = 0;
            while (left < right && (left == 0 || arr[left - 1] <= arr[left]))
            {
                while (right < arr.Length && arr[left] > arr[right])
                {
                    right++;
                }
                ans = Math.Min(ans, right - left - 1);
                left++;
            }
            return ans;
        }

        /// <summary>
        /// 1590. Make Sum Divisible by P
        /// </summary>
        public static int MinSubarray(int[] nums, int p)
        {
            var array = nums.Select(x => x % p).Where(x => x > 0).GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            var hasChanges = true;

            foreach (var key in array.Keys)
            {
                
            }

            while (hasChanges)
            {
                
            }

            return array[0];
        }

        /// <summary>
        /// 1598. Crawler Log Folder
        /// </summary>
        public static int MinOperations(string[] logs)
        {
            var result = 0;
            foreach (var log in logs)
            {
                if (log == "./")
                {
                    continue;
                }
                else if (log == "../")
                {
                    result = (result > 0) ? result - 1 : 0;
                }
                else
                {
                    result++;
                }
            }

            return result;
        }
    }
}
