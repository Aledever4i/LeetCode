using LeetCode.Array;
using LeetCode.Dynamic_Programming;
using LeetCode.Matrix;
using LeetCode.String;
using System;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = DynamicProgramming.CountGoodStrings(9, 9, 4, 2);
        
            Console.WriteLine(result);
        }
    }
}
