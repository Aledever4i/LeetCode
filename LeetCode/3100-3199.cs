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
        /// 3105. Longest Strictly Increasing or Strictly Decreasing Subarray
        /// </summary>
        public static int LongestMonotonicSubarray(int[] nums)
        {
            var result = 0;
            var minLen = 1;
            var maxLen = 1;

            for (var i = 1; i < nums.Length; i++)
            {
                var prev = nums[i - 1];
                var cur = nums[i];

                if (prev > cur)
                {
                    minLen++;
                }
                else
                {
                    result = Math.Max(result, minLen);
                    minLen = 1;
                }


                if (cur > prev)
                {
                    maxLen++;
                }
                else
                {
                    result = Math.Max(result, maxLen);
                    maxLen = 1;
                }
            }

            result = Math.Max(result, minLen);
            result = Math.Max(result, maxLen);

            return result;
        }

        /// <summary>
        /// 3133. Minimum Array End
        /// </summary>
        public static long MinEnd(int n, int x)
        {
            var xString = Convert.ToString(x, 2).Reverse().ToList();
            var y = Convert.ToString(n - 1, 2).Reverse().ToArray();
            var yLength = y.Count();

            var yIndex = 0;
            for (int i = 0; i < xString.Count() && yIndex < yLength; i++)
            {
                if (xString[i] == '0')
                {
                    xString[i] = y[yIndex];
                    yIndex++;
                }
            }

            if (yIndex < yLength)
            {
                xString.AddRange(y[yIndex..]);
            }

            xString.Reverse();
            var answer = string.Join("", xString).TrimStart('0');
            return Convert.ToInt64(answer, 2);
        }

        /// <summary>
        /// 3151. Special Array I
        /// </summary>
        public static bool IsArraySpecial(int[] nums)
        {
            var prev = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                if ((nums[i] - prev) % 2 == 0)
                {
                    return false;
                }

                prev = nums[i];
            }

            return true;
        }

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
