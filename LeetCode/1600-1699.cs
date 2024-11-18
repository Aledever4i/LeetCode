using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{

    /// <summary>
    /// 1603. Design Parking System
    /// </summary>
    public class ParkingSystem
    {
        private Dictionary<int, int> map = new Dictionary<int, int>();

        public ParkingSystem(int big, int medium, int small)
        {
            map[1] = big;
            map[2] = medium;
            map[3] = small;
        }

        public bool AddCar(int carType)
        {
            if (map[carType] > 0) {
                map[carType]--;
                return true;
            }

            return false;
        }
    }

    public static class _1600_1699
    {
        /// <summary>
        /// 1605. Find Valid Matrix Given Row and Column Sums
        /// </summary>
        public static int[][] RestoreMatrix(int[] rowSum, int[] colSum)
        {
            var result = new int[rowSum.Length][];
            for (int i = 0; i < rowSum.Length; i++)
            {
                result[i] = new int[colSum.Length];
            }

            for (int i = 0; i < rowSum.Length; i++)
            {
                for (int y = 0; y < colSum.Length; y++)
                {
                    if (rowSum[i] > 0)
                    {
                        if (rowSum[i] > colSum[y])
                        {
                            result[i][y] = colSum[y];
                            rowSum[i] -= colSum[y];
                            colSum[y] = 0;
                        }
                        else
                        {
                            result[i][y] = rowSum[i];
                            colSum[y] -= rowSum[i];
                            rowSum[i] = 0;
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 1609. Even Odd Tree
        /// </summary>
        public static bool IsEvenOddTree(TreeNode root)
        {
            var dict = new Dictionary<int, List<int>>();

            Analyse(root, 1);

            foreach (var key in dict.Keys)
            {
                var values = dict[key].ToArray();
                var isOdd = key % 2 == 0;
                var e = values.GetEnumerator();
                e.MoveNext();
                var previous = (int)e.Current;
                if (isOdd && previous % 2 == 1)
                {
                    return false;
                }
                else if (!isOdd && previous % 2 == 0)
                {
                    return false;
                }

                while (e.MoveNext())
                {
                    if (!isOdd && (((int)e.Current).CompareTo(previous) <= 0 || (int)e.Current % 2 == 0))
                    {
                        return false;
                    }
                    else if (isOdd && (((int)e.Current).CompareTo(previous) >= 0 || (int)e.Current % 2 == 1))
                    {
                        return false;
                    }

                    previous = (int)e.Current;
                }
            }

            return true;

            void Analyse(TreeNode root, int level)
            {
                if (root == null) { return; }
                Analyse(root.left, level + 1);
                Analyse(root.right, level + 1);
                if (dict.TryGetValue(level, out var values)) { values.Add(root.val); }
                else { dict.Add(level, new List<int>() { root.val }); }
            }
        }

        /// <summary>
        /// 1614. Maximum Nesting Depth of the Parentheses
        /// </summary>
        public static int MaxDepth(string s)
        {
            var result = 0;
            var open = 0;

            foreach (var c in s)
            {
                if (c == '(')
                {
                    open++;

                    result = Math.Max(result, open);
                }
                else if (c == ')')
                {
                    open--;

                    result = Math.Max(result, open);
                }
            }

            return result;
        }

        /// <summary>
        /// 1624. Largest Substring Between Two Equal Characters
        /// </summary>
        public static int MaxLengthBetweenEqualCharacters(string s)
        {
            var dict = new Dictionary<char, List<int>>();

            for (int i = 0; i < s.Length; i++)
            {
                var c = s[i];

                if (!dict.TryAdd(c, new List<int>() { i })) {
                    dict[c].Add(i);
                }
            }

            var result = -1;
            foreach (var v in dict.Where(d => d.Value.Count > 1))
            {
                result = Math.Max(result, v.Value.Max() - v.Value.Min() - 1);
            }

            return result;
        }

        /// <summary>
        /// 1636. Sort Array by Increasing Frequency
        /// </summary>
        public static int[] FrequencySort(int[] nums)
        {
            return nums.GroupBy(n => n).OrderBy(n => n.Count()).ThenByDescending(n => n.Key).SelectMany(n => Enumerable.Repeat(n.Key, n.Count())).ToArray();
        }

        /// <summary>
        /// 1642. Furthest Building You Can Reach
        /// </summary>
        public static int FurthestBuilding(int[] heights, int bricks, int ladders)
        {
            var ladderQueue = new PriorityQueue<int, int>();
            int n = heights.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int diff = heights[i + 1] - heights[i];

                if (diff > 0)
                {
                    ladderQueue.Enqueue(diff, diff);
                }

                if (ladderQueue.Count > ladders)
                {
                    bricks -= ladderQueue.Dequeue();
                }

                if (bricks < 0)
                {
                    return i;
                }
            }

            return n - 1;
        }

        /// <summary>
        /// 1642. Furthest Building You Can Reach
        /// </summary>
        public static int FurthestBuildingDP(int[] heights, int bricks, int ladders)
        {
            var n = heights.Length;
            var dp = new int[bricks + 1][];
            for (int i = 0; i < bricks + 1; i++)
            {
                dp[i] = new int[ladders + 1];
                Array.Fill<int>(dp[i], -1);
            }

            return Calculate(heights, 0, bricks, ladders);

            int Calculate(int[] heights, int currentPosition, int bricks, int ladders)
            {
                if (currentPosition == n - 1)
                {
                    return currentPosition;
                }

                if (dp[bricks][ladders] != -1)
                {
                    return dp[bricks][ladders];
                }

                var current = heights[currentPosition];

                var nextPostiton = currentPosition;
                var next = current;

                while (current >= next)
                {
                    nextPostiton = nextPostiton + 1;

                    if (nextPostiton == n - 1)
                    {
                        return nextPostiton;
                    }

                    next = heights[nextPostiton];
                }

                if (current >= next)
                {
                    return dp[bricks][ladders] = Calculate(heights, nextPostiton, bricks, ladders);
                }
                else
                {
                    var result = currentPosition;
                    var h = next - current;

                    if (bricks >= h)
                    {
                        result = Calculate(heights, nextPostiton, bricks - h, ladders);
                    }

                    if (ladders > 0)
                    {
                        result = Math.Max(result, Calculate(heights, nextPostiton, bricks, ladders - 1));
                    }


                    return dp[bricks][ladders] = result;
                }
            }
        }

        /// <summary>
        /// 1652. Defuse the Bomb
        /// </summary>
        public static int[] Decrypt(int[] code, int k)
        {
            var n = code.Length;
            var result = new int[n];
            var prefixSum = 0;

            if (k == 0)
            {
                Array.Fill(result, 0);
                return result;
            }

            if (k > 0)
            {
                prefixSum = code[..k].Sum();
                for (int i = 0; i < n; i++)
                {
                    var index = (i + k) % n;
                    prefixSum = prefixSum + code[index] - code[i];
                    result[i] = prefixSum;
                }

                return result;
            }

            prefixSum = code[(n + k)..].Sum();
            result[0] = prefixSum;

            for (int i = 1; i < n; i++)
            {
                var index =  (n + k + i - 1) % n;
                prefixSum = prefixSum - code[index] + code[i - 1];
                result[i] = prefixSum;
            }

            return result;
        }

        /// <summary>
        /// 1657. Determine if Two Strings Are Close
        /// </summary>
        public static bool CloseStrings(string word1, string word2)
        {
            if (word1.Length != word2.Length)
            {
                return false;
            }

            var word1charDict = word1.GroupBy(c => c).ToDictionary(c => c.Key, c => c.Count());
            var word2charDict = word2.GroupBy(c => c).ToDictionary(c => c.Key, c => c.Count());

            foreach (var v in word1charDict)
            {
                if (!word2charDict.ContainsKey(v.Key))
                {
                    return false;
                }
            }

            var word1CharCountDict = word1charDict.GroupBy(v => v.Value).ToDictionary(c => c.Key, c => c.Count());
            var word2CharCountDict = word2charDict.GroupBy(v => v.Value).ToDictionary(c => c.Key, c => c.Count());

            foreach (var x in word1CharCountDict)
            {
                if (!word2CharCountDict.TryGetValue(x.Key, out int value))
                {
                    return false;
                }
                else if (x.Value != value)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 1658. Minimum Operations to Reduce X to Zero
        /// </summary>
        public static int MinOperations(int[] nums, int x)
        {
            var n = nums.Length;
            var leftStack = new Stack<int>();
            var tempSum = 0;
            var leftIter = 0;
            var result = -1;

            while (tempSum < x && leftIter < n)
            {
                var leftValue = nums[leftIter];
                tempSum += leftValue;
                leftStack.Push(leftValue);
                leftIter++;
            }

            if (leftIter == n)
            {
                return -1;
            }

            if (tempSum == 0)
            {
                result = leftIter;
            }

            for (int i = 0; i < leftIter; i++)
            {
                tempSum -= leftStack.Pop();
                tempSum += nums[n - 1 - i];

                if (tempSum == 0)
                {
                    result = Math.Min(result, leftIter );
                }
            }

            return result;
        }

        /// <summary>
        /// 1662. Check If Two String Arrays are Equivalent
        /// </summary>
        public static bool ArrayStringsAreEqual(string[] word1, string[] word2)
        {
            string word1String = string.Join("", word1);
            string word2String = string.Join("", word2);

            return word1String.Equals(word2String);
        }

        /// <summary>
        /// 1685. Sum of Absolute Differences in a Sorted Array
        /// </summary>
        public static int[] GetSumAbsoluteDifferences(int[] nums)
        {
            var n = nums.Length;

            var result = new int[n];
            Array.Fill(result, 0);

            int prefixSum = 0;
            var sum = nums.Sum();

            for (int i = 0; i < n; i++)
            {
                var v = nums[i];
                int rightSum = sum - prefixSum - v;

                int rightCount = n - 1 - i;

                int leftTotal = i * v - prefixSum;
                int rightTotal = rightSum - rightCount * v;

                result[i] = leftTotal + rightTotal;
                prefixSum += v;
            }

            return result;
        }
    }
}

