using LeetCode.Array;
using LeetCode.Contest;
using LeetCode.Dynamic_Programming;
using LeetCode.Matrix;
using LeetCode.String;
using System;
using System.Collections.Generic;
using static LeetCode._0100_0199;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var m = new int[1][] {
                new int[3] { 12345, 1, 2 },
            };

            var result = _1200_1299.NumWays(27, 7);

            Console.WriteLine(result);
        }
    }
}