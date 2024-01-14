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

