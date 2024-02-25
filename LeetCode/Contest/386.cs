using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Contest
{
    public static class _386
    {
        public static bool IsPossibleToSplit(int[] nums)
        {
            var dist = nums.GroupBy(n => n).ToDictionary(n => n.Key, n => n.Count());

            foreach (var n in dist.Values)
            {
                if (n > 2)
                {
                    return false;
                }
            }

            return true;
        }
        public static long LargestSquareArea(int[][] bottomLeft, int[][] topRight)
        {
            long result = 0;

            for (var y = 0; y < bottomLeft.Length; y++)
            {
                var startRectangle = new System.Drawing.Rectangle(bottomLeft[y][0], bottomLeft[y][1], topRight[y][0] - bottomLeft[y][0], topRight[y][1] - bottomLeft[y][1]);

                for (var i = y + 1; i < bottomLeft.Length; i++)
                {
                    var currentRectangle = new System.Drawing.Rectangle(bottomLeft[i][0], bottomLeft[i][1], topRight[i][0] - bottomLeft[i][0], topRight[i][1] - bottomLeft[i][1]);

                    if (startRectangle.IntersectsWith(currentRectangle))
                    {
                        var temp = startRectangle;
                        temp.Intersect(currentRectangle);
                        result = Math.Max(result, (long)Math.Pow(Math.Min(temp.Size.Height, temp.Size.Width), 2));
                    }
                }
            }

            return result == int.MaxValue ? 0 : result;
        }
    }
}
