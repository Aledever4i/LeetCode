using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class _1400_1499
    {
        /// <summary>
        /// 1456. Maximum Number of Vowels in a Substring of Given Length
        /// </summary>
        public static int MaxVowels(string s, int k)
        {
            var chars = s.ToCharArray();
            var n = chars.Length;

            var values = new int[n];
            System.Array.Fill(values, -1);

            int currentWindowValue = 0;
            var result = 0;

            for (int i = 0; i < k; i++)
            {
                currentWindowValue += (new char[] { 'a', 'e', 'i', 'o', 'u' }).Contains(chars[i]) ? 1 : 0;
            }
            result = currentWindowValue;

            for (int i = k; i < n; i++)
            {
                currentWindowValue += (new char[] { 'a', 'e', 'i', 'o', 'u'}).Contains(chars[i]) ? 1 : 0;
                currentWindowValue -= (new char[] { 'a', 'e', 'i', 'o', 'u' }).Contains(chars[i - k]) ? 1 : 0;

                result = Math.Max(result, currentWindowValue);
            }

            return result;
        }

        /// <summary>
        /// 1480. Running Sum of 1d Array. Tags: Array, Sliding Window
        /// </summary>
        public static int[] RunningSum(int[] nums)
        {
            var result = new int[nums.Length];
            var windowValue = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                windowValue += nums[i];
                result[i] = windowValue;
            }

            return result;
        }

        /// <summary>
        /// 1493. Longest Subarray of 1's After Deleting One Element
        /// </summary>
        public static int LongestSubarray(int[] nums)
        {
            int currentNumber = nums[0];
            int current = 0;
            int left = 0;
            int n = nums.Length;
            int result = 0;
            int indexPass = 0;

            bool isFirstPassed = false;
            bool hasOtherNumber = false;

            while (left < n)
            {
                if (currentNumber == 0)
                {
                    left++;
                    current = 0;

                    if (left == n)
                    {
                        break;
                    }

                    currentNumber = nums[left];
                    if (currentNumber != 0)
                    {
                        hasOtherNumber = true;
                    }
                }
                else if (currentNumber == nums[left])
                {
                    current++;
                    result = Math.Max(result, current);
                    left++;
                }
                else
                {
                    hasOtherNumber = true;

                    if (!isFirstPassed)
                    {
                        isFirstPassed = true;
                        indexPass = left;
                        left++;
                    }
                    else
                    {
                        result = Math.Max(result, current);

                        if (indexPass + 1 == left)
                        {
                            left = indexPass;
                        }
                        else
                        {
                            left = indexPass + 1;
                        }

                        currentNumber = nums[left];
                        current = 0;
                        isFirstPassed = false;
                    }
                }

            }

            if (!hasOtherNumber)
            {
                return (result - 1 <= 0) ? 0 : result - 1;
            }

            return result;
        }
    }
}
