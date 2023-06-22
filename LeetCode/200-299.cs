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
        /// 209. Minimum Size Subarray Sum. Tags: 
        /// </summary>
        public static int MinSubArrayLen(int target, int[] nums)
        {
            var subArrayLength = nums.Length + 1;
            var currentSum = 0;

            int left = 0;
            int right = 0;

            while (right < nums.Length)
            {
                currentSum += nums[right];

                while (currentSum >= target)
                {
                    subArrayLength = Math.Min(subArrayLength, right - left + 1);

                    currentSum -= nums[left];
                    left++;
                }

                right++;
            }

            return subArrayLength == nums.Length + 1 ? 0 : subArrayLength;
        }

        /// <summary>
        /// 219. Contains Duplicate II. Tags: Array, Hash Table, Sliding Window
        /// </summary>
        public static bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            var dict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var value = nums[i];

                if (!dict.TryGetValue(value, out int index))
                {
                    dict.Add(value, i);
                }
                else
                {
                    if (i - index <= k)
                    {
                        return true;
                    }
                    else
                    {
                        dict[value] = i;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 220. Contains Duplicate III. Tags: Array, Sliding Window, Sorting, Bucket Sort, Ordered Set
        /// </summary>
        public static bool ContainsNearbyAlmostDuplicate(int[] nums, int indexDiff, int valueDiff)
        {


            return true;
        }

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

        /// <summary>
        /// 205. Isomorphic Strings. Tags: Hash Table, String
        /// </summary>
        public static bool IsIsomorphic(string s, string t)
        {
            var dict = new Dictionary<char, char>();
            var hash = new HashSet<char>();

            for (int i = 0; i < s.Length; i++)
            {
                var sChar = s[i];
                var tChar = t[i];

                if (!dict.TryGetValue(sChar, out char dictChar))
                {
                    dict[sChar] = tChar;
                    if (!hash.Add(tChar))
                    {
                        return false;
                    }
                }
                else
                {
                    if (dictChar != tChar)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
