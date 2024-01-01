using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class _2700_2799
    {
        /// <summary>
        /// 2706. Buy Two Chocolates
        /// </summary>
        public static int BuyChoco(int[] prices, int money)
        {
            System.Array.Sort(prices);

            var result = money - prices[0] - prices[1];

            if (result >= 0)
            {
                return result;
            }

            return money;
        }
    }
}
