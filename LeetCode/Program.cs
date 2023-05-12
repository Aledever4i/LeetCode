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
            var nums1 = new[] { 1, 2, 4, 1, 4, 4, 3, 5, 5, 1, 4, 4, 4, 1, 4, 3, 4, 2, 4, 2 };
            var nums2 = new[] { 2, 4, 1, 1, 3, 5, 2, 1, 5, 1, 2, 3, 3, 2, 1, 4, 1, 2, 5, 5 };

            var result = ArraySolutions.MaxUncrossedLines(nums1, nums2);
            Console.WriteLine(result);
        }
    }
}
