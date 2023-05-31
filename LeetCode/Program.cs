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
            //var array = new int[] { 0, 0, 0, 1, 1, 2, 4, 9};
            //ListNode end = new ListNode(array[array.Length - 1], null);
            //ListNode head = null;
            //for (int i = array.Length - 2; i >= 0; i--)
            //{
            //    head = new ListNode(array[i], end);
            //    end = head;
            //}

            var list = new int[2][] { new int[]{ 0, 1 }, new int[]{ 1, 0 } };






            // [[4,1],[0,2],[1,3,4],[2,4],[0,3,2]] false
            // [[4,1],[0,2],[1,3],[2,4],[0,3]] true
            // [[1,4],[0,2],[1,4,3],[2],[0,2]] true

            //IList<IList<string>> equations = new List<IList<string>>() { 
            //    new List<string>() { "x1", "x2" },
            //    new List<string>() { "x2", "x3" },
            //    new List<string>() { "x3", "x4" },
            //    new List<string>() { "x4", "x5" },
            //};
            //double[] values = new double[] { 3.0, 4.0, 5.0, 6.0 };
            //IList<IList<string>> queries = new List<IList<string>>() { 
            //    new List<string>() { "x1", "x5" },
            //    new List<string>() { "x5", "x2" },
            //    new List<string>() { "x2", "x4" },
            //    new List<string>() { "x2", "x2" },
            //    new List<string>() { "x2", "x9" },
            //    new List<string>() { "x9", "x9" }
            //};

            var result = new MyHashSet(); //_800_899.StoneGame(array);
            result.Add(1);
            result.Add(2);
            result.Contains(2);
            result.Remove(2);
            Console.WriteLine(result.Contains(2));

            Console.WriteLine(result);
        }
    }
}
