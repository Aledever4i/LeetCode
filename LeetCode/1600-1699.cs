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

    }
}
