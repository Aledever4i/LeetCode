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
        /// <summary>
        /// Сортировка для графов, возращает последовательность снятия зависимостей с точек
        /// </summary>
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
    }
}
