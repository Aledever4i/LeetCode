using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LeetCode
{
    public static class _0800_0899
    {
        /// <summary>
        /// 802. Find Eventual Safe States
        /// </summary>
        public static IList<int> EventualSafeNodes(int[][] graph)
        {
            int n = graph.Length;
            var adj = new List<List<int>>();
            for (int i = 0; i < n; i++)
            {
                var newList = new List<int>();
                newList.AddRange(graph[i]);
                adj.Add(newList);
            }

            bool[] visit = new bool[n];
            bool[] inStack = new bool[n];

            for (int i = 0; i < n; i++)
            {
                dfs(i, adj, visit, inStack);
            }

            var safeNodes = new List<int>();
            for (int i = 0; i < n; i++)
            {
                if (!inStack[i])
                {
                    safeNodes.Add(i);
                }
            }
            return safeNodes;

            bool dfs(int node, List<List<int>> adj, bool[] visit, bool[] inStack)
            {
                if (inStack[node])
                    return true;

                if (visit[node])
                    return false;

                visit[node] = true;
                inStack[node] = true;

                foreach (int neighbor in adj[node]) 
                {
                    if (dfs(neighbor, adj, visit, inStack))
                    {
                        return true;
                    }
                }
                inStack[node] = false;
                return false;
            }
        }

        /// <summary>
        /// 823. Binary Trees With Factors
        /// </summary>
        public static int NumFactoredBinaryTrees(int[] arr)
        {
            System.Array.Sort(arr);
            var s = new HashSet<int>(arr);
            var dp = new Dictionary<int, long>();

            foreach (int x in arr)
            {
                dp[x] = 1;
            }

            foreach (int i in arr)
            {
                foreach (int j in arr)
                {
                    if (j > Math.Sqrt(i))
                    {
                        break;
                    }

                    if (i % j == 0 && s.Contains(i / j))
                    {
                        long temp = dp[j] * dp[i / j];
                        dp[i] = (dp[i] + (i / j == j ? temp : temp * 2)) % 1000000007;
                    }
                }
            }

            long result = 0;
            foreach (long val in dp.Values)
            {
                result = (result + val) % 1000000007;
            }
            return (int)result;
        }

/// <summary>
/// 837. New 21 Game. Tags: Math, Dynamic Programming, Sliding Window, Probability and Statistics
/// </summary>
public static double New21Game(int n, int k, int maxPts)
        {
            return 0.0;
        }

        /// <summary>
        /// 844. Backspace String Compare
        /// </summary>
        public static bool BackspaceCompare(string s, string t)
        {
            return Sanitaze(s).Equals(Sanitaze(t));

            string Sanitaze(string s)
            {
                var stack = new Stack<char>();

                foreach (var c in s)
                {
                    if (c == '#')
                    {
                        if (stack.Count > 0)
                        {
                            stack.Pop();
                        }
                    }
                    else
                    {
                        stack.Push(c);
                    }
                }

                return new string(stack.ToArray());
            }
        }

        /// <summary>
        /// 859. Buddy Strings. Tags: Hash Table, String
        /// </summary>
        public static bool BuddyStrings(string s, string goal)
        {
            var sInEqual = new List<char>();
            var goalInEqual = new List<char>();

            if (s.Length != goal.Length)
            {
                return false;
            }

            for (int i = 0; i < s.Length; i++)
            {
                var sChar = s[i];
                var goalChar = goal[i];

                if (sChar != goalChar)
                {
                    sInEqual.Add(sChar);
                    goalInEqual.Add(goalChar);
                }
            }

            if (sInEqual.Count() == 2 && !sInEqual.Except(goalInEqual).Any())
            {
                return true;
            }
            else if (sInEqual.Count() == 1)
            {
                return false;
            }
            else if (sInEqual.Count() > 2)
            {
                return false;
            }
            else if (!sInEqual.Any())
            {
                return s.GroupBy(c => c).Any(gr => gr.Count() > 1);
            }

            return false;
        }

        /// <summary>
        /// 860. Lemonade Change
        /// </summary>
        public static bool LemonadeChange(int[] bills)
        {
            var dict = new Dictionary<int, int>
            {
                { 5, 0 },
                { 10, 0 }
            };

            for (int i = 0; i < bills.Length; i++)
            {
                var value = bills[i];

                if (value == 5)
                {
                    dict[5] += 1;
                }
                else if (value == 10 && dict[5] >= 1)
                {
                    dict[10] += 1;
                    dict[5] -= 1;
                }
                else
                {
                    if (dict[10] >= 1 && dict[5] >= 1)
                    {
                        dict[10] -= 1;
                        dict[5] -= 1;
                    }
                    else if (dict[5] >= 3)
                    {
                        dict[5] -= 3;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 863. All Nodes Distance K in Binary Tree
        /// TODO: НЕ РЕШИЛ САМ
        /// </summary>
        public static IList<int> DistanceK(TreeNode root, TreeNode target, int k)
        {
            var graph = new Dictionary<int, List<int>>();
            dfsBuild(root, null, graph);

            var answer = new List<int>();
            HashSet<int> visited = new HashSet<int>();
            Queue<int[]> queue = new Queue<int[]>();

            queue.Enqueue(new int[] { target.val, 0 });
            visited.Add(target.val);

            while (queue.Count() > 0)
            {
                int[] cur = queue.Dequeue();
                int node = cur[0], distance = cur[1];
                if (distance == k)
                {
                    answer.Add(node);
                    continue;
                }

                if (graph.TryGetValue(node, out List<int> value))
                {
                    foreach (var neighbor in value)
                    {
                        if (!visited.Contains(neighbor))
                        {
                            visited.Add(neighbor);
                            queue.Enqueue(new int[] { neighbor, distance + 1 });
                        }
                    }
                }
            }

            return answer;

            void dfsBuild(TreeNode cur, TreeNode parent, Dictionary<int, List<int>> graph)
            {
                if (cur != null && parent != null)
                {
                    int curVal = cur.val, parentVal = parent.val;

                    graph.TryAdd(curVal, new List<int>());
                    graph.TryAdd(parentVal, new List<int>());

                    graph[curVal].Add(parentVal);
                    graph[parentVal].Add(curVal);
                }

                if (cur != null && cur.left != null)
                {
                    dfsBuild(cur.left, cur, graph);
                }

                if (cur != null && cur.right != null)
                {
                    dfsBuild(cur.right, cur, graph);
                }
            }
        }        

        /// <summary>
        /// 877. Stone Game. Tags: Array, Math, Dynamic Programming, Game Theory
        /// </summary>
        public static bool StoneGame(int[] piles)
        {
            int count = piles.Length;

            var dp = new int[count + 2][];
            for (int y = 0; y < count + 2; y++)
            {
                dp[y] = new int[count + 2];
            }

            var first = 0;
            var second = 0;
            var step = 0;

            for (int x = 0, y = count - 1; step < count; step++)
            {
                var who = (x + y % 2);
                var left1 = piles[x] + GetMAxPoint(x + 2, y);
                var right = piles[y] + GetMAxPoint(x, y - 2);

                if (left1 > right)
                {
                    if (who == 1)
                    {
                        first += piles[x];
                    }
                    else
                    {
                        second += piles[x];
                    }
                    x = x + 1;
                }
                else
                {
                    if (who == 1)
                    {
                        first += piles[y];
                    }
                    else
                    {
                        second += piles[y];
                    }
                    y = y - 1;
                }
            }

            return first > second;

            int GetMAxPoint(int x, int y)
            {
                if (x > y || y < x || x < 0 || y < 0)
                {
                    return 0;
                }

                if (dp[x][y] > 0)
                {
                    return dp[x][y];
                }

                if (x == y || Math.Abs(x - y) == 1)
                {
                    dp[x][y] = Math.Max(piles[x], piles[y]);

                    return dp[x][y];
                }
                else
                {
                    var left1 = piles[x] + GetMAxPoint(x + 2, y);
                    var right2 = piles[y] + GetMAxPoint(x, y - 2);
                    
                    dp[x][y] = Math.Max(left1, right2);
                }

                return dp[x][y];
            }
        }

        /// <summary>
        /// 880. Decoded String at Index
        /// </summary>
        public static string DecodeAtIndex(string s, int k)
        {
            return string.Empty;
        }

        /// <summary>
        /// 896. Monotonic Array
        /// </summary>
        public static bool IsMonotonic(int[] nums)
        {
            var inc = nums.OrderBy(x => x);
            if (Enumerable.SequenceEqual(nums, inc))
            {
                return true;
            }

            var descr = nums.OrderByDescending(x => x);
            if (Enumerable.SequenceEqual(nums, descr))
            {
                return true;
            }

            return false;
        }
    }
}
