using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace LeetCode
{
    public static class _1000_1099
    {
        /// <summary>
        /// 1018. Binary Prefix Divisible By 5
        /// </summary>
        public static IList<bool> PrefixesDivBy5(int[] nums)
        {


            return new List<bool>();
        }

        /// <summary>
        /// 1025. Divisor Game
        /// </summary>
        public static bool DivisorGame(int n)
        {
            return (n % 2 == 0);
        }

        /// <summary>
        /// 1027. Longest Arithmetic Subsequence. Tags: Array, Hash Table, Binary Search, Dynamic Programming
        /// </summary>
        public static int LongestArithSeqLength(int[] nums)
        {
            var length = nums.Length;

            if (length == 2)
            {
                return 2;
            }

            var dp = new Dictionary<(int, int), int>();
            var maxLength = 0;

            for (int right = 0; right < length; right++)
            {
                var rightValue = nums[right];

                for (int left = 0; left < right; left++)
                {
                    var leftValue = nums[left];
                    int diff = leftValue - rightValue;

                    if (dp.TryGetValue((left, diff), out int prevValue))
                    {
                        dp[(right, diff)] = prevValue + 1;
                    }
                    else
                    {
                        dp[(right, diff)] = 2;
                    }

                    maxLength = Math.Max(maxLength, dp[(right, diff)]);
                }
            }

            return maxLength;
        }

        /// <summary>
        /// 1035. Uncrossed Lines
        /// Высчитывал через матрицу + таблица для кеширования результатов.
        /// TODO: Изучить более легкий алгоритм https://leetcode.com/problems/uncrossed-lines/solutions/3510389/easy-and-fast-c-solution-with-explanation/?orderBy=most_votes&languageTags=csharp
        /// </summary>
        public static int MaxUncrossedLines(int[] nums1, int[] nums2)
        {
            var cacheTable = new int?[nums1.Length, nums2.Length];

            var coincidences = new int?[nums1.Length][];
            for (int i = 0; i < nums1.Length; i++)
            {
                coincidences[i] = new int?[nums2.Length];
            }

            for (int num1 = 0; num1 < nums1.Length; num1++)
            {
                for (int num2 = 0; num2 < nums2.Length; num2++)
                {
                    coincidences[num1][num2] = (nums1[num1] == nums2[num2]) ? num2 : -1;
                }
            }

            int coincidence(int num1Index, int num2Index)
            {
                var value = cacheTable[num1Index, num2Index];
                if (value == default)
                {
                    int? nearestIndex = coincidences[num1Index].Where(num2 => num2 >= num2Index).FirstOrDefault();

                    if (nearestIndex != null)
                    {
                        if (nearestIndex == nums2.Length - 1 || num1Index == nums1.Length - 1)
                        {
                            value = 1;
                        }
                        else
                        {
                            var tempResultWith = 0;

                            for (int next = num1Index + 1; next < nums1.Length; next++)
                            {
                                var x = coincidence(next, nearestIndex.Value + 1);

                                tempResultWith = (x > tempResultWith) ? x : tempResultWith;
                            }

                            value = 1 + tempResultWith;
                        }
                    }
                    else
                    {
                        if (nearestIndex == nums2.Length - 1 || num1Index == nums1.Length - 1)
                        {
                            value = 0;
                        }
                        else
                        {
                            var next = num1Index + 1;
                            value = coincidence(next, nearestIndex ?? num2Index);
                        }
                    }

                    cacheTable[num1Index, num2Index] = value;
                }

                return value ?? 0;
            }

            int result = 0;
            for (int num1 = 0; num1 < nums1.Length; num1++)
            {
                var count = coincidence(num1, 0);

                result = (count > result) ? count : result;
            }


            return result;
        }

        /// <summary>
        /// 1043. Partition Array for Maximum Sum
        /// </summary>
        public static int MaxSumAfterPartitioning(int[] arr, int k)
        {
            var n = arr.Length;

            if (n == k)
            {
                return arr.Max() * n;
            }
            else if (k == 1)
            {
                return arr.Sum();
            }

            var dp = new int[n];
            Array.Fill(dp, -1);
            return maxSum(arr, k, dp, 0);

            int maxSum(int[] arr, int k, int[] dp, int start)
            {
                if (start >= n)
                {
                    return 0;
                }

                if (dp[start] != -1)
                {
                    return dp[start];
                }

                var currMax = 0;
                var ans = 0;
                int end = Math.Min(n, start + k);

                for (int i = start; i < end; i++)
                {
                    currMax = Math.Max(currMax, arr[i]);

                    ans = Math.Max(ans, currMax * (i - start + 1) + maxSum(arr, k, dp, i + 1));
                }

                return dp[start] = ans;
            }
        }

        /// <summary>
        /// 1048. Longest String Chain
        /// </summary>
        public static int LongestStrChain(string[] words)
        {
            System.Array.Sort(words, (a, b) => { return a.Length - b.Length; });

            var chainCount = new string[words.Length][];

            return 0;
        }

        /// <summary>
        /// 1072. Flip Columns For Maximum Number of Equal Rows
        /// </summary>
        public static int MaxEqualRowsAfterFlips(int[][] matrix)
        {
            Dictionary<string, int> patternFrequency = new();

            foreach (int[] currentRow in matrix)
            {
                StringBuilder patternBuilder = new();
                for (int col = 0; col < currentRow.Length; col++)
                {
                    patternBuilder.Append((currentRow[0] == currentRow[col]) ? 'T' : 'F');
                }

                string rowPattern = patternBuilder.ToString();

                if (!patternFrequency.TryAdd(rowPattern, 1))
                {
                    patternFrequency[rowPattern] += 1;
                }
            }

            return patternFrequency.Values.Max();
        }

        /// <summary>
        /// 1089. Duplicate Zeros
        /// </summary>
        public static void DuplicateZeros(int[] arr)
        {
            var n = arr.Length;
            var newArray = new int[n];
            var zeroCount = 0;

            for (int i = 0; i < n - zeroCount; i++)
            {
                newArray[i + zeroCount] = arr[i];
                if (arr[i] == 0 && i + 1 < n - zeroCount)
                {
                    zeroCount++;
                    newArray[i + zeroCount] = 0;
                }
            }

            newArray.CopyTo(arr, 0);
        }


        /// <summary>
        /// 1091. Shortest Path in Binary Matrix. Tags: Array, Breadth-First Search, Matrix
        /// </summary>
        public static int ShortestPathBinaryMatrix(int[][] grid)
        {
            var n = grid.Length;
            var ways = new List<(int, int, int)>();
            var results = new List<int>();

            var visited = new int[n][];
            for (var i = 0; i < n; i++ )
            {
                visited[i] = new int[n];
            }

            if (grid[0][0] == 1 || grid[n - 1][n - 1] == 1)
            {
                return -1;
            }

            analyse(0, 0, 1);

            while (ways.Count > 0)
            {
                var item = ways.First();
                ways.RemoveAt(0);

                analyse(item.Item1, item.Item2, item.Item3);
            }

            return results.Any() ? results.Min() : -1;

            void analyse(int x, int y, int count)
            {
                if (x == n - 1 && y == n - 1)
                {
                    results.Add(count);
                    return;
                }

                if (x < n - 1 && y < n - 1 && visited[x + 1][y + 1] < 8 && grid[x + 1][y + 1] == 0)
                {
                    ways.Add((x + 1, y + 1, count + 1));
                    visited[x + 1][y + 1] += 1;
                }

                if (x < n - 1 && visited[x + 1][y] < 8 && grid[x + 1][y] == 0)
                {
                    ways.Add((x + 1, y, count + 1));
                    visited[x + 1][y] += 1;
                }

                if (y < n - 1 && visited[x][y + 1] < 8 && grid[x][y + 1] == 0)
                {
                    ways.Add((x, y + 1, count + 1));
                    visited[x][y + 1] += 1;
                }

                if (x > 0 && y < n - 1 && visited[x - 1][y + 1] < 8 && grid[x - 1][y + 1] == 0)
                {
                    ways.Add((x - 1, y + 1, count + 1));
                    visited[x - 1][y + 1] += 1;
                }

                if (y > 0 && visited[x][y - 1] < 8 && grid[x][y - 1] == 0)
                {
                    ways.Add((x, y - 1, count + 1));
                    visited[x][y - 1] += 1;
                }

                if (y > 0 && x < n - 1 && visited[x + 1][y - 1] < 8 && grid[x + 1][y - 1] == 0)
                {
                    ways.Add((x + 1, y - 1, count + 1));
                    visited[x + 1][y - 1] += 1;
                }

                if (x > 0 && visited[x - 1][y] < 8 && grid[x - 1][y] == 0)
                {
                    ways.Add((x - 1, y, count + 1));
                    visited[x - 1][y] += 1;
                }

                if (x > 0 && y > 0 && visited[x - 1][y - 1] < 8 && grid[x - 1][y - 1] == 0)
                {
                    ways.Add((x - 1, y - 1, count + 1));
                    visited[x - 1][y - 1] += 1;
                }
            }
        }

        /// <summary>
        /// 1095. Find in Mountain Array
        /// </summary>
        public static int FindInMountainArray(int target, IMountainArray mountainArr)
        {
            int len = mountainArr.Length();

            var left = 0;
            var right = len - 1;

            while (left != right)
            {
                var mid = (int)(left + right) / 2;
                if (mountainArr.Get(mid) < mountainArr.Get(mid + 1))
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            int peak = left;
            left = 0;
            right = peak;

            while (left != right)
            {
                var mid = (int)(left + right) / 2;
                if (mountainArr.Get(mid) < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            if (mountainArr.Get(left) == target)
            {
                return left;
            }

            left = peak + 1;
            right = len - 1;

            while (left != right)
            {
                var mid = (int)(left + right) / 2;
                if (mountainArr.Get(mid) > target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            if (mountainArr.Get(left) == target)
            {
                return left;
            }

            return -1;
        }
    }

    public interface IMountainArray
    {
        public int Get(int index);
        public int Length();
    }
}
