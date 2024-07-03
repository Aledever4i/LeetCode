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
    }
}
