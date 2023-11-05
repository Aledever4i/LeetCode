using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = _1500_1599.GetWinner(new int[] { 1, 11, 22, 33, 44, 55, 66, 77, 88, 99 }, 1000000000);

            Console.WriteLine(result);
        }
    }
}