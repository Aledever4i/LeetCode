﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class _1200_1299
    {
        /// <summary>
        /// 1232. Check If It Is a Straight Line. Tags: Array, Math, Geometry
        /// </summary>
        public static bool CheckStraightLine(int[][] coordinates)
        {
            if (coordinates.Length == 2)
            {
                return true;
            }

            var point1X = coordinates[0][0];
            var point1Y = coordinates[0][1];

            var point2X = coordinates[1][0];
            var point2Y = coordinates[1][1];

            if (point1X == point2X)
            {
                return !coordinates.Any(coordinate => coordinate[0] != point1X);
            }
            else if (point1Y == point2Y)
            {
                return !coordinates.Any(coordinate => coordinate[1] != point1Y);
            }


            double xStep = Math.Abs( - point2X);
            double yStep = Math.Abs(point1Y - point2Y);

            return !coordinates.Any(coordinate => (coordinate[0] - point1X) / (point2X - point1X) != (coordinate[1] - point1Y) / (point2Y - point1Y));
        }
    }
}