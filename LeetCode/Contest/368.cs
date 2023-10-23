using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Contest
{
    public static class _368
    {
        public static int MinimumSum(int[] nums)
        {
            var n = nums.Length;
            var dpForward = new int[nums.Length];
            var dpBack = new int[nums.Length];

            dpForward[0] = nums[0];
            dpBack[n - 1] = nums[n - 1];

            for (int i = 1; i < nums.Length - 2; i++)
            {
                var v = nums[i];
                dpForward[i] = Math.Min(dpForward[i - 1], v);
            }

            for (int i = n - 2; i >= 2; i--)
            {
                var v = nums[i];
                dpBack[i] = Math.Min(dpBack[i + 1], v);
            }

            var result = int.MaxValue;
            for (int i = 1; i < n - 1; i++)
            {
                if (nums[i] > dpForward[i - 1] && nums[i] > dpBack[i + 1])
                {
                    result = Math.Min(result, dpForward[i - 1] + nums[i] + dpBack[i + 1]);
                }

            }
            
            return (result == int.MaxValue) ? -1 : result;
        }

        public static int MinGroupsForValidAssignment(int[] nums)
        {
            var dict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var v = nums[i];

                if (!dict.TryAdd(v, 1))
                {
                    dict[v]++;
                }
            }

            int minGroup = dict.Values.Min();

            for (int i = minGroup; i >= 1; i--)
            {
                var f = find(i, dict);

                if (f > 0)
                {
                    return f;
                }
            }
            return dict.Keys.Count();

            int find(int bucket, Dictionary<int, int> dict)
            {
                int count = 0;

                foreach (var value in dict.Values)
                {
                    if (value % (bucket + 1) == 0)
                    {
                        count += value / (bucket + 1);
                    }
                    else if (value / (bucket + 1) + value % (bucket + 1) >= bucket)
                    {
                        count += value / (bucket + 1) + 1;
                    }
                    else
                    {
                        return 0;
                    }
                }

                return count;
            }
        }
    }
}
