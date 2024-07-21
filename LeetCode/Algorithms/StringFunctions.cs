using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Algorithms
{
    public static class StringFunctions
    {
        public static (string, string) LowestCommonAncestorRemove(string a, string b)
        {
            var commonIndex = 0;
            for (; commonIndex < Math.Min(a.Length, b.Length); commonIndex++)
            {
                if (a[commonIndex] != b[commonIndex])
                {
                    break;
                }
            }

            return (a.Remove(0, commonIndex), b.Remove(0, commonIndex));
        }

        public static string LowestCommonAncestor(string a, string b)
        {
            var commonIndex = 0;
            for (; commonIndex < Math.Min(a.Length, b.Length); commonIndex++)
            {
                if (a[commonIndex] != b[commonIndex])
                {
                    break;
                }
            }

            return a.Substring(0, commonIndex);
        }
    }
}
