using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.String
{
    public static class StringSolutions
    {
        // 58. Length of Last Word
        public static int LengthOfLastWord(string s)
        {
            return (s.Trim().Split().Reverse().First()).Length;
        }

    }
}
