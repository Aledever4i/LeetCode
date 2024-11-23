using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /// <summary>
    /// 1845. Seat Reservation Manager
    /// </summary>
    public class SeatManager
    {
        private readonly PriorityQueue<int, int> queue;
        private readonly int tableCount;

        public SeatManager(int n)
        {
            tableCount = n;
            queue = new PriorityQueue<int, int>(tableCount);

            for (int i = 1; i <= n; i++)
            {
                queue.Enqueue(i, i);
            }
        }

        public int Reserve()
        {
            return queue.Dequeue();
        }

        public void Unreserve(int seatNumber)
        {
            queue.Enqueue(seatNumber, seatNumber);
        }
    }

    public class _1800_1899
    {
        /// <summary>
        /// 1802. Maximum Value at a Given Index in a Bounded Array. Tags: Binary Search, Greedy
        /// </summary>
        public static int MaxValue(int n, int index, int maxSum)
        {
            return 0;
        }

        /// <summary>
        /// 1813. Sentence Similarity III
        /// </summary>
        public bool AreSentencesSimilar(string sentence1, string sentence2)
        {
            LinkedList<string> deque1 = new(sentence1.Split(" "));
            LinkedList<string> deque2 = new(sentence2.Split(" "));

            while (
                deque1.Count > 0
                && deque2.Count > 0
                && deque1.First().Equals(deque2.First())
            )
            {
                deque1.RemoveFirst();
                deque2.RemoveFirst();
            }

            while (
                deque1.Count > 0
                && deque2.Count > 0
                && deque1.Last().Equals(deque2.Last())
            )
            {
                deque1.RemoveLast();
                deque2.RemoveLast();
            }

            return deque1.Count == 0 || deque2.Count == 0;
        }

        /// <summary>
        /// 1823. Find the Winner of the Circular Game
        /// </summary>
        public static int FindTheWinner(int n, int k)
        {
            var link = new LinkedList<int>();
            for (int i = 1; i < n + 1; i++)
            {
                link.AddLast(i);
            }
            var current = link.First;
            var next = link.First;
            

            while (link.Count != 1)
            {
                int iter = k - 1;
                while (iter > 0)
                {
                    current = current.Next;
                    current ??= link.First;
                    iter--;
                }

                next = current.Next;
                next ??= link.First;
                link.Remove(current);
                current = next;
            }

            return link.First();
        }

        /// <summary>
        /// 1829. Maximum XOR for Each Query
        /// </summary>
        public static int[] GetMaximumXor(int[] nums, int maximumBit)
        {
            var number = Convert.ToInt32(Math.Pow(2, maximumBit) - 1);
            var length = nums.Length;

            var result = new int[length];

            var temp = new int[length];
            temp[0] = nums[0];

            for (int i = 1; i < length; i++)
            {
                temp[i] = temp[i - 1] ^ nums[i];
            }

            for (int i = 0; i < length; i++)
            {
                result[i] = number ^ temp[i];
            }

            return result.Reverse().ToArray();
        }

        /// <summary>
        /// 1861. Rotating the Box
        /// </summary>
        public static char[][] RotateTheBox(char[][] box)
        {
            var n = box.Length;
            var m = box[0].Length;

            var result = new char[m][];
            for (int i = 0; i < m; i++)
            {
                result[i] = new char[n];
                Array.Fill(result[i], '.');
            }

            for (int i = 0; i < n; i++)
            {
                var row = box[i];
                var platform = m;

                for (int j = m - 1; j >= 0; j--)
                {
                    var value = row[j];

                    if (value == '#')
                    {
                        result[--platform][n - i - 1] = value;
                    }
                    else if (value == '*')
                    {
                        result[j][n - i - 1] = value;
                        platform = j;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 1877. Minimize Maximum Pair Sum in Array
        /// </summary>
        public int MinPairSum(int[] nums)
        {
            Array.Sort(nums);
            var result = 0;

            for (int i = 0; i < nums.Length / 2; i++)
            {
                result = Math.Max(nums[i] + nums[nums.Length - 1 - i], result);
            }

            return result;
        }

        /// <summary>
        /// 1894. Find the Student that Will Replace the Chalk
        /// </summary>
        public static int ChalkReplacer(int[] chalk, int k)
        {
            var fullIter = chalk.Sum(n => (decimal)n);

            if (k >= fullIter)
            {
                int multi = k / (int)fullIter;
                k -= multi * (int)fullIter;
            }

            for (int i = 0; i < chalk.Length; i++)
            {
                if (chalk[i] > k)
                {
                    return i;
                }
                
                k -= chalk[i];
            }

            return 0;
        }
    }
}
