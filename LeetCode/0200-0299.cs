using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /// <summary>
    /// 208. Implement Trie (Prefix Tree)
    /// </summary>
    public class Trie
    {
        private readonly Trie[] branches;
        public bool isEnd = false;

        public Trie()
        {
            branches = new Trie[26];
        }

        public void Insert(string word)
        {
            Trie current = this;

            foreach (var c in word)
            {
                if (current.branches[c - 'a'] == null)
                {
                    current.branches[c - 'a'] = new Trie();
                }
                
                current = current.branches[c - 'a'];
            }

            current.isEnd = true;
        }

        public bool Search(string word)
        {
            var current = this;

            foreach (var c in word)
            {
                var element = current.branches[c - 'a'];

                if (element == null)
                {
                    return false;
                }

                current = element;
            }

            return current.isEnd;
        }

        public bool StartsWith(string prefix)
        {
            var current = this;

            foreach (var c in prefix)
            {
                var element = current.branches[c - 'a'];

                if (element == null)
                {
                    return false;
                }

                current = element;
            }

            return true;
        }
    }

    /// <summary>
    /// 211. Design Add and Search Words Data Structure
    /// </summary>
    public class WordDictionary
    {
        Dictionary<int, List<string>> stringBuilder = new Dictionary<int, List<string>>();
        public WordDictionary()
        {
            for (int i = 1; i <= 25; i++)
            {
                stringBuilder.Add(i, new List<string>());
            }
        }

        public void AddWord(string word)
        {
            stringBuilder[word.Length].Add(word);
        }

        public bool Search(string word)
        {
            var n = word.Length;
            foreach (var v in stringBuilder[n])
            {
                for (int i = 0; i < n; i++)
                {
                    if (v[i] != word[i] && word[i] != '.')
                    {
                        break;
                    }

                    if (i + 1 == n)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }

    /// <summary>
    /// 225. Implement Stack using Queues
    /// </summary>
    public class MyStack225
    {
        private Queue<int> que1;
        private Queue<int> que2;
        private int count = 0;

        public MyStack225()
        {
            que1 = new();
            que2 = new();
        }

        public void Push(int x)
        {
            que1.Enqueue(x);
            count++;
        }

        public int Pop()
        {
            var n = 0;
            while (n < count - 1)
            {
                que2.Enqueue(que1.Dequeue());
                n++;
            }
            count--;

            var ans = que1.Dequeue();
            que1 = que2;
            que2 = new();

            return ans;
        }

        public int Top()
        {
            var n = 0;
            while (n < count - 1)
            {
                que2.Enqueue(que1.Dequeue());
                n++;
            }

            var ans = que1.Dequeue();
            que2.Enqueue(ans);
            que1 = que2;
            que2 = new();

            return ans;
        }

        public bool Empty()
        {
            return que1.Count == 0;
        }
    }

    public static class _0200_0299
    {
        /// <summary>
        /// 201. Bitwise AND of Numbers Range
        /// </summary>
        public static int RangeBitwiseAnd(int left, int right)
        {
            if (left == right)
            {
                return left;
            }
            else if (Math.Abs(left - right) == 1)
            {
                return left & right;
            }
            else
            {
                var array = new BitArray(32);
                var isDifferent = false;

                for (int i = 31; i >= 0; i--)
                {
                    if (!isDifferent && IsBitSet(left, i) == IsBitSet(right, i))
                    {
                        array.Set(i, IsBitSet(left, i));
                    }
                    else
                    {
                        isDifferent = true;
                        array.Set(i, false);
                    }

                }

                int[] intArray = new int[1];
                array.CopyTo(intArray, 0);
                return intArray[0];
            }

            bool IsBitSet(int b, int pos)
            {
                return (b & (1 << pos)) != 0;
            }
        }

        /// <summary>
        /// 202. Happy Number. Tags: Hash Table, Math, Two Pointers
        /// </summary>
        public static bool IsHappy(int n)
        {
            var unique = new HashSet<double>();
            double result = n;

            while (result != 1)
            {
                if (!unique.Add(result))
                {
                    return false; 
                }

                result = result.ToString().ToCharArray().Select(c => Math.Pow(Char.GetNumericValue(c), 2)).Sum();
            }

            return true;
        }

        /// <summary>
        /// 203. Remove Linked List Elements
        /// </summary>
        public static ListNode RemoveElements(ListNode head, int val)
        {
            while (head != null && head.val == val)
            {
                head = head.next;
            }

            var current = head;
            var result = new ListNode
            {
                next = current
            };

            return new ListNode();
        }

        /// <summary>
        /// 205. Isomorphic Strings. Tags: Hash Table, String
        /// </summary>
        public static bool IsIsomorphic(string s, string t)
        {
            var dict = new Dictionary<char, char>();
            var hash = new HashSet<char>();

            for (int i = 0; i < s.Length; i++)
            {
                var sChar = s[i];
                var tChar = t[i];

                if (!dict.TryGetValue(sChar, out char dictChar))
                {
                    dict[sChar] = tChar;
                    if (!hash.Add(tChar))
                    {
                        return false;
                    }
                }
                else
                {
                    if (dictChar != tChar)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 206. Reverse Linked List
        /// </summary>
        public static ListNode ReverseList(ListNode head)
        {
            if (head == null)
            {
                return head;
            }

            var value = head.val;
            var current = new ListNode(value);

            while (head.next != null)
            {
                var temp = new ListNode(head.next.val, current);
                current = temp;
                head = head.next;
            }

            return current;
        }

        /// <summary>
        /// 209. Minimum Size Subarray Sum. Tags: 
        /// </summary>
        public static int MinSubArrayLen(int target, int[] nums)
        {
            var subArrayLength = nums.Length + 1;
            var currentSum = 0;

            int left = 0;
            int right = 0;

            while (right < nums.Length)
            {
                currentSum += nums[right];

                while (currentSum >= target)
                {
                    subArrayLength = Math.Min(subArrayLength, right - left + 1);

                    currentSum -= nums[left];
                    left++;
                }

                right++;
            }

            return subArrayLength == nums.Length + 1 ? 0 : subArrayLength;
        }

        /// <summary>
        /// 215. Kth Largest Element in an Array
        /// </summary>
        public static int FindKthLargest(int[] nums, int k)
        {
            System.Array.Sort(nums, new Comparison<int>((i1, i2) => i1.CompareTo(i2)));

            return nums[nums.Length - k];
        }

        /// <summary>
        /// 217. Contains Duplicate
        /// </summary>
        public static bool ContainsDuplicate(int[] nums)
        {
            return nums.GroupBy(n => n).Any(n => n.Count() > 1);
        }

        /// <summary>
        /// 219. Contains Duplicate II. Tags: Array, Hash Table, Sliding Window
        /// </summary>
        public static bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            var dict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var value = nums[i];

                if (!dict.TryGetValue(value, out int index))
                {
                    dict.Add(value, i);
                }
                else
                {
                    if (i - index <= k)
                    {
                        return true;
                    }
                    else
                    {
                        dict[value] = i;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 220. Contains Duplicate III. Tags: Array, Sliding Window, Sorting, Bucket Sort, Ordered Set
        /// </summary>
        public static bool ContainsNearbyAlmostDuplicate(int[] nums, int indexDiff, int valueDiff)
        {


            return true;
        }

        /// <summary>
        /// 226. Invert Binary Tree
        /// </summary>
        public static TreeNode InvertTree(TreeNode root)
        {
            var queue = new Queue<TreeNode>();

            if (root != null)
            {
                queue.Enqueue(root);
            }

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                var temp = current.left;
                current.left = current.right;
                current.right = temp;

                if (current.left != null)
                {
                    queue.Enqueue(current.left);
                }

                if (current.right != null)
                {
                    queue.Enqueue(current.right);
                }
            }

            return root;
        }

        /// <summary>
        /// 229. Majority Element II
        /// </summary>
        public static IList<int> MajorityElement(int[] nums)
        {
            var n1 = int.MinValue;
            var n1count = 0;

            var n2 = int.MinValue;
            var n2count = 0;

            foreach (int num in nums)
            {
                if (num == n1)
                {
                    n1count++;
                }
                else if (num == n2)
                {
                    n2count++;
                }
                else if (n1count == 0)
                {
                    n1 = num;
                    n1count = 1;
                }
                else if (n2count == 0)
                {
                    n2 = num;
                    n2count = 1;
                }
                else
                {
                    n1count--;
                    n2count--;
                }
            }

            n1count = n2count = 0;
            foreach (int num in nums)
            {
                if (num == n1) n1count++;
                if (num == n2) n2count++;
            }

            int threshold = nums.Length / 3;

            IList<int> result = new List<int>();
            if (n1count > threshold) result.Add(n1);
            if (n2count > threshold && n1 != n2) result.Add(n2);

            return result;
        }

        /// <summary>
        /// 230. Kth Smallest Element in a BST
        /// </summary>
        public static int KthSmallest(TreeNode root, int k)
        {
            int i = 0, solution = 0;

            void DFSinorder(TreeNode node)
            {
                if (node == null) return;

                DFSinorder(node.left);
                i++;

                if (i == k)
                {
                    solution = node.val;
                }

                DFSinorder(node.right);
            }

            DFSinorder(root);
            return solution;
        }

        /// <summary>
        /// 231. Power of Two
        /// </summary>
        public static bool IsPowerOfTwo(int n)
        {
            return (n > 0) && (n & (n - 1)) == 0;
        }

        /// <summary>
        /// 234. Palindrome Linked List
        /// </summary>
        public static bool IsPalindrome(ListNode head)
        {
            var list = new List<int>();

            while (head != null)
            {
                list.Add(head.val);
                head = head.next;
            }

            var n = list.Count;
            var array = list.ToArray();
            for (int i = 0; i < n / 2; i++)
            {
                if (array[i] != array[n - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 238. Product of Array Except Self
        /// </summary>
        public static int[] ProductExceptSelf(int[] nums)
        {
            var multi = 1;
            var hasZero = false;
            var result = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                var value = nums[i];
                if (value == 0)
                {
                    if (hasZero)
                    {
                        return result;
                    }

                    hasZero = true;
                }
                else
                {
                    multi *= value;
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                var value = nums[i];

                if (value == 0)
                {
                    result[i] = multi;
                }
                else if (hasZero)
                {
                    result[i] = 0;
                }
                else
                {
                    result[i] = multi / value;
                }
            }

            return result;
        }

        /// <summary>
        /// 239. Sliding Window Maximum
        /// </summary>
        public static int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (nums.Length == 0 || k == 0)
            {
                return new int[0];
            }

            int n = nums.Length;
            int[] result = new int[n - k + 1];
            int ri = 0; // Index for the result array

            LinkedList<int> deque = new LinkedList<int>();
            for (int i = 0; i < n; i++)
            {
                while (deque.Count > 0 && deque.First.Value < i - k + 1)
                {
                    deque.RemoveFirst();
                }

                while (deque.Count > 0 && nums[deque.Last.Value] < nums[i])
                {
                    deque.RemoveLast();
                }

                deque.AddLast(i);
                if (i >= k - 1)
                {
                    result[ri++] = nums[deque.First.Value];
                }
            }

            return result;
        }

        /// <summary>
        /// 241. Different Ways to Add Parentheses
        /// </summary>
        public static IList<int> DiffWaysToCompute(string expression)
        {
            var res = new List<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                char oper = expression[i];
                if (oper == '+' || oper == '-' || oper == '*')
                {
                    var s1 = DiffWaysToCompute(expression[..i]);
                    var s2 = DiffWaysToCompute(expression[(i + 1)..]);
                    foreach (int a in s1)
                    {
                        foreach (int b in s2)
                        {
                            if (oper == '+')
                            {
                                res.Add(a + b);
                            }
                            else if (oper == '-')
                            {
                                res.Add(a - b);
                            }
                            else if (oper == '*')
                            { 
                                res.Add(a * b);
                            }
                        }
                    }
                }
            }

            if (res.Count == 0)
            {
                res.Add(Int32.Parse(expression));
            }

            return res;
        }

        /// <summary>
        /// 257. Binary Tree Paths
        /// </summary>
        public static IList<string> BinaryTreePaths(TreeNode root)
        {
            if (root == null)
            {
                return new List<string>();
            }

            var result = new List<string>();

            Analyse(root, new List<int>());

            void Analyse(TreeNode node, List<int> ints)
            {
                var newInts = new List<int>(ints)
                {
                    node.val
                };

                if (node.right != null)
                {
                    Analyse(node.right, newInts);
                }

                if (node.left != null)
                {
                    Analyse(node.left, newInts);
                }

                if (node.left == null && node.right == null)
                {
                    result.Add(string.Join("->", newInts.ToArray()));
                }
            }

            return result;
        }

        /// <summary>
        /// 258. Add Digits
        /// </summary>
        public static int AddDigits(int num)
        {
            var result = num;
            while (result > 9)
            {
                result = Convert.ToInt32(result.ToString().ToArray().Sum(x => Char.GetNumericValue(x)));
            }
            return result;

            //if (num == 0) return 0;
            //if (num % 9 == 0) return 9;
            //return num % 9;
        }

        /// <summary>
        /// 268. Missing Number
        /// </summary>
        public static int MissingNumber(int[] nums)
        {
            Array.Sort(nums);
            for (int i = 0; i < nums.Length; i++)
            {
                if (i != nums[i])
                {
                    return i;
                }
            }

            return nums.Length;
        }

        /// <summary>
        /// 274. H-Index
        /// </summary>
        public static int HIndex(int[] citations)
        {
            var n = citations.Length;

            System.Array.Sort(citations);

            int h = n;
            while (h > 0)
            {
                var value = citations[n - h];

                if (value >= h)
                {
                    return h;
                }
                h--;
            }

            return 0;
        }

        /// <summary>
        /// 278. First Bad Version
        /// </summary>
        public static int FirstBadVersion(int n)
        {
            long left = 1, right = n;
            while (left < right)
            {
                var mid = (left + right) / 2;
                var isBad = IsBadVersion((int)mid);
                if (isBad)
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return (int)left;



            bool IsBadVersion(int version)
            {
                return true;
            }
        }

        /// <summary>
        /// 279. Perfect Squares
        /// </summary>
        public static int NumSquares(int n)
        {
            var dp = new int[n + 1];
            dp[0] = 0;
            dp[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                var min = int.MaxValue;

                for (int j = 1; j * j <= i; j++)
                {
                    int rem = i - j * j;
                    if (dp[rem] < min)
                    {
                        min = dp[rem];
                    }
                }

                dp[i] = min + 1;
            }

            return dp[n];
        }

        public static void MoveZeroes(int[] nums)
        {
            var zeroCount = 0;
            var nonZeroList = new List<int>();

            foreach (var num in nums)
            {
                if (num != 0)
                {
                    nonZeroList.Add(num);
                }
                else
                {
                    zeroCount++;
                }
            }

            int i = 0;
            foreach (var num in nonZeroList)
            {
                nums[i] = num;
                i++;
            }

            for (int y = i; y < nums.Length; y++)
            {
                nums[y] = 0;
            }
        }

        /// <summary>
        /// 287. Find the Duplicate Number
        /// </summary>
        public static int FindDuplicate(int[] nums)
        {
            var hash = new HashSet<int>();
            foreach (int num in nums)
            {
                if (!hash.Add(num))
                {
                    return num;
                }
            }

            throw new ArgumentException(nameof(nums));
        }

        /// <summary>
        /// 290. Word Pattern. Tags: Hash Table, String
        /// </summary>
        public static bool WordPattern(string pattern, string s)
        {
            var pArray = pattern.ToCharArray();
            var pLength = pArray.Length;

            var sArray = s.Split(' ').ToArray();
            var sLength = sArray.Length;

            if (pLength != sLength)
            {
                return false;
            }

            var dict = new Dictionary<char, string>();
            var unique = new HashSet<string>();

            for (int i = 0; i < pLength; i++)
            {
                var pChar = pArray[i];
                var sValue = sArray[i];

                if (!dict.TryGetValue(pChar, out string value))
                {
                    dict[pChar] = sValue;

                    if (!unique.Add(sValue))
                    {
                        return false;
                    }
                }
                else
                {
                    if (value != sValue)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 292. Nim Game
        /// </summary>
        public static bool CanWinNim(int n)
        {
            return n % 4 > 0;
        }
    }
}
