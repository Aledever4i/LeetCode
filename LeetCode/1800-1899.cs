using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
