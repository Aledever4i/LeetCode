using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class _400_499
    {
        /// <summary>
        /// 445. Add Two Numbers II. Tags: Linked List, Math, Stack
        /// </summary>
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var firstValue = new List<int>();
            var secondValue = new List<int>();
            var resultList = new List<int>();

            while (l1 != null)
            {
                firstValue.Add(l1.val);
                l1 = l1.next;
            }
            while (l2 != null)
            {
                secondValue.Add(l2.val);
                l2 = l2.next;
            }

            var first = firstValue.Count;
            var second = secondValue.Count;
            var discharge = 0;

            for (int i = 1; i <= Math.Max(first, second); i++)
            {
                var value = 0;
                if (first - i >= 0)
                {
                    value = firstValue[first - i];
                }
                if (second - i >= 0)
                {
                    value += secondValue[second - i];
                }
                if (discharge == 1)
                {
                    value++;
                }

                discharge = value / 10;
                resultList.Add(value % 10);
            }

            if (discharge == 1)
            {
                resultList.Add(1);
            }

            ListNode head = new ListNode(resultList[resultList.Count - 1]);
            var result = head;
            for (int i = 2; i <= resultList.Count; i++)
            {
                head.next = new ListNode(resultList[resultList.Count - i]);
                head = head.next;
            }

            return result;
        }
    }
}
