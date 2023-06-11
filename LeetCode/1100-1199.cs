using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /// <summary>
    /// 1146. Snapshot Array. Tags: Array, Hash Table, Binary Search, Design
    /// </summary>
    public class SnapshotArray
    {
        Dictionary<int, int>[] snapshot; 
        int initLength = 0;
        int currentSnapshotId = 0;

        public SnapshotArray(int length)
        {
            snapshot = new Dictionary<int, int>[length];

            var dictionary = new Dictionary<int, int>();

            for (int i = 0; i < length; i++)
            {
                var defaultInit = new Dictionary<int, int>();
                defaultInit.Add(0, 0);
                snapshot[i] = defaultInit;
            }
        }

        public void Set(int index, int val)
        {
            snapshot[index][currentSnapshotId] = val;
        }

        public int Snap()
        {
            var temp = currentSnapshotId;

            currentSnapshotId++;

            return temp;
        }

        public int Get(int index, int snap_id)
        {
            return snapshot[index].Last(record => record.Key <= snap_id).Value;
        }
    }

    public static class _1100_1199
    {
        /// <summary>
        /// 1140. Stone Game II
        /// </summary>
        public static int StoneGameII(int[] piles)
        {
            return 1;
        }
    }
}
