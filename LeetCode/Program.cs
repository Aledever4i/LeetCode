using LeetCode.Array;
using LeetCode.Dynamic_Programming;
using LeetCode.Matrix;
using LeetCode.String;
using System;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[] { 2, 5, 3, 4, 6, 2, 2 };

            ListNode end = new ListNode(array[array.Length - 1], null);
            ListNode head = null;

            for (int i = array.Length - 2; i >= 0 ; i--)
            {
                head = new ListNode(array[i], end);
                end = head;
            }

            var result = _1_99.SwapPairs(head);
        
            Console.WriteLine(result);
        }
    }
}
