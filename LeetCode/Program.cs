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
            var relations = new int[13][];
            relations[0] = new int[2] { 11,10 };
            relations[1] = new int[2] { 6,3 };
            relations[2] = new int[2] { 2,5 };
            relations[3] = new int[2] { 9,2 };
            relations[4] = new int[2] { 4, 12 };
            relations[5] = new int[2] { 8, 7 };
            relations[6] = new int[2] { 9, 5 };
            relations[7] = new int[2] { 6, 2 };


            relations[8] = new int[2] { 7, 2 };
            relations[9] = new int[2] { 7, 4 };
            relations[10] = new int[2] { 9, 3 };
            relations[11] = new int[2] { 11, 1 };
            relations[12] = new int[2] { 4, 3 };



            //relations[14] = new int[2] { 1, 8 };
            //relations[15] = new int[2] { 2, 7 };
            //relations[16] = new int[2] { 8, 4 };
            //relations[17] = new int[2] { 10, 8 };
            //relations[18] = new int[2] { 12, 7};
            //relations[19] = new int[2] { 5, 4 };
            //relations[20] = new int[2] { 3, 4 };
            //relations[21] = new int[2] { 11,7 };
            //relations[22] = new int[2] { 7, 4 };
            //relations[23] = new int[2] { 13, 4};
            //relations[24] = new int[2] { 9, 8 };
            //relations[25] = new int[2] { 13, 8 };


            var result = _1400_1499.MinNumberOfSemesters(12, relations, 3);

            Console.WriteLine(result);
        }
    }
}