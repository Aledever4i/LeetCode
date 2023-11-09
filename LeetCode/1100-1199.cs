using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        /// 1140. Stone Game II
        /// </summary>
        public static int StoneGameII(int[] piles)
        {
            return 1;
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
