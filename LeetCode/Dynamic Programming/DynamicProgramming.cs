using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Dynamic_Programming
{
    public static class DynamicProgramming
    {
        /// <summary>
        /// 2466. Count Ways To Build Good Strings.
        /// Первый вариант оказался рабочим но медленным.
        /// Итоговое решение посмотрел, сделал несколько Excel, но так и не смог додуматься какая формула вшита. То что я возвращаюсь на 1 элемент когда оказывается то количество шагов, которое требовалось искомо, это удивительно.
        /// </summary>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <param name="zero"></param>
        /// <param name="one"></param>
        /// <returns></returns>
        public static int CountGoodStrings(int low, int high, int zero, int one)
        {
            int[] cache = new int[high + 1];
            cache[0] = 1;

            for (int i = 1; i <= high; i++)
            {
                if (i - zero >= 0)
                {
                    cache[i] += cache[i - zero];
                }

                if (i - one >= 0)
                {
                    cache[i] += cache[i - one];
                }

                cache[i] %= 1_000_000_007;
            }

            int result = 0;
            for (int i = low; i <= high; i++)
            {
                result = (result + cache[i]) % 1_000_000_007;
            }

            return result;
        }

        /// <summary>
        /// 70. Climbing Stairs
        /// Эта задача кроссылка с задачи 2466 на форуме. Неожиданно для себя осознал что это последовательность фибоначчи.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int ClimbStairs(int n)
        {
            var cache = new int[n + 1];
            cache[0] = 1;
            cache[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                cache[i] = cache[i - 1] + cache[i - 2];
            }

            return cache[n];
        }
    }
}
