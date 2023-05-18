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
            //var array = new int[10];
            //ListNode end = new ListNode(array[array.Length - 1], null);
            //ListNode head = null;
            //for (int i = array.Length - 2; i >= 0 ; i--)
            //{
            //    head = new ListNode(array[i], end);
            //    end = head;
            //}

            var list = new List<IList<int>>() { new List<int>() { 1, 3 }, new List<int>() { 2, 0 }, new List<int>() { 2, 3 }, new List<int>() { 1, 0 }, new List<int>() { 4, 1 }, new List<int>() { 0, 3 } };

            var result = _1500_1599.FindSmallestSetOfVertices(5, list);
        
            Console.WriteLine(result);
        }
    }
}
