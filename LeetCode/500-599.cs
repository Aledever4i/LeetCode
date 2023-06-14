using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class _500_599
    {
        /// <summary>
        /// 530. Minimum Absolute Difference in BST. Tags: Tree, Depth-First Search, Breadth-First Search, Binary Search Tree, Binary Tree,
        /// </summary>
        public static int GetMinimumDifference(TreeNode root)
        {
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            var array = new List<int>();
            var result = int.MaxValue;

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                var value = node.val;

                var index = array.BinarySearch(value);
                if (index < 0)
                {
                    index = ~index;
                }
                array.Insert(index, value);

                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }

                if (array.Count() == 2)
                {
                    result = Math.Abs(array[0] - array[1]);
                }
                else if (array.Count() > 2)
                {
                    if (index > 0)
                    {
                        var tempResult = Math.Abs(array[index] - array[index - 1]);
                        result = (result > tempResult) ? tempResult : result;

                        if (result == 0)
                        {
                            return result;
                        }
                    }

                    if (array.Count - 1 != index)
                    {
                        var tempResult = Math.Abs(array[index] - nextValue);
                        result = (result > tempResult) ? tempResult : result;

                        if (result == 0)
                        {
                            return result;
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 547. Number of Provinces. Tags: Depth-First Search, Breadth-First Search, Union Find, Graph
        /// </summary>
        public static int FindCircleNum(int[][] isConnected)
        {
            var n = isConnected.Length;
            var island = 0;
            var isIncluded = new bool[n];

            for (int i = 0; i < n; i++)
            {
                if (isIncluded[i] == false)
                {
                    isIncluded[i] = true;
                    DFS(isConnected, i, isIncluded);
                    island++;
                }
            }

            return island;

            void DFS(int[][] graph, int i, bool[] h)
            {
                for (int j = 0; j < graph[i].Length; j++)
                {
                    if (i != j && graph[i][j] == 1 && h[j] == false)
                    {
                        h[j] = true;
                        DFS(graph, j, h);
                    }
                }
            }
        }
    }
}
