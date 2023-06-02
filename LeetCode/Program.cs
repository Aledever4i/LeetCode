﻿using LeetCode.Array;
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
            //var array = new intnew int[] {} { 0, 0, 0, 1, 1, 2, 4, 9};
            //ListNode end = new ListNode(arraynew int[] {array.Length - 1}, null);
            //ListNode head = null;
            //for (int i = array.Length - 2; i >= 0; i--)
            //{
            //    head = new ListNode(arraynew int[] {i}, end);
            //    end = head;
            //}

            // new int[] {new int[] {4,1},new int[] {0,2},new int[] {1,3,4},new int[] {2,4},new int[] {0,3,2}} false
            // new int[] {new int[] {4,1},new int[] {0,2},new int[] {1,3},new int[] {2,4},new int[] {0,3}} true
            // new int[] {new int[] {1,4},new int[] {0,2},new int[] {1,4,3},new int[] {2},new int[] {0,2}} true

            //IList<IList<string>> equations = new List<IList<string>>() { 
            //    new List<string>() { "x1", "x2" },
            //    new List<string>() { "x2", "x3" },
            //    new List<string>() { "x3", "x4" },
            //    new List<string>() { "x4", "x5" },
            //};
            //doublenew int[] {} values = new doublenew int[] {} { 3.0, 4.0, 5.0, 6.0 };
            //IList<IList<string>> queries = new List<IList<string>>() { 
            //    new List<string>() { "x1", "x5" },
            //    new List<string>() { "x5", "x2" },
            //    new List<string>() { "x2", "x4" },
            //    new List<string>() { "x2", "x2" },
            //    new List<string>() { "x2", "x9" },
            //    new List<string>() { "x9", "x9" }
            //};


            var list = new int[5][] {
                new int[] { 1, 2, 3 },
                new int[] { 2, 3, 1},
                new int[] { 3, 4, 2},
                new int[] { 4, 5, 3},
                new int[] { 5, 6, 4},
            };
            var result = _2100_2199.MaximumDetonation(list);


            Console.WriteLine(result);
        }
    }
}
