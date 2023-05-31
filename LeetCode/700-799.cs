using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /// <summary>
    /// 705. Design HashSet
    /// </summary>
    public class MyHashSet
    {
        private int currentIndex = 0;
        private int currentSize = 10;

        private int?[] keys;

        public MyHashSet()
        {
            keys = new int?[currentSize];
        }

        public void Add(int key)
        {
            var index = System.Array.IndexOf(keys, key, 0, currentSize);
            if (index >= 0)
            {
                return;
            }

            if (currentIndex >= currentSize)
            {
                resize(currentSize + 2);
                currentSize += 2;
            }

            keys[currentIndex] = key;

            currentIndex++;
        }

        public void Remove(int key)
        {
            var index = System.Array.IndexOf(keys, key);

            if (index >= 0)
            {
                System.Array.Copy(keys, index + 1, keys, index, currentSize - index - 1);
            }
        }

        public bool Contains(int key)
        {
            var index = System.Array.IndexOf(keys, key, 0, currentSize);

            return (index >= 0);
        }

        private void resize(int newSize)
        {
            var newArray = new int?[newSize];
            System.Array.Copy(keys, newArray, currentSize);
            keys = newArray;
        }
    }

    public static class _700_799
    {
        /// <summary>
        /// 785. Is Graph Bipartite?. Tags: Depth-First Search, Breadth-First Search, Union Find, Graph
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public static bool IsBipartite(int[][] graph)
        {
            var n = graph.Length;

            for (int i = 0; i < n; i++)
            {
                var connects = graph[i];

                var notConnectedX = Enumerable.Range(0, n).Except(connects);

                foreach (var y in notConnectedX)
                {
                    var connectY = graph[y];

                    var notConnectedY = Enumerable.Range(0, n).Except(connects).Except(new int[] { i, y });

                    if (!notConnectedY.Any())
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
