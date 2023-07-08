using System;

namespace LeetCode
{
    public static class _2000_2099
    {
        /// <summary>
        /// 2024. Maximize the Confusion of an Exam
        /// </summary>
        public static int MaxConsecutiveAnswers(string answerKey, int k)
        {
            var array = answerKey.ToCharArray();
            var n = array.Length;

            var maxSum = 0;
            var left = 0;
            var right = 0;
            var frequency = 0;

            for (int i = 0; i < n; i++)
            {
                var value = array[i];
                right++;

                if (value == 'F')
                {
                    frequency++;

                    while (frequency > k)
                    {
                        maxSum = Math.Max(maxSum, right - left - 1);
                        value = array[left];
                        left++;
                        if (value == 'F')
                        {
                            frequency--;
                        }
                    }
                }
            }
            maxSum = Math.Max(maxSum, right - left);

            left = 0;
            right = 0;
            frequency = 0;
            for (int i = 0; i < n; i++)
            {
                var value = array[i];
                right++;

                if (value == 'T')
                {
                    frequency++;

                    while (frequency > k)
                    {
                        maxSum = Math.Max(maxSum, right - left - 1);
                        value = array[left];
                        left++;
                        if (value == 'T')
                        {
                            frequency--;
                        }
                    }
                }
            }
            maxSum = Math.Max(maxSum, right - left);

            return maxSum;
        }

        /// <summary>
        /// 2090. K Radius Subarray Averages. Tags: Array, Sliding Window
        /// </summary>
        public static int[] GetAverages(int[] nums, int k)
        {
            var n = nums.Length;
            if (2 * k >= n)
            {
                System.Array.Fill(nums, -1);
                return nums;
            }

            var decimals = new int[n];
            System.Array.Fill(decimals, -1);

            decimal currentWindowValue = 0.0M;

            for (int i = 0; i < n; i++)
            {
                currentWindowValue += nums[i];

                if (i >= 2 * k + 1)
                {
                    currentWindowValue -= nums[i - ((2 * k) + 1)];
                }

                if (i - (2 * k) >= 0)
                {
                    decimals[i - k] = Convert.ToInt32(currentWindowValue / (2 * k + 1));
                }
            }

            return decimals;
        }
    }
}
