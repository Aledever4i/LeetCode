using LeetCode.Array;
using LeetCode.Dynamic_Programming;
using LeetCode.Matrix;
using LeetCode.String;
using System;
using System.Collections.Generic;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //var req_skills = new string[3] { "java", "nodejs", "reactjs" };
            //var people = new List<IList<string>>() { new List<string> { "java" }, new List<string> { "nodejs" }, new List<string> { "nodejs", "reactjs" } };
            //Console.WriteLine(_1100_1199.SmallestSufficientTeam(req_skills, people));

            var l1 = new ListNode(3, new ListNode(9, new ListNode(9, new ListNode(9))));
            var l2 = new ListNode(7);
            _400_499.AddTwoNumbers(l1, l2);
        }
    }
}
