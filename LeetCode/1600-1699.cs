using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /// <summary>
    /// 1603. Design Parking System
    /// </summary>
    public class ParkingSystem
    {
        private Dictionary<int, int> map = new Dictionary<int, int>();

        public ParkingSystem(int big, int medium, int small)
        {
            map[1] = big;
            map[2] = medium;
            map[3] = small;
        }

        public bool AddCar(int carType)
        {
            if (map[carType] > 0) {
                map[carType]--;
                return true;
            }

            return false;
        }
    }

    public static class _1600_1699
    {
        /// <summary>
        /// 1658. Minimum Operations to Reduce X to Zero
        /// </summary>
        public static int MinOperations(int[] nums, int x)
        {
            var n = nums.Length;
            var leftStack = new Stack<int>();
            var tempSum = 0;
            var leftIter = 0;
            var result = -1;

            while (tempSum < x && leftIter < n)
            {
                var leftValue = nums[leftIter];
                tempSum += leftValue;
                leftStack.Push(leftValue);
                leftIter++;
            }

            if (leftIter == n)
            {
                return -1;
            }

            if (tempSum == 0)
            {
                result = leftIter;
            }

            for (int i = 0; i < leftIter; i++)
            {
                tempSum -= leftStack.Pop();
                tempSum += nums[n - 1 - i];

                if (tempSum == 0)
                {
                    result = Math.Min(result, leftIter );
                }
            }

            return result;
        }
    }
}
