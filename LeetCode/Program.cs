using LeetCode.Array;
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
            var result = new int[4][];
            result[0] = new int[2] { 1,2 };
            result[1] = new int[2] { 2,3 };
            result[2] = new int[2] { 3,4 };
            result[3] = new int[2] { 1,3 };
            var x = _0400_0499.EraseOverlapIntervals(result);
        }
    }
}
