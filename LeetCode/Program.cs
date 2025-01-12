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
            var a = _2100_2199.CanBeValid("())()))()(()(((())(()()))))((((()())(())", "1011101100010001001011000000110010100101");

            Console.WriteLine(a);
        }
    }
}