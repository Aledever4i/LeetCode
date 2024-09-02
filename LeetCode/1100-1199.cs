using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
        /// 
        /// </summary>
        /// <param name="books"></param>
        /// <param name="shelfWidth"></param>
        /// <returns></returns>
        public static int MinHeightShelves(int[][] books, int shelfWidth)
        {
            var level = books.Length;
            return Store(0, 0, 0, shelfWidth);

            int Store(int curlevel, int height, int reservedHeight, int curShelf)
            {
                if (curlevel == level)
                {
                    return height;
                }

                var book = books[curlevel];

                if (curShelf < book[0])
                {
                    return Store(curlevel + 1, height + book[1], book[1], shelfWidth);
                }

                return Math.Min(Store(curlevel + 1, height + book[1], book[1], shelfWidth), Store(curlevel + 1, (reservedHeight < book[1]) ? height + book[1] - reservedHeight : height, Math.Max(reservedHeight, book[1]), curShelf - book[0]));
            }
        }

        /// <summary>
        /// 1110. Delete Nodes And Return Forest
        /// </summary>
        public static IList<TreeNode> DelNodes(TreeNode root, int[] to_delete)
        {
            var result = new List<TreeNode>();
            Check(ref root, true, to_delete);
            return result;

            void Check(ref TreeNode treeNode, bool isRoot, int[] to_delete)
            {
                if (treeNode == null)
                {
                    return;
                }

                var deleted = to_delete.Contains(treeNode.val);

                Check(ref treeNode.right, deleted, to_delete);
                Check(ref treeNode.left, deleted, to_delete);

                if (deleted)
                {
                    treeNode = null;
                }
                else if (isRoot)
                {
                    result.Add(treeNode);
                }
            }
        }

        /// <summary>
        /// 1125. Smallest Sufficient Team
        /// </summary>
        public static int[] SmallestSufficientTeam(string[] req_skills, IList<IList<string>> people)
        {
            var skillOwners = people
                .Select((skills, index) => new { skills, Index = index })
                .SelectMany(skills =>
                    skills
                    .skills
                    .Select(skill => new { skill, Owner = skills.Index })
                )
                .GroupBy(skill => skill.skill)
                .Select(gr => new { Skill = gr.Key, People = gr.Select(s => s.Owner).ToList() });  
                
                //skills.SelectMany(skill => new { skill, Owner = index })).Select(x => new { x.Key, People = x.Select(k => index) });

            return System.Array.Empty<int>();
        }

        /// <summary>
        /// 1137. N-th Tribonacci Number
        /// </summary>
        public static int Tribonacci(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            else if (n == 1)
            {
                return 1;
            }
            else if (n == 2)
            {
                return 1;
            }
            else if (n == 3)
            {
                return 2;
            }

            var dp = new int[n + 1];
            dp[1] = 1;
            dp[2] = 1;
            dp[3] = 2;

            for (int i = 4; i < n + 1; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2] + dp[i - 3];
            }

            return dp[n];
        }

        /// <summary>
        /// 1140. Stone Game II
        /// </summary>
        public static int StoneGameII(int[] piles)
        {
            return 1;
        }

        /// <summary>
        /// 1143. Longest Common Subsequence
        /// </summary>
        public static int LongestCommonSubsequence(string text1, string text2)
        {
            return 0;
        }

        /// <summary>
        /// 1160. Find Words That Can Be Formed by Characters
        /// </summary>
        public static int CountCharacters(string[] words, string chars)
        {
            var dict = chars.GroupBy(a => a).ToDictionary(a => a.Key, a => a.Count());

            var result = 0;

            foreach (var word in words)
            {
                var wordDict = word.GroupBy(a => a).ToDictionary(a => a.Key, a => a.Count());
                var canContinue = true;
                var tempResult = 0;

                foreach (var key in wordDict.Keys)
                {
                    var wValue = wordDict[key];

                    if (!dict.TryGetValue(key, out int value) || wValue > value)
                    {
                        canContinue = false;
                        break;
                    }

                    tempResult += wValue;
                }

                if (canContinue)
                {
                    result += tempResult;
                }
            }

            return result;
        }

        /// <summary>
        /// 1161. Maximum Level Sum of a Binary Tree. Tags: Tree, Depth-First Search, Breadth-First Search, Binary Tree
        /// </summary>
        public static int MaxLevelSum(TreeNode root)
        {
            var dict = new Dictionary<int, int>();

            var queue = new Queue<(int, TreeNode)>();
            queue.Enqueue((1, root));

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (!dict.TryAdd(node.Item1, node.Item2.val))
                {
                    dict[node.Item1] += node.Item2.val;
                }

                if (node.Item2.right != null)
                {
                    queue.Enqueue((node.Item1 + 1, node.Item2.right));
                }

                if (node.Item2.left != null)
                {
                    queue.Enqueue((node.Item1 + 1, node.Item2.left));
                }
            }

            return dict.MaxBy(value => value.Value).Key;
        }

        /// <summary>
        /// 1171. Remove Zero Sum Consecutive Nodes from Linked List
        /// </summary>
        public static ListNode RemoveZeroSumSublists(ListNode head)
        {
            if (head == null)
            {
                return head;
            }

            var front = new ListNode(0, head);
            var current = front;
            int prefixSum = 0;

            Dictionary<int, ListNode> prefixSumToNode = new Dictionary<int, ListNode>();
            prefixSumToNode.Add(0, front);

            while (current != null)
            {
                prefixSum += current.val;

                if (prefixSumToNode.ContainsKey(prefixSum))
                {
                    prefixSumToNode[prefixSum] = current;
                }
                else
                {
                    prefixSumToNode.Add(prefixSum, current);
                }

                current = current.next;
            }

            prefixSum = 0;
            current = front;
            while (current != null)
            {
                prefixSum += current.val;
                current.next = prefixSumToNode[prefixSum].next;
                current = current.next;
            }
            return front.next;
        }

        /// <summary>
        /// 1185. Day of the Week
        /// </summary>
        public static string DayOfTheWeek(int day, int month, int year)
        {
            return new DateTime(year, month, day).DayOfWeek.ToString();
        }

        /// <summary>
        /// 1187. Make Array Strictly Increasing. Tags: Array, Binary Search, Dynamic Programming, Sorting
        /// </summary>
        public static int MakeArrayIncreasing(int[] arr1, int[] arr2)
        {
            System.Array.Sort(arr2);
            var dp = new Dictionary<(int, int), int>();

            int answer = dfs(0, -1, arr1, arr2);

            return answer < 2_001 ? answer : -1;

            int dfs(int i, int prev, int[] arr1, int[] arr2)
            {
                if (i == arr1.Length)
                {
                    return 0;
                }

                if (dp.ContainsKey((i, prev)))
                {
                    return dp[(i, prev)];
                }

                int cost = 2_001;

                // If arr1[i] is already greater than prev, we can leave it be.
                if (arr1[i] > prev)
                {
                    cost = dfs(i + 1, arr1[i], arr1, arr2);
                }

                // Find a replacement with the smallest value in arr2.
                int idx = bisectRight(arr2, prev);

                // Replace arr1[i], with a cost of 1 operation.
                if (idx < arr2.Length)
                {
                    cost = Math.Min(cost, 1 + dfs(i + 1, arr2[idx], arr1, arr2));
                }

                dp.Add((i, prev), cost);
                return cost;
            }

            int bisectRight(int[] arr, int value)
            {
                int left = 0, right = arr.Length;
                while (left < right)
                {
                    int mid = (left + right) / 2;
                    if (arr[mid] <= value)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid;
                    }
                }
                return left;
            }
        }
    }
}
