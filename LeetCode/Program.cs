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
        //    var a = _2000_2099.MaximumBeauty(new int[][] { new int[] { 864, 954 }, new int[] { 958, 150 }, new int[] { 193, 732 }, 
        //        new int[] { 567,715 }, new int[] { 247, 919 } ,
        //        new int[] { 136,746 }, new int[] { 781, 962 }
        //    }, new int[] { 885, 1445, 1580, 1309, 205, 1788, 1214, 1404, 572, 1170, 989, 265, 153, 151, 1479, 1180, 875, 276, 1584 });

            var a = _0800_0899.ShortestSubarray([-34, 37, 51, 3, -12, -50, 51, 100, -47, 99, 34, 14, -13, 89, 31, -14, -44, 23, -38, 6], 151);

            Console.WriteLine(a);
        }
    }
}