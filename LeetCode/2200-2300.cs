using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    public static class _2200_2300
    {
        /// <summary>
        /// 2220. Minimum Bit Flips to Convert Number
        /// </summary>
        public static int MinBitFlips(int start, int goal)
        {
            int xorResult = start ^ goal;
            int count = 0;

            while (xorResult != 0)
            {
                xorResult &= (xorResult - 1);
                count++;
            }
            return count;
        }

        /// <summary>
        /// 2251. Number of Flowers in Full Bloom
        /// </summary>
        public static int[] FullBloomFlowers(int[][] flowers, int[] people)
        {
            int[] sortedPeople = people.OrderBy(v => v).ToArray();
            System.Array.Sort(flowers, (a, b) => a[0].CompareTo(b[0]));

            var dict = new Dictionary<int, int>();
            var queue = new PriorityQueue<int, int>();

            int i = 0;

            foreach (var person in sortedPeople)
            {
                while (i < flowers.Length && flowers[i][0] <= person)
                {
                    queue.Enqueue(flowers[i][1], flowers[i][1]);
                    i++;
                }

                while (queue.Count > 0 && queue.Peek() < person)
                {
                    queue.Dequeue();
                }

                dict[person] = queue.Count;
            }


            var result = new List<int>();
            foreach (var person in people)
            {
                result.Add(dict[person]);
            }
            return result.ToArray();
        }

        /// <summary>
        /// 2257. Count Unguarded Cells in the Grid
        /// </summary>
        public static int CountUnguarded(int m, int n, int[][] guards, int[][] walls)
        {
            int UNGUARDED = 0;
            int GUARDED = 1;
            int GUARD = 2;
            int WALL = 3;

            int[][] grid = new int[m][];
            for (int i = 0; i < m; i++)
            {
                grid[i] = new int[n];
            }

            foreach (int[] guard in guards)
            {
                grid[guard[0]][guard[1]] = GUARD;
            }

            foreach (int[] wall in walls)
            {
                grid[wall[0]][wall[1]] = WALL;
            }

            for (int row = 0; row < m; row++)
            {
                bool isGuardLineActive = grid[row][0] == GUARD;
                for (int col = 1; col < n; col++)
                {
                    isGuardLineActive = updateCellVisibility(grid, row, col, isGuardLineActive);
                }

                isGuardLineActive = grid[row][n - 1] == GUARD;
                for (int col = n - 2; col >= 0; col--)
                {
                    isGuardLineActive = updateCellVisibility(grid, row, col, isGuardLineActive);
                }
            }

            for (int col = 0; col < n; col++)
            {
                bool isGuardLineActive = grid[0][col] == GUARD;
                for (int row = 1; row < m; row++)
                {
                    isGuardLineActive = updateCellVisibility(grid, row, col, isGuardLineActive);
                }

                isGuardLineActive = grid[m - 1][col] == GUARD;
                for (int row = m - 2; row >= 0; row--)
                {
                    isGuardLineActive = updateCellVisibility(grid, row, col, isGuardLineActive);
                }
            }

            int count = 0;
            for (int row = 0; row < m; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (grid[row][col] == UNGUARDED)
                    {
                        count++;
                    }
                }
            }

            return count;

            bool updateCellVisibility(int[][] grid, int row, int col, bool isGuardLineActive)
            {
                if (grid[row][col] == GUARD)
                {
                    return true;
                }

                if (grid[row][col] == WALL)
                {
                    return false;
                }

                if (isGuardLineActive)
                {
                    grid[row][col] = GUARDED;
                }

                return isGuardLineActive;
            }
        }

        /// <summary>
        /// 2259. Remove Digit From Number to Maximize Result
        /// </summary>
        public static string RemoveDigit(string number, char digit)
        {
            var lastIndex = -1;
            for (int i = 0; i < number.Length; i++)
            {
                var currentChar = number[i];
                if (currentChar == digit)
                {
                    lastIndex = i;

                    if (i + 1 < number.Length)
                    {
                        var nextChar = number[i + 1];
                        if (currentChar != nextChar && char.GetNumericValue(currentChar) < char.GetNumericValue(nextChar))
                        {
                            break;
                        }
                    }
                }
            }

            return number.Remove(lastIndex, 1);
        }

        /// <summary>
        /// 2265. Count Nodes Equal to Average of Subtree
        /// </summary>
        public static int AverageOfSubtree(TreeNode root)
        {
            int result = 0;

            if (root == null)
            {
                return result;
            }

            var (a, b) = GetChildAverageCount(root);

            (int, int) GetChildAverageCount(TreeNode root)
            {
                int sumLeft = 0, countLeft = 0;
                if (root.left != null)
                {
                    (sumLeft, countLeft) = GetChildAverageCount(root.left);
                }

                int sumRight = 0, countRight = 0;
                if (root.right != null)
                {
                    (sumRight, countRight) = GetChildAverageCount(root.right);
                }

                int unionSum = sumLeft + sumRight + root.val;
                int unionCount = countLeft + countRight + 1;
                if (unionSum / unionCount == root.val)
                {
                    result++;
                }

                return (unionSum, unionCount);
            }

            return result;
        }

        /// <summary>
        /// 2272. Substring With Largest Variance
        /// </summary>
        public static int LargestVariance(string s)
        {
            var n = s.Length;
            var chars = s.ToCharArray();
            var charDistinct = chars.Distinct().ToList();

            var pairs = new List<(char a, char b)>();

            while (charDistinct.Count() > 1)
            {
                var firstChar = charDistinct.ElementAt(0);

                foreach (var secondChar in charDistinct)
                {
                    if (firstChar != secondChar)
                    {
                        pairs.Add((firstChar, secondChar));
                    }
                }

                charDistinct.RemoveAt(0);
            }

            var result = 0;
            int mainResult;
            int secondResult;
            int restResult;

            foreach (var (a, b) in pairs)
            {
                mainResult = 0;
                secondResult = 0;
                restResult = chars.Where(c => c == b).Count();
                for (int i = 0; i < n; i++)
                {
                    if (a == chars[i])
                    {
                        mainResult++;
                    }
                    else if (b == chars[i])
                    {
                        secondResult++;
                        restResult--;
                    }

                    if (secondResult > 0)
                    {
                        result = Math.Max(result, mainResult - secondResult);
                    }

                    if (mainResult - secondResult < 0 && restResult > 0)
                    {
                        mainResult = 0;
                        secondResult = 0;
                    }
                }

                mainResult = 0;
                secondResult = 0;
                restResult = chars.Where(c => c == a).Count();
                for (int i = 0; i < n; i++)
                {
                    if (b == chars[i])
                    {
                        mainResult++;
                    }
                    else if (a == chars[i])
                    {
                        secondResult++;
                        restResult--;
                    }

                    if (secondResult > 0)
                    {
                        result = Math.Max(result, mainResult - secondResult);
                    }

                    if (mainResult - secondResult < 0 && restResult > 0)
                    {
                        mainResult = 0;
                        secondResult = 0;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 2275. Largest Combination With Bitwise AND Greater Than Zero
        /// </summary>
        public static int LargestCombination(int[] candidates)
        {
            var a = new int[32];
            
            foreach (var candidate in candidates)
            {
                var to2 = Convert.ToString(candidate, 2).Reverse().ToArray();

                for (int i = 0; i < to2.Length; i++)
                {
                    if (to2[i] == '1')
                    {
                        a[i] += 1;
                    }
                }
            }

            return a.Max();
        }
    }
}
