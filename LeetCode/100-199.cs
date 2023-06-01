using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class _100_199
    {
        /// <summary>
        /// 118. Pascal's Triangle. Tags: Array, Dynamic Programming
        /// </summary>
        public static IList<IList<int>> Generate(int numRows)
        {
            var result = new List<IList<int>>();

            result.Add(new List<int>() { 1 });

            if (numRows == 1)
            {
                return result;
            }

            result.Add(new List<int>() { 1, 1 });

            if (numRows == 2)
            {
                return result;
            }

            for (int i = 2; i < numRows; i++)
            {
                var values = new List<int>();

                for (int j = 0; j < i + 1; j++)
                {
                    if (j == 0 || j == i)
                    {
                        values.Add(1);
                    }
                    else
                    {
                        values.Add(result[i - 1][j - 1] + result[i - 1][j]);
                    }
                }

                result.Add(values);
            }

            return result;
        }

        /// <summary>
        /// 119. Pascal's Triangle II. Tags: Array, Dynamic Programming
        /// </summary>
        public static IList<int> GenerateRow(int rowIndex)
        {
            var result = new List<IList<int>>();

            result.Add(new List<int>() { 1 });

            if (rowIndex == 0)
            {
                return result.ElementAt(rowIndex);
            }

            result.Add(new List<int>() { 1, 1 });

            if (rowIndex == 1)
            {
                return result.ElementAt(rowIndex);
            }

            for (int i = 2; i < rowIndex + 1; i++)
            {
                var values = new List<int>();

                for (int j = 0; j < i + 1; j++)
                {
                    if (j == 0 || j == i)
                    {
                        values.Add(1);
                    }
                    else
                    {
                        values.Add(result[i - 1][j - 1] + result[i - 1][j]);
                    }
                }

                result.Add(values);
            }

            return result.ElementAt(rowIndex);
        }

        /// <summary>
        /// 121. Best Time to Buy and Sell Stock. Tags: Array, Dynamic Programming
        /// </summary>
        /// [7,1,5,3,6,4]
        /// [7,6,4,3,1]
        public static int MaxProfit1(int[] prices)
        {
            var n = prices.Length;
            if (n == 1)
            {
                return 0;
            }

            int[][] values = new int[n][];

            for (int i = 0; i < n; i++)
            {
                var price = prices[i];

                values[i] = new int[] { price };
            }
            return 0;
        }
    }
}
