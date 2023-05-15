using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class _1_99
    {
        /// <summary>
        /// 67. Add Binary. Tags: Math, String, Bit Manipulation, Simulation
        /// Задача простая но нужная
        /// </summary>
        public static string AddBinary(string a, string b)
        {
            var charA = a.Reverse().Select(c => Convert.ToInt32(c)).ToArray();
            var charB = b.Reverse().Select(c => Convert.ToInt32(c)).ToArray();

            var aLength = charA.Length;
            var bLength = charB.Length;

            var stringBuilder = new StringBuilder();
            var bonus = 0;

            for (int i = 0; i < Math.Max(aLength, bLength); i++)
            {
                var charByteA = 48;
                var charByteB = 48;

                if (i < aLength)
                {
                    charByteA = charA[i];
                }

                if (i < bLength)
                {
                    charByteB = charB[i];
                }

                if (charByteA == 48 && charByteB == 48 && bonus == 0)
                {
                    stringBuilder.Append(0);
                }
                else if (charByteA == 49 && charByteB == 49 && bonus == 0)
                {
                    stringBuilder.Append(0);
                    bonus = 1;
                }
                else if (bonus == 0 && charByteA != charByteB)
                {
                    stringBuilder.Append(1);
                }
                else if (bonus == 1 && charByteA == 48 && charByteB == 48)
                {
                    stringBuilder.Append(1);
                    bonus = 0;
                }
                else if (bonus == 1 && charByteA == 49 && charByteB == 49)
                {
                    stringBuilder.Append(1);
                    bonus = 1;
                }
                else if (bonus == 1 && charByteA != charByteB)
                {
                    stringBuilder.Append(0);
                    bonus = 1;
                }
            }

            if (bonus == 1)
            {
                stringBuilder.Append(1);
            }

            return string.Join("", stringBuilder.ToString().Reverse());
        }
    }
}
