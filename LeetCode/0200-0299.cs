using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class _0200_0299
    {
        /// <summary>
        /// 202. Happy Number. Tags: Hash Table, Math, Two Pointers
        /// </summary>
        public static bool IsHappy(int n)
        {
            var unique = new HashSet<double>();
            double result = n;

            while (result != 1)
            {
                if (!unique.Add(result))
                {
                    return false; 
                }

                result = result.ToString().ToCharArray().Select(c => Math.Pow(Char.GetNumericValue(c), 2)).Sum();
            }

            return true;
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
        /// 215. Kth Largest Element in an Array
        /// </summary>
        public static int FindKthLargest(int[] nums, int k)
        {
            System.Array.Sort(nums, new Comparison<int>((i1, i2) => i1.CompareTo(i2)));

            return nums[nums.Length - k];
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
        /// 238. Product of Array Except Self
        /// </summary>
        public static int[] ProductExceptSelf(int[] nums)
        {
            var multi = 1;
            var hasZero = false;
            var result = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                var value = nums[i];
                if (value == 0)
                {
                    if (hasZero)
                    {
                        return result;
                    }

                    hasZero = true;
                }
                else
                {
                    multi *= value;
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                var value = nums[i];

                if (value == 0)
                {
                    result[i] = multi;
                }
                else if (hasZero)
                {
                    result[i] = 0;
                }
                else
                {
                    result[i] = multi / value;
                }
            }

            return result;
        }

        /// <summary>
        /// 239. Sliding Window Maximum
        /// </summary>
        public static int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (nums.Length == 0 || k == 0)
            {
                return new int[0];
            }

            int n = nums.Length;
            int[] result = new int[n - k + 1];
            int ri = 0; // Index for the result array

            LinkedList<int> deque = new LinkedList<int>();
            for (int i = 0; i < n; i++)
            {
                while (deque.Count > 0 && deque.First.Value < i - k + 1)
                {
                    deque.RemoveFirst();
                }

                while (deque.Count > 0 && nums[deque.Last.Value] < nums[i])
                {
                    deque.RemoveLast();
                }

                deque.AddLast(i);
                if (i >= k - 1)
                {
                    result[ri++] = nums[deque.First.Value];
                }
            }

            return result;
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
        /// 274. H-Index
        /// </summary>
        public static int HIndex(int[] citations)
        {
            var n = citations.Length;

            System.Array.Sort(citations);

            int h = n;
            while (h > 0)
            {
                var value = citations[n - h];

                if (value >= h)
                {
                    return h;
                }
                h--;
            }

            return 0;
        }

        /// <summary>
        /// 290. Word Pattern. Tags: Hash Table, String
        /// </summary>
        public static bool WordPattern(string pattern, string s)
        {
            var pArray = pattern.ToCharArray();
            var pLength = pArray.Length;

            var sArray = s.Split(' ').ToArray();
            var sLength = sArray.Length;

            if (pLength != sLength)
            {
                return false;
            }

            var dict = new Dictionary<char, string>();
            var unique = new HashSet<string>();

            for (int i = 0; i < pLength; i++)
            {
                var pChar = pArray[i];
                var sValue = sArray[i];

                if (!dict.TryGetValue(pChar, out string value))
                {
                    dict[pChar] = sValue;

                    if (!unique.Add(sValue))
                    {
                        return false;
                    }
                }
                else
                {
                    if (value != sValue)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
