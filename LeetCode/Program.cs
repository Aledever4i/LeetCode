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
            var a = _1100_1199.MinHeightShelves(
                new int[][] { 
                    new int[] { 1, 1 },
                    new int[] { 2, 3 },
                    new int[] { 2, 3 },
                    new int[] { 1, 1 },
                    new int[] { 1, 1 },
                    new int[] { 1, 1 },
                    new int[] { 1, 2 }
                },
                4
            );
            Console.WriteLine(a);
        }
    }
}