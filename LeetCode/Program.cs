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

            var a = _2200_2300.MinimumObstacles([[0, 1, 1], [1, 1, 0], [1, 1, 0]]);

            Console.WriteLine(a);
        }
    }
}