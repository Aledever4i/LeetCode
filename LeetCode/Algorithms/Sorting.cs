using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LeetCode.Algorithms
{
    public static class Sorting
    {
        public static bool TopologicalSort(Dictionary<int, List<int>> elements, int minValue, int maxValue, in List<int> output)
        {
            var indegree = new Dictionary<int, int>();
            for (int i = minValue; i <= maxValue; i++)
            {
                indegree.Add(i, 0);
            }

            for (int i = minValue; i <= maxValue; i++)
            {
                if (elements.TryGetValue(i, out var elementsValues))
                {
                    foreach (var ind in elementsValues)
                    {
                        indegree[ind]++;
                    }
                }
            }

            var queue = new Queue<int>();
            foreach (var element in indegree)
            {
                if (element.Value == 0)
                {
                    queue.Enqueue(element.Key);
                }
            }

            while (queue.Count > 0)
            {
                var value = queue.Dequeue();

                if (elements.ContainsKey(value))
                {
                    output.Add(value);

                    foreach (var it in elements[value])
                    {
                        indegree[it]--;

                        if (indegree[it] == 0)
                        {
                            queue.Enqueue(it);
                        }
                    }
                }
            }

            if (indegree.Values.Any(v => v > 0))
            {
                return false;
            }

            return true;
        }

        public static bool LoopCheck(int less, int more, Dictionary<int, List<int>> dict)
        {
            var queue = new Queue<int>(new int[] { less });
            while (queue.Count > 0)
            {
                var key = queue.Dequeue();
                var elements = dict[key];

                if (elements.Contains(more))
                {
                    return false;
                }

                foreach (var e in elements)
                {
                    queue.Enqueue(e);
                }
            }

            return true;
        }

    }
}
