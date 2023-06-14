using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class _200_299
    {
        /// <summary>
        /// 258. Add Digits
        /// </summary>
        public static int AddDigits(int num)
        {
            var result = num;
            while (result > 9)
            {
                result = Convert.ToInt32(result.ToString().ToArray().Sum(x => Char.GetNumericValue(x)));
            }
            return result;

            //if (num == 0) return 0;
            //if (num % 9 == 0) return 9;
            //return num % 9;
        }

        public static bool IsIsomorphic(string s, string t)
        {
            return true;
        }
    }
}
