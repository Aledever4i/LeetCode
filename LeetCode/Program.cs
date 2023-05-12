using LeetCode.Array;
using LeetCode.Matrix;
using LeetCode.String;
using System;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums1 = new int[8][];
            nums1[0] = new int[] { 21, 5 };
            nums1[1] = new int[] { 92, 3 };
            nums1[2] = new int[] { 74, 2 };
            nums1[3] = new int[] { 39, 4 };
            nums1[4] = new int[] { 58, 2 };
            nums1[5] = new int[] { 5, 5 };
            nums1[6] = new int[] { 49, 4 };
            nums1[7] = new int[] { 65, 3 };

            var result = ArraySolutions.MostPoints(nums1);
            Console.WriteLine(result);
        }
    }
}
