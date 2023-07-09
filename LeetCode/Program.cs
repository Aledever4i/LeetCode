using LeetCode.Array;
using LeetCode.Dynamic_Programming;
using LeetCode.Matrix;
using LeetCode.String;
using System;
using System.Collections.Generic;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var list1 = new ListNode() { val = 1, next = new ListNode() { val = 2, next = new ListNode() { val = 4, next = null } } };
            var list2 = new ListNode() { val = 1, next = new ListNode() { val = 3, next = new ListNode() { val = 4, next = null } } };

            _1_99.MergeTwoLists(list1, list2);
        }
    }
}
