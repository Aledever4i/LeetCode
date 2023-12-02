using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Contest
{
    public static class _372
    {
        public static int FindMinimumOperations(string s1, string s2, string s3)
        {
            var len = Math.Min(Math.Min(s1.Length, s2.Length), s3.Length);

            for (int i = 0; i < len; i++)
            {
                if (s1[i] != s2[i] || s1[i] != s3[i])
                {
                    if (i == 0)
                    {
                        return -1;
                    }
                    else
                    {
                        return s1.Length - i + s2.Length - i + s3.Length - i;
                    }
                }
            }

            return s1.Length - len + s2.Length - len + s3.Length - len;
        }


        public static long MinimumSteps(string s)
        {
            var n = s.Length;

            if (n <= 1)
            {
                return 0;
            }

            var array = s.ToArray();

            int result = 0;
            bool b = true;
            int begin = 0;
            int end = n;

            while (b)
            {
                b = false;
                begin++;
                for (int i = begin; i < end; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        char t = s[i + 1];
                        array[i + 1] = array[i];
                        array[i] = t;
                        result++;
                        b = true;
                    }
                }
                if (!b)
                {
                    break;
                }

                end--;
                for (int i = end; i > begin; i--)
                {
                    if (array[i] < array[i - 1])
                    {
                        char t = s[i + 1];
                        array[i + 1] = array[i];
                        array[i] = t;
                        result++;
                        b = true;
                    }
                }
            }

            return result;
        }
    }
}
