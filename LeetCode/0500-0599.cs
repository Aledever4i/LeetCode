﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class _0500_0599
    {
        /// <summary>
        /// 501. Find Mode in Binary Search Tree
        /// </summary>
        public static int[] FindMode(TreeNode root)
        {
            var dict = new Dictionary<int, int>();

            Analyse(root);

            var maxCount = dict.Select(val => val.Value).Max();
            return dict.Where(val => val.Value == maxCount).Select(val => val.Key).ToArray();

            void Analyse (TreeNode root)
            {
                if (root == null)
                {
                    return;
                }

                if (!dict.TryAdd(root.val, 1))
                {
                    dict[root.val] += 1;
                }

                if (root.right != null)
                {
                    Analyse(root.right);
                }

                if (root.left != null)
                {
                    Analyse(root.left);
                }
            }
        }


        /// <summary>
        /// 515. Find Largest Value in Each Tree Row
        /// </summary>
        public static IList<int> LargestValues(TreeNode root)
        {
            if (root == null)
            {
                return new List<int>();
            }

            var dict = new Dictionary<int, int>();

            dfs(root, 0);

            void dfs(TreeNode node, int level)
            {
                if (!dict.TryAdd(level, node.val))
                {
                    dict[level] = Math.Max(dict[level], node.val);
                }

                if (node.right != null)
                {
                    dfs(node.right, level + 1);
                }

                if (node.left != null)
                {
                    dfs(node.left, level + 1);
                }
            }

            return dict.Values.ToList();
        }

        /// <summary>
        /// 518. Coin Change II
        /// </summary>
        public static int Change(int amount, int[] coins)
        {
            var n = coins.Length;
            var dp = new int[n][];

            for (int i = 0; i < dp.Length; i++)
            {
                var value = new int[amount + 1];
                System.Array.Fill(value, -1);
                dp[i] = value;
            }

            var result = numberOfWays(0, amount);

            return result;

            int numberOfWays(int index, int remaining)
            {
                if (remaining == 0)
                {
                    return 1;
                }

                if (index == n)
                {
                    return 0;
                }

                if (dp[index][remaining] != -1)
                {
                    return dp[index][remaining];
                }

                if (coins[index] > remaining)
                {
                    dp[index][remaining] = numberOfWays(index + 1, remaining);
                }
                else
                {
                    dp[index][remaining] = numberOfWays(index, remaining - coins[index]) + numberOfWays(index + 1, remaining);
                }

                return dp[index][remaining];
            }
        }

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
                        var tempResult = Math.Abs(array[index] - array[index + 1]);
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
        /// 543. Diameter of Binary Tree
        /// </summary>
        public static int DiameterOfBinaryTree(TreeNode root)
        {
            var result = 0;
            maxDeep(root, 0);
            return result;

            int maxDeep(TreeNode tree, int currentLevel)
            {
                if (tree == null)
                {
                    return currentLevel;
                }

                var left = maxDeep(tree.left, currentLevel + 1);
                var right = maxDeep(tree.right, currentLevel + 1);

                result = Math.Max(result, left + right);

                return Math.Max(left, right);
            }
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

        /// <summary>
        /// 557. Reverse Words in a String III
        /// </summary>
        public static string ReverseWords(string s)
        {
            var words = s.Split(" ");
            var reversedWords = words.Select(word => string.Join("", word.Reverse()));
            return string.Join(" ", reversedWords);
        }
    }
}
