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

        public static bool IsIsomorphic(string s, string t)
        {
            return true;
        }
    }
}
