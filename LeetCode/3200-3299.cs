using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class _3200_3299
    {
        /// <summary>
        /// 3254. Find the Power of K-Size Subarrays I
        /// </summary>
        public static int[] ResultsArray(int[] nums, int k)
        {
            if (k == 1)
            {
                return nums;
            }

            var result = new int[nums.Length - k + 1];

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] - 1 == nums[i - 1])
                {
                    if (i - k + 1 >= 0 && result[i - k + 1] != -1)
                    {
                        result[i - k + 1] = nums[i];
                    }
                }
                else
                {
                    var iter = 1;
                    while (iter < k)
                    {
                        if (i - iter < nums.Length - k + 1 && i - iter >= 0)
                        {
                            result[i - iter] = -1;
                        }
                        iter++;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 3255. Find the Power of K-Size Subarrays II
        /// </summary>
        public static int[] ResultsArray2(int[] nums, int k)
        {
            if (k == 1)
            {
                return nums;
            }

            var result = new int[nums.Length - k + 1];

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] - 1 == nums[i - 1])
                {
                    if (i - k + 1 >= 0 && result[i - k + 1] != -1)
                    {
                        result[i - k + 1] = nums[i];
                    }
                }
                else
                {
                    var iter = 1;
                    while (iter < k)
                    {
                        if (i - iter < nums.Length - k + 1 && i - iter >= 0)
                        {
                            result[i - iter] = -1;
                        }
                        iter++;

                        if (iter < k && i - iter >= 0 && i - iter < result.Length && result[i - iter] == -1)
                        {
                            break;
                        }
                    }
                }
            }

            return result;
        }
    }
}
