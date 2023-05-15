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
            var array = new int[] { 1, 2, 3, 4, 5 };

            ListNode end = new ListNode(array[array.Length - 1], null);
            ListNode head = null;

            for (int i = array.Length - 2; i >= 0 ; i--)
            {
                head = new ListNode(array[i], end);
                end = head;
            }

            var result = _1700_1799.SwapNodes(head, 2);
        
            Console.WriteLine(result);
        }
    }
}
