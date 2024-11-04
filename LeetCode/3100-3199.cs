using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class _3100_3199
    {
        /// <summary>
        /// 3163. String Compression III
        /// </summary>
        public string CompressedString(string word)
        {
            var builder = new StringBuilder();
            var currentNumber = 0;
            var currentChar = '-';

            foreach (char c in word)
            {
                if (c == currentChar && currentNumber < 9)
                {
                    currentNumber++;
                    continue;
                }

                builder.Append(currentNumber);
                builder.Append(currentChar);

                currentNumber = 1;
                currentChar = c;
            }

            builder.Append(currentNumber);
            builder.Append(currentChar);

            return builder.ToString().Remove(0, 2);
        }
    }
}
