using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace LeetCode
{
    public static class _2500_2599
    {
        public class MaxScoreElement
        {
            public MaxScoreElement(int score, int factor)
            {
                this.score = score;
                this.factor = factor;
            }

            public int score;

            public int factor;
        }

        /// <summary>
        /// 2542. Maximum Subsequence Score. Tags: Array, Greedy, Sorting, Heap(Priority Queue)
        /// </summary>
        public static long MaxScore(int[] nums1, int[] nums2, int k)
        {
            int n = nums1.Length;
            MaxScoreElement[] nums = new MaxScoreElement[n];

            for (int i = 0; i < n; i++)
            {
                nums[i] = new MaxScoreElement(nums1[i], nums2[i]);
            }

            System.Array.Sort(nums, (a, b) => {
                return b.factor - a.factor;
            });

            PriorityQueue<int, int> queue = new();
            long res = 0, sum = 0;

            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(nums[i].score, nums[i].score);
                sum += nums[i].score;

                if (queue.Count > k) sum -= queue.Dequeue();
                if (queue.Count == k) res = Math.Max(res, sum * nums[i].factor);
            }

            return res;
        }

        /// <summary>
        /// 2551. Put Marbles in Bags
        /// </summary>
        public static long PutMarbles(int[] weights, int k)
        {
            var n = weights.Length;
            if (k >= n)
            {
                return 0;
            }

            var pair = new long[n - 1];
            for (int i = 0; i < n - 1; i++)
            {
                pair[i] = weights[i] + weights[i + 1];
            }

            return pair.OrderByDescending(v => v).Take(k - 1).Sum() - pair.OrderBy(v => v).Take(k - 1).Sum();
        }
    }
}
