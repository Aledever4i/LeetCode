using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class _2100_2199
    {
        /// <summary>
        /// 2100. Find Good Days to Rob the Bank
        /// </summary>
        public static IList<int> GoodDaysToRobBank(int[] security, int time)
        {
            var n = security.Length;
            var leftDescendings = new int[n];
            var rightDescendings = new int[n];

            for (var i = 1; i < n; i++)
            {
                leftDescendings[i] = security[i - 1] < security[i] ? 0 : leftDescendings[i - 1] + 1;
            }

            for (var i = n - 2; i >= 0; i--)
            {
                rightDescendings[i] = security[i] > security[i + 1] ? 0 : rightDescendings[i + 1] + 1;
            }

            var result = new List<int>();
            for (var i = 0; i < n; i++)
            {
                if (leftDescendings[i] >= time && rightDescendings[i] >= time)
                    result.Add(i);
            }
            return result;
        }

        /// <summary>
        /// 2101. Detonate the Maximum Bombs. Tags: Array, Math, Depth-First Search, Breadth-First Search, Graph, Geometry
        /// </summary>
        public static int MaximumDetonation(int[][] bombs)
        {
            var n = bombs.Length;
            var list = new int[n][];
            var result = new int[n];

            for (int i = 0; i < n; i++)
            {
                List<int> points = new List<int>();

                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    if ((Math.Pow(bombs[i][0] - bombs[j][0], 2) + Math.Pow(bombs[i][1] - bombs[j][1], 2)) <= Math.Pow(bombs[i][2], 2))
                    {
                        points.Add(j);
                    }
                }

                list[i] = points.ToArray();
            }

            for (int i = 0; i < n; i++)
            {
                var visited = new List<int>();
                var booms = new List<int>();

                booms.Add(i);
                boom(i, visited, booms);

                result[i] = booms.Distinct().Count();
            }

            return result.Max();

            void boom(int p, List<int> visited, List<int> booms)
            {
                var newBooms = list[p];
                booms.AddRange(newBooms);
                visited.Add(p);

                foreach (var i in newBooms)
                {
                    if (!visited.Contains(i))
                    {
                        boom(i, visited, booms);
                    }
                }
            }
        }

        /// <summary>
        /// 2108. Find First Palindromic String in the Array
        /// </summary>
        public static string FirstPalindrome(string[] words)
        {
            foreach (var word in words)
            {
                var n = word.Length;
                var left = 0;
                var right = n - 1;
                var isBreak = false;
                while (left <= right && !isBreak)
                {
                    if (word[left] != word[right])
                    {
                        isBreak = true;
                    }
                    left++;
                    right--;
                }

                if (!isBreak)
                {
                    return word;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// 2109. Adding Spaces to a String
        /// </summary>
        public static string AddSpaces(string s, int[] spaces)
        {
            var stringBuilder = new StringBuilder();
            var prev = 0;

            for (var i = 0; i < spaces.Length; i++)
            {
                stringBuilder.Append(s[prev..spaces[i]]).Append(' ');
                prev = spaces[i];
            }

            stringBuilder.Append(s[prev..s.Length]);

            return stringBuilder.ToString();
        }

        /// <summary>
        /// 2116. Check if a Parentheses String Can Be Valid
        /// </summary>
        public static bool CanBeValid(string s, string locked)
        {
            if (s.Length % 2 == 1) return false;

            var reserved = 0;
            var open = 0;
            for (int i = 0; i < locked.Length; i++)
            {
                var value = locked[i];

                if (value == '0')
                {
                    reserved++;
                }
                else
                {
                    var sChar = s[i];

                    if (sChar == '(')
                    {
                        open++;
                    }
                    else
                    {
                        if (open > 0)
                        {
                            open--;
                        }
                        else if (reserved > 0)
                        {
                            reserved--;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }

            reserved = 0;
            open = 0;
            for (int i = locked.Length - 1; i >= 0; i--)
            {
                var value = locked[i];

                if (value == '0')
                {
                    reserved++;
                }
                else
                {
                    var sChar = s[i];

                    if (sChar == ')')
                    {
                        open++;
                    }
                    else
                    {
                        if (open > 0)
                        {
                            open--;
                        }
                        else if (reserved > 0)
                        {
                            reserved--;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 2125. Number of Laser Beams in a Bank
        /// </summary>
        public static int NumberOfBeams(string[] bank)
        {


            return 0;
        }

        /// <summary>
        /// 2140. Solving Questions With Brainpower
        /// По аналогии с задачей 1035 попробывал решить через матрицу. В принципе решение прикольное, но не проходит по памяти.
        /// Поэтому старый подход с алгоритмом фибоначчи и кеширующей таблицей подошел.
        /// </summary>
        public static long MostPoints(int[][] questions)
        {
            var cache = new long[questions.Length];

            long choice(int index)
            {
                if (index >= questions.Length)
                {
                    return 0;
                }

                if (cache[index] != 0)
                {
                    return cache[index];
                }

                var choice1 = questions[index][0] + choice(index + questions[index][1] + 1);
                var choice2 = choice(index + 1);

                cache[index] = Math.Max(choice1, choice2);

                return cache[index];
            }

            long max = 0;
            for (int i = 0; i < questions.Length; i++)
            {
                var result = choice(i);
                max = max > result ? max : result;
            }

            return max;


            //var points = new int[questions.Length, questions.Length];

            //for (int i = 0; i < questions.Length; i++)
            //{
            //    var question = questions[i];

            //    var max = 0;
            //    for (int y = 0; y < i; y++)
            //    {
            //        if (questions[y][1] + y < i)
            //        {
            //            max = max > points[y, i] ? max : points[y, i];
            //        }
            //    }

            //    for (int y = i; y < questions.Length; y++)
            //    {
            //        points[i, y] = question[0] + max;
            //    }
            //}

            //var result = 0;
            //for (int i = 0; i < questions.Length; i++)
            //{
            //    var p = points[i, questions.Length - 1];
            //    result = (p > result) ? p : result;
            //}

            //return result;
        }

        /// <summary>
        /// 2149. Rearrange Array Elements by Sign
        /// </summary>
        public static int[] RearrangeArray(int[] nums)
        {
            var result = new int[nums.Length];

            var positiveIndex = 0;
            var negativeIndex = 1;

            foreach (var num in nums)
            {
                if (num > 0)
                {
                    result[positiveIndex] = num;
                    positiveIndex += 2;
                }
                else
                {
                    result[negativeIndex] = num;
                    negativeIndex += 2;
                }
            }

            return result;
        }

        /// <summary>
        /// 2181. Merge Nodes in Between Zeros
        /// </summary>
        public static ListNode MergeNodes(ListNode head)
        {
            var result = new ListNode();
            var start = result;

            while (head != null)
            {
                var newValue = 0;

                while (head != null && head.val != 0)
                {
                    newValue += head.val;
                    head = head.next;
                }

                if (newValue != 0)
                {
                    result.next = new ListNode(newValue);
                    result = result.next;
                }

                head = head.next;
            }

            return start.next;
        }

        /// <summary>
        /// 2185. Counting Words With a Given Prefix
        /// </summary>
        public static int PrefixCount(string[] words, string pref)
        {
            var len = pref.Length;
            var ans = 0;

            foreach (var word in words.Where(w => w.Length >= len))
            {
                if (pref == word[..len])
                {
                    ans++;
                }
            }

            return ans;
        }

        /// <summary>
        /// 2191. Sort the Jumbled Numbers
        /// </summary>
        public static int[] SortJumbled(int[] mapping, int[] nums)
        {
            var convertTable = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var value = string.Join("", nums[i].ToString().Select(v => mapping[(int)Char.GetNumericValue(v)])).TrimStart('0');

                convertTable.TryAdd(nums[i], string.IsNullOrWhiteSpace(value) ? 0 : int.Parse(value));
            }

            Array.Sort(nums, (a, b) => { return convertTable[a].CompareTo(convertTable[b]); });

            return nums;
        }

        /// <summary>
        /// 2196. Create Binary Tree From Descriptions
        /// </summary>
        public static TreeNode CreateBinaryTree(int[][] descriptions)
        {
            var nodes = new List<int>();
            var parents = new List<int>();

            var dict = new Dictionary<int, TreeNode>();

            foreach (var desc in descriptions)
            {
                nodes.Add(desc[1]);
                parents.Add(desc[0]);

                dict.TryAdd(desc[0], new TreeNode(desc[0], null, null));
                dict.TryAdd(desc[1], new TreeNode(desc[1], null, null));

                if (desc[2] == 1)
                {
                    dict[desc[0]].left = dict[desc[1]];
                }
                else
                {
                    dict[desc[0]].right = dict[desc[1]];
                }
            }

            var root = parents.Except(nodes).First();

            return dict[root];
        }
    }
}
