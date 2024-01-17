using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Contest
{
    public static class _380
    {

        public static int MaxFrequencyElements(int[] nums)
        {
            var array = new int[101];
            var freq = 0;

            foreach (var x in nums)
            {
                var currFreq = ++array[x];

                if (currFreq > freq)
                {
                    freq = currFreq;
                }
            }

            return array.Where(x => x == freq).Sum();
        }


        public static IList<int> BeautifulIndices(string s, string a, string b, int k)
        {
            var result = new List<int>();
            var bPriorityQueue = new Queue<int>();
            for (int index = 0; ; index++)
            {
                index = s.IndexOf(b, index);
                if (index == -1)
                {
                    break;
                }
                bPriorityQueue.Enqueue(index);
            }

            var currentQueue = new Queue<int>();
            for (int index = 0; ; index++)
            {
                index = s.IndexOf(a, index);
                if (index == -1)
                {
                    break;
                }

                while (bPriorityQueue.Count > 0 && bPriorityQueue.Peek() <= index + k)
                {
                    var bValue = bPriorityQueue.Dequeue();
                    currentQueue.Enqueue(bValue);
                }

                while (currentQueue.Count > 0 && currentQueue.Peek() < index - k)
                {
                    currentQueue.Dequeue();
                }

                if (currentQueue.Count > 0)
                {
                    result.Add(index);
                }
            }

            return result.ToList();
        }
    }
}
