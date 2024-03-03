using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Contest
{
    public static class _387
    {
        public static int[] ResultArray(int[] nums)
        {
            var stack1 = new Stack<int>();
            stack1.Push(nums[0]);
            var stack2 = new Stack<int>();
            stack2.Push(nums[1]);

            for (int i = 2; i < nums.Length; i++)
            {
                var value = nums[i];

                if (stack1.Peek() > stack2.Peek())
                {
                    stack1.Push(value);
                }
                else
                {
                    stack2.Push(value);
                }
            }

            return stack1.Reverse().Concat(stack2.Reverse()).ToArray();
        }

        public static int CountSubmatrices(int[][] grid, int k)
        {
            var result = 0;
            if (grid[0][0] > k)
            {
                return result;
            }

            var dp = new int[grid.Length][];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[grid[i].Length];
                Array.Fill<int>(dp[i], -1);
            }

            for (int y = 0; y < grid.Length; y++)
            {
                for (int i = 0; i < dp[0].Length; i++)
                {
                    dp[y][i] = grid[y][i] + ((i > 0) ? dp[y][i - 1] : 0);
                }
            }

            for (int i = 0; i < dp.Length; i++)
            {
                for (int y = dp[i].Length - 1; y >= 0; y--)
                {
                    dp[i][y] = grid[i][y] + ((i > 0) ? dp[i - 1][y] : 0) + ((y > 0) ? dp[i][y - 1] : 0);

                    if (dp[i][y] <= k)
                    {
                        result++;
                    }
                }
            }

            return result;
        }

        public static int MinimumOperationsToWriteY(int[][] grid)
        {


            return 0;
        }

        public static int[] ResultArray2(int[] nums)
        {
            return new int[] { };
        }
    }
}
