using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class _1700_1799
    {
        /// <summary>
        /// 1721. Swapping Nodes in a Linked List. Tags: Linked List, Two Pointers
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static ListNode SwapNodes(ListNode head, int k)
        {
            var list = new List<ListNode>();
            list.Add(head);

            ListNode endElement = head.next;

            while (endElement != null) {
                list.Add(endElement);

                endElement = endElement.next;
            }

            var endIndex = list.Count - k;

            var firstItem = list[k - 1];
            var endItem = list[endIndex];

            var temp = firstItem.val;
            firstItem.val = endItem.val;
            endItem.val = temp;

            return head;
        }

        /// <summary>
        /// 1732. Find the Highest Altitude. Tags: Array, Prefix Sum
        /// </summary>
        public static int LargestAltitude(int[] gain)
        {
            var maxAltitude = 0;
            var currentAltitude = 0;

            foreach (var step in gain)
            {
                currentAltitude += step;

                maxAltitude = Math.Max(maxAltitude, currentAltitude);
            }

            return maxAltitude;
        }

        /// <summary>
        /// 1799. Maximize Score After N Operations. Tags: Array, Math, Dynamic Programming, Backtracking, Bit Manipulation, Number Theory, Bitmask
        /// </summary>
        /// <param name="nums"></param>
        /// TODO: Изучить тему с рекурсией и битовыми масками
        public static int MaxScore(int[] nums)
        {
            Dictionary<string, int> dp = new Dictionary<string, int>();
            Dictionary<string, int> cache = new Dictionary<string, int>();
            return Util(nums, new bool[nums.Length], nums.Length / 2);

            int GCD(int num1, int num2)
            {
                int Remainder;
                while (num2 != 0)
                {
                    Remainder = num1 % num2;
                    num1 = num2;
                    num2 = Remainder;
                }
                return num1;
            }

            int Util(int[] arr, bool[] taken, int operations)

            {

                if (operations == 0)

                {

                    return 0;

                }

                string key = string.Join(",", taken.Select(b => b ? "1" : "0")) + "|" + operations;

                if (dp.ContainsKey(key))

                {

                    return dp[key];

                }

                int max = int.MinValue;

                for (int i = 0; i < arr.Length; i++)

                {

                    for (int j = i + 1; j < arr.Length; j++)

                    {

                        if (!taken[i] && !taken[j])

                        {

                            taken[i] = taken[j] = true;



                            var gcdKey = $"{arr[i]}|{arr[j]}";

                            if (!cache.TryGetValue(gcdKey, out int gcdValue))

                            {

                                gcdValue = GCD(arr[i], arr[j]);

                                cache.Add(gcdKey, gcdValue);

                            }



                            int val = (operations * gcdValue) + Util(arr, taken, operations - 1);

                            max = Math.Max(max, val);

                            taken[i] = taken[j] = false;

                        }

                    }

                }

                dp[key] = max;

                return max;

            }

        }
    }
}