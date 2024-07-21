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
            var a = _2000_2099.GetDirections(new TreeNode(5, new TreeNode(1, new TreeNode(3)), new TreeNode(2, new TreeNode(6), new TreeNode(4))), 3, 6);
            Console.WriteLine(a);
        }
    }
}