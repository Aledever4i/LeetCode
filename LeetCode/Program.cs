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
        static void Main(string[] args)
        {
            var ways = new int[5][] { new int[3] { 0, 1, 100 }, new int[3] { 1, 2, 100 }, new int[3] { 2, 0, 100 }, new int[3] { 1, 3, 600 }, new int[3] { 2, 3, 200 }};


            var a = _0100_0199.SortedArrayToBST(new int[] { -10, -3, 0, 5, 9 });
            // new int[4][] { new int[] { 0, 10 }, new int[] { 1, 5 }, new int[] { 2, 7 }, new int[] { 3, 4 } }
            // 
            // 
            Console.WriteLine(a);


            //a = result.ShortestPath(11, 11);

            //a = result.ShortestPath(11, 11);
            //Console.WriteLine(a);
        }
    }
}