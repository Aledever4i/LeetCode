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
            var a = _387.CountSubmatrices(new int[2][] { new int[] { 9, 8, 7, 10 }, new int[] { 7, 9, 3, 7 }}, 14);
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