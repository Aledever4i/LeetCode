using LeetCode.Contest;
using LeetCode.PinaevSon;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace LeetCode
{
    class Program
    {
        // Test
        static void Main(string[] args)
        {
            var a = _2100_2199.CreateBinaryTree(new int[][] { new int[] { 20, 15, 1 }, new int[] { 20, 17, 0 }, new int[] { 50, 20, 1 }, new int[] { 50, 80, 0 }, new int[] { 80, 19, 1 } });
            Console.WriteLine(a);
        }
    }
}