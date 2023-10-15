using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace LeetCode.Contest
{
    public static class _367
    {
        /// <summary>
        /// 2903. Find Indices With Index and Value Difference I
        /// </summary>
        public static int[] FindIndices(int[] nums, int indexDifference, int valueDifference)
        {
            var n = nums.Length;

            for (int i = 0; i < n; i++)
            {
                var value = nums[i];

                if (i + indexDifference >= n)
                {
                    continue;
                }

                for (int y = i + indexDifference; y < n; y++)
                {
                    if (Math.Abs(value - nums[y]) >= valueDifference)
                    {
                        return new int[] { i, y };
                    }   
                }
            }

            return new int[] { -1, -1 };
        }

        /// <summary>
        /// 2904. Shortest and Lexicographically Smallest Beautiful String
        /// </summary>
        public static string ShortestBeautifulSubstring(string s, int k)
        {
            var currentBeautifulString = string.Empty;
            var currentOnes = 0;
            var queue = new Queue<char>();

            foreach (var c in s)
            {
                queue.Enqueue(c);

                if (c == '1')
                {
                    currentOnes = currentOnes + 1;
                }

                if (currentOnes == k && (queue.Count < currentBeautifulString.Length || currentBeautifulString == string.Empty))
                {
                    currentBeautifulString = new string(queue.Select(c => c).ToArray());
                }

                while (queue.Count > 0 && (currentOnes > k || queue.Peek() == '0'))
                {
                    if (queue.Peek() == '1')
                    {
                        currentOnes--;
                    }

                    queue.Dequeue();

                    if (
                        currentOnes == k
                        && (
                            queue.Count < currentBeautifulString.Length
                            || currentBeautifulString == string.Empty
                            || (
                                queue.Count == currentBeautifulString.Length
                                && largerCheck(currentBeautifulString.ToCharArray(), queue.Select(c => c).ToArray())
                            )
                        )
                    )
                    {
                        currentBeautifulString = new string(queue.Select(c => c).ToArray());
                    }
                }
            }

            bool largerCheck(char[] current, char[] newArray)
            {
                for (int i = 0; i < current.Length; i++)
                {
                    if (current[i] > newArray[i])
                    {
                        return true;
                    }

                    if (newArray[i] > current[i])
                    {
                        return false;
                    }
                }

                return false;
            }

            return currentBeautifulString;
        }

        /// <summary>
        /// 2905. Find Indices With Index and Value Difference II
        /// </summary>
        public static int[] FindIndices2(int[] nums, int indexDifference, int valueDifference)
        {
            var n = nums.Length;
            var linked = new LinkedList<int>(nums[0..indexDifference]);

            for (int i = 0; i < n; i++)
            {
                var value = nums[i];

                if (i + indexDifference >= n)
                {
                    continue;
                }

                for (int y = i + indexDifference; y < n; y++)
                {
                    if (Math.Abs(value - nums[y]) >= valueDifference)
                    {
                        return new int[] { i, y };
                    }
                }
            }

            return new int[] { -1, -1 };
        }

        /// <summary>
        /// 2906. Construct Product Matrix
        /// </summary>
        public static int[][] ConstructProductMatrix(int[][] grid)
        {
            var n = grid.Length;
            var m = grid[0].Length;

            var result = new int[n][];
            for (int i = 0; i < n; i++)
            {
                result[i] = new int[m];
            }

            BigInteger preMultiple = 1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    result[i][j] = (int)(preMultiple % 12345);
                    preMultiple = preMultiple * grid[i][j] % 12345;
                }
            }

            BigInteger sufMulti = 1;
            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = m - 1; j >= 0; j--)
                {
                    result[i][j] = (int)(result[i][j] * sufMulti % 12345);
                    sufMulti = sufMulti * grid[i][j] % 12345;
                }
            }

            return result;
        }
    }
}
