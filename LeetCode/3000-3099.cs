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
    }
}
