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
            var root = new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(5)), new TreeNode(3, new TreeNode(6), new TreeNode(7)));

            var a = _1600_1699.RestoreMatrix(new int[] { 14, 9 }, new int[] { 6, 9, 8 });
            Console.WriteLine(a);
        }
    }
}