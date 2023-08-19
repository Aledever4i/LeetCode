using LeetCode.Array;
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
            var x = new ListNode()
            {
                val = 1,
                next = new ListNode()
                {
                    val = 4,
                    next = new ListNode()
                    {
                        val = 3,
                        next = new ListNode()
                        {
                            val = 2,
                            next = new ListNode()
                            {
                                val = 5,
                                next = new ListNode()
                                {
                                    val = 2,
                                    next = null
                                }
                            }
                        }
                    }
                }
            };

            var y = _0001_0099.MaxArea(new int[] { 2, 3, 4, 5, 18, 17, 6 });
        }
    }
}
