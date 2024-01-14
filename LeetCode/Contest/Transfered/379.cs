using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Contest.Transfered
{
    public static class _379
    {
        public static int AreaOfMaxDiagonal(int[][] dimensions)
        {
            int result = 0;
            double multi = 0;

            foreach (var dimension in dimensions)
            {
                var curMulti = Math.Pow(dimension[0], 2) + Math.Pow(dimension[1], 2);

                if (multi == curMulti)
                {
                    result = Math.Max(result, dimension[0] * dimension[1]);
                }
                else if (multi < curMulti)
                {
                    result = dimension[0] * dimension[1];
                    multi = curMulti;
                }
            }

            return result;
        }
        public static int MinMovesToCaptureTheQueen(int a, int b, int c, int d, int e, int f)
        {
            if (BishopCrossQueen(a, b, c, d, e, f))
            {
                return 1;
            }
            else if (RockCrossQueen(a, b, c, d, e, f))
            {
                return 1;
            }

            return 2;

            bool BishopCrossQueen(int a, int b, int c, int d, int e, int f)
            {
                var bishopMoves = new int[4][] {
                    new int[] { 1, 1 },
                    new int[] { -1, 1 },
                    new int[] { -1, -1 },
                    new int[] { 1, -1 }
                };

                foreach (var i in bishopMoves)
                {
                    var startPositionC = c;
                    var startPositionD = d;

                    while (startPositionC > 0 && startPositionC < 9 && startPositionD > 0 && startPositionD < 9)
                    {
                        startPositionC += i[0];
                        startPositionD += i[1];

                        if (startPositionC == a && startPositionD == b)
                        {
                            break;
                        }
                        else if (startPositionC == e && startPositionD == f)
                        {
                            return true;
                        }
                    }
                }

                return false;
            }

            bool RockCrossQueen(int a, int b, int c, int d, int e, int f)
            {
                var rockMoves = new int[4][] {
                    new int[] { 0, 1 },
                    new int[] { 0, -1 },
                    new int[] { 1, 0 },
                    new int[] { -1, 0 }
                };

                foreach (var i in rockMoves)
                {
                    var startPositionC = a;
                    var startPositionD = b;

                    while (startPositionC > 0 && startPositionC < 9 && startPositionD > 0 && startPositionD < 9)
                    {
                        startPositionC += i[0];
                        startPositionD += i[1];

                        if (startPositionC == c && startPositionD == d)
                        {
                            break;
                        }
                        else if (startPositionC == e && startPositionD == f)
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
        }

        public static int MaximumSetSize(int[] nums1, int[] nums2)
        {
            var n = nums1.Length;
            var distinctNums1 = nums1.Distinct();
            var distinctNums1Count = distinctNums1.Count();
            var distinctNums2 = nums2.Distinct();
            var distinctNums2Count = distinctNums2.Count();

            var intersectCount = distinctNums1.Intersect(distinctNums2).Count();

            var fromNums1 = Math.Min(distinctNums1Count - intersectCount, n / 2);
            var fromNums2 = Math.Min(distinctNums2Count - intersectCount, n / 2);

            return Math.Min(fromNums1 + fromNums2 + intersectCount, n);
        }
    }
}
