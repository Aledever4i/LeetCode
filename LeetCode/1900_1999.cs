using LeetCode.Algorithms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Numerics;
using System.Xml.Linq;

namespace LeetCode
{
    public static class _1900_1999
    {
        /// <summary>
        /// 1903. Largest Odd Number in String
        /// </summary>
        public static string LargestOddNumber(string num)
        {
            return string.Empty;
        }

        /// <summary>
        /// 1921. Eliminate Maximum Number of Monsters
        /// </summary>
        public static int EliminateMaximum(int[] dist, int[] speed)
        {
            var result = 0;
            var n = dist.Length;

            var time = new double[n];
            for (int i = 0; i < n; i++)
            {
                time[i] = (1.0 * dist[i]) / (1.0 * speed[i]);
            }

            Array.Sort(time);

            for (int i = 0; i < n; i++)
            {
                if (time[i] <= i)
                {
                    break;
                }
                result++;
            }

            return result;
        }

        /// <summary>
        /// 1930. Unique Length-3 Palindromic Subsequences
        /// </summary>
        public static int CountPalindromicSubsequence(string s)
        {
            var ans = 0;
            var data = s.Select((x, index) => new { x, index }).GroupBy(x => x.x).ToDictionary(x => x.Key, v => v.Select(y => y.index).ToArray());

            foreach (var key in data.Keys)
            {
                if (data[key].Length >= 2)
                {
                    var left = data[key][0];
                    var right = data[key].ElementAt(data[key].Length - 1);

                    foreach (var innerKey in data.Keys)
                    {
                        if (data[innerKey].Any(v => v > left && v < right))
                        {
                            ans++;
                        }
                    }
                }
            }

            return ans;
        }

        /// <summary>
        /// 1942. The Number of the Smallest Unoccupied Chair
        /// </summary>
        public static int SmallestChair(int[][] times, int targetFriend)
        {
            var sorted = times.Select((time, index) => new { Order = index, Come = time[0], Out = time[1] }).OrderBy(t => t.Come);
            var priority = new PriorityQueue<int, int>();
            foreach (var n in Enumerable.Range(1, times.Length)) {
                priority.Enqueue(n, n);
            }

            foreach (var temp in sorted)
            {

            }

            return 0;
        }

        /// <summary>
        /// 1945. Sum of Digits of String After Convert
        /// </summary>
        public static int GetLucky(string s, int k)
        {
            var numbers = string.Join("", s.Select(x => x - 'a' + 1));

            while (k-- > 0)
            {
                numbers = numbers.Sum(x => (decimal)(x - '0')).ToString();
            }

            return int.Parse(numbers);
        }

        public class TrieNode1948
        {
            public string name = string.Empty;
            public Dictionary<string, TrieNode1948> children = [];
        }

        /// <summary>
        /// 1948. Delete Duplicate Folders in System
        /// </summary>
        public static IList<IList<string>> DeleteDuplicateFolder(IList<IList<string>> paths)
        {
            // Root of the tree
            var root = new TrieNode1948 { name = "/" };

            // Build the tree from the given paths
            foreach (var path in paths)
            {
                AddPath(root, path);
            }

            // Dictionary to store serialized subtree structures and their frequency
            var subtreeCount = new Dictionary<string, int>();
            var nodeToSerialization = new Dictionary<TrieNode1948, string>();

            // Post-order traversal to serialize subtrees and count them
            SerializeSubtree(root, subtreeCount, nodeToSerialization);

            // List to collect remaining paths after removing duplicates
            var remainingPaths = new List<IList<string>>();

            // Traverse the tree again to collect valid paths
            CollectPaths(root, [], remainingPaths, subtreeCount, nodeToSerialization);

            return remainingPaths;

            void AddPath(TrieNode1948 root, IList<string> path)
            {
                TrieNode1948 current = root;
                foreach (var dir in path)
                {
                    current.children.TryAdd(dir, new TrieNode1948 { name = dir });
                    current = current.children[dir];
                }
            }

            string SerializeSubtree(TrieNode1948 node, Dictionary<string, int> subtreeCount, Dictionary<TrieNode1948, string> nodeToSerialization)
            {
                if (node.children.Count == 0)
                {
                    return string.Empty; // Leaf node
                }

                // Serialize the subtree rooted at this node
                var serializedChildren = new List<string>();
                foreach (var child in node.children.Values)
                {
                    serializedChildren.Add(child.name + "(" + SerializeSubtree(child, subtreeCount, nodeToSerialization) + ")");
                }

                serializedChildren.Sort(); // Sort to ensure identical structures have the same serialization
                string serialized = string.Join(",", serializedChildren);

                // Count the serialized structure
                if (!subtreeCount.TryAdd(serialized, 1))
                {
                    subtreeCount[serialized]++;
                }
                   
                nodeToSerialization[node] = serialized;
                return serialized;
            }

            void CollectPaths(TrieNode1948 node, List<string> currentPath, IList<IList<string>> remainingPaths, Dictionary<string, int> subtreeCount, Dictionary<TrieNode1948, string> nodeToSerialization)
            {
                if (node == null) return;

                // Serialize the subtree to check if it has duplicates
                // If this subtree occurs more than once, skip this subtree
                if (nodeToSerialization.TryGetValue(node, out string value) && subtreeCount.TryGetValue(value, out int count) && count > 1)
                {
                    return;
                }

                // Add the current path to remaining paths if not the root node
                if (!node.name.Equals("/"))
                {
                    remainingPaths.Add(new List<string>(currentPath));
                }

                // Recursively collect paths from child nodes
                foreach (var child in node.children)
                {
                    currentPath.Add(child.Key);
                    CollectPaths(child.Value, currentPath, remainingPaths, subtreeCount, nodeToSerialization);
                    currentPath.RemoveAt(currentPath.Count - 1);
                }
            }
        }

        /// <summary>
        /// 1975. Maximum Matrix Sum
        /// </summary>
        public static long MaxMatrixSum(int[][] matrix)
        {
            long result = 0;

            var negativeCount = 0;
            var minimum = int.MaxValue;

            foreach (var n in matrix) {
                foreach (var t in n) {
                    if (t < 0)
                    {
                        negativeCount++;
                    }

                    minimum = Math.Min(minimum, Math.Abs(t));

                    result += Math.Abs(t);
                }
            }

            return ((negativeCount & 1) == 0) ? result : result - minimum * 2;
        }

        /// <summary>
        /// 1980. Find Unique Binary String
        /// </summary>
        public static string FindDifferentBinaryString(string[] nums)
        {
            var value = nums[0];
            var hash = new HashSet<int>();
            var count = Math.Pow(2, value.Length);

            foreach (var item in nums)
            {
                hash.Add(Convert.ToInt32(item, 2));
            }

            foreach (var x in Enumerable.Range(0, (int)count))
            {
                if (hash.Add(x))
                {
                    var binary = Convert.ToString(x, 2);

                    return new string('0', value.Length - binary.Length) + binary;
                }
            }

            return "";
        }
    }
}
