using LeetCode.Contest.Transfered;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class _3000_3099
    {
        /// <summary>
        /// 3000. Maximum Area of Longest Diagonal Rectangle
        /// </summary>
        public static int AreaOfMaxDiagonal(int[][] dimensions)
        {
            return _379.AreaOfMaxDiagonal(dimensions);
        }

        /// <summary>
        /// 3001. Minimum Moves to Capture The Queen
        /// </summary>
        public static int MinMovesToCaptureTheQueen(int a, int b, int c, int d, int e, int f)
        {
            return _379.MinMovesToCaptureTheQueen(a, b, c, d, e, f);
        }

        /// <summary>
        /// 3002. Maximum Size of a Set After Removals
        /// </summary>
        public static int MaximumSetSize(int[] nums1, int[] nums2)
        {
            return _379.MaximumSetSize(nums1, nums2);
        }

        /// <summary>
        /// 3036. Number of Subarrays That Match a Pattern II
        /// </summary>
        public static int CountMatchingSubarrays(int[] nums, int[] pattern)
        {
            int n = nums.Length;
            int p = pattern.Length;

            var val = new int[n];
            for (var i = 0; i < n - 1; i++)
            {
                if (nums[i] == nums[i + 1]) val[i] = 0;
                if (nums[i] > nums[i + 1]) val[i] = -1;
                if (nums[i] < nums[i + 1]) val[i] = 1;
            }
            val[n - 1] = -5;

            return KMPSearch(pattern, val);

            int KMPSearch(int[] pattern, int[] txt)
            {
                int pLen = pattern.Length;
                int tLen = txt.Length;
                int matchCount = 0;

                var lps = computeLPSArray(pattern);

                int tIdx = 0, pIdx = 0;
                while (tIdx < tLen)
                {
                    if (pattern[pIdx] == txt[tIdx])
                    {
                        pIdx++; tIdx++;
                    }

                    if (pIdx == pLen)
                    {
                        matchCount++;
                        pIdx = lps[pIdx - 1];
                    }
                    else if (tIdx < tLen && pattern[pIdx] != txt[tIdx])
                    {
                        if (pIdx != 0)
                        {
                            pIdx = lps[pIdx - 1];
                        }
                        else
                        {
                            tIdx++; 
                        } 
                    }
                }

                return matchCount;
            }

            int[] computeLPSArray(int[] pat)
            {
                var pLen = pat.Length;
                var lps = new int[pLen];
                lps[0] = 0;

                int len = 0;
                int i = 1;
                while (i < pLen)
                {
                    if (pat[i] == pat[len])
                    {
                        lps[i] = ++len;
                        i++;
                    }
                    else
                    {
                        if (len != 0)
                        {
                            len = lps[len - 1];
                        }
                        else
                        {
                            lps[i++] = len;
                        }
                    }
                }

                return lps;
            }
        }

        /// <summary>
        /// 3042. Count Prefix and Suffix Pairs I
        /// </summary>
        public static int CountPrefixSuffixPairs(string[] words)
        {            
            var ans = 0;
            for (int i = 0; i < words.Length; i++)
            {
                var word = words[i];

                for (int y = i + 1; y < words.Length; y++)
                {
                    var word2 = words[y];

                    if (word2.Length < word.Length)
                    {
                        continue;
                    }

                    if (word2.Substring(0, word.Length) == word && word2.Substring(word2.Length - word.Length, word.Length) == word)
                    {
                        ans++;
                    }
                }
            }

            return ans;
        }

        /// <summary>
        /// 3074. Apple Redistribution into Boxes
        /// </summary>
        public static int MinimumBoxes(int[] apple, int[] capacity)
        {
            var applesSum = apple.Sum();
            var result = 0;

            System.Array.Sort(capacity);

            for (int i = capacity.Length - 1; i >= 0; i--)
            {
                result++;

                applesSum -= capacity[i];

                if (applesSum <= 0)
                {
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// 3083. Existence of a Substring in a String and Its Reverse
        /// </summary>
        public static bool IsSubstringPresent(string s)
        {
            var hash = new HashSet<string>();

            if (s.Length == 1)
            {
                return false;
            }

            for (int i = 0; i < s.Length - 1; i++)
            {
                if (!hash.Add($"{s[i]}{s[i + 1]}"))
                {
                    return true;
                }
                if (!hash.Add($"{s[i + 1]}{s[i]}"))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 3095. Shortest Subarray With OR at Least K I
        /// </summary>
        public static int MinimumSubarrayLength1(int[] nums, int k)
        {
            int minLength = int.MaxValue;
            int windowStart = 0;
            int windowEnd = 0;
            int[] bitCounts = new int[32]; // Tracks count of set bits at each position

            // Expand window until end of array
            while (windowEnd < nums.Length)
            {
                // Add current number to window
                updateBitCounts(bitCounts, nums[windowEnd], 1);

                // Contract window while OR value is valid
                while (
                    windowStart <= windowEnd &&
                    convertBitCountsToNumber(bitCounts) >= k
                )
                {
                    // Update minimum length found so far
                    minLength = Math.Min(minLength, windowEnd - windowStart + 1);

                    // Remove leftmost number and shrink window
                    updateBitCounts(bitCounts, nums[windowStart], -1);
                    windowStart++;
                }

                windowEnd++;
            }

            return minLength == int.MaxValue ? -1 : minLength;

            void updateBitCounts(int[] bitCounts, int number, int delta) {
                for (int bitPosition = 0; bitPosition < 32; bitPosition++)
                {
                    // Check if bit is set at current position
                    if (((number >> bitPosition) & 1) != 0)
                    {
                        bitCounts[bitPosition] += delta;
                    }
                }
            }

            int convertBitCountsToNumber(int[] bitCounts)
            {
                int result = 0;
                for (int bitPosition = 0; bitPosition < 32; bitPosition++)
                {
                    if (bitCounts[bitPosition] != 0)
                    {
                        result |= 1 << bitPosition;
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// 3097. Shortest Subarray With OR at Least K II
        /// </summary>
        public static int MinimumSubarrayLength2(int[] nums, int k)
        {
            int minLength = int.MaxValue;
            int windowStart = 0;
            int windowEnd = 0;
            int[] bitCounts = new int[32]; // Tracks count of set bits at each position

            // Expand window until end of array
            while (windowEnd < nums.Length)
            {
                // Add current number to window
                updateBitCounts(bitCounts, nums[windowEnd], 1);

                // Contract window while OR value is valid
                while (
                    windowStart <= windowEnd &&
                    convertBitCountsToNumber(bitCounts) >= k
                )
                {
                    // Update minimum length found so far
                    minLength = Math.Min(minLength, windowEnd - windowStart + 1);

                    // Remove leftmost number and shrink window
                    updateBitCounts(bitCounts, nums[windowStart], -1);
                    windowStart++;
                }

                windowEnd++;
            }

            return minLength == int.MaxValue ? -1 : minLength;

            void updateBitCounts(int[] bitCounts, int number, int delta)
            {
                for (int bitPosition = 0; bitPosition < 32; bitPosition++)
                {
                    // Check if bit is set at current position
                    if (((number >> bitPosition) & 1) != 0)
                    {
                        bitCounts[bitPosition] += delta;
                    }
                }
            }

            int convertBitCountsToNumber(int[] bitCounts)
            {
                int result = 0;
                for (int bitPosition = 0; bitPosition < 32; bitPosition++)
                {
                    if (bitCounts[bitPosition] != 0)
                    {
                        result |= 1 << bitPosition;
                    }
                }
                return result;
            }
        }
    }
}
