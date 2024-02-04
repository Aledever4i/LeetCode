using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.PinaevSon
{
    public static class Example
    {
        public static List<char[]> AllCombinations(char[] list, int k) {
            var result = new List<char[]>();
            var queue = new Queue<List<char>>();
            foreach (var c in list)
            {
                queue.Enqueue(new List<char>() { c });
            }

            while (queue.Count > 0)
            {
                var x = queue.Dequeue();
                if (x.Count == k)
                {
                    result.Add(x.ToArray());
                }
                else
                {
                    foreach (var c in list)
                    {
                        var next = new List<char>(x) { c };
                        queue.Enqueue(next);
                    }
                }
            }

            return result;
        }

        public static void AllCombinationZa499(char[] list, int k)
        {
            Print(list, new char[list.Length], 0, k);

            void Print(char[] list, char[] current, int currentIndex, int k)
            {
                if (currentIndex == k)
                {
                    Console.WriteLine(string.Join("", current));
                }
                else
                {
                    foreach (var c in list)
                    {
                        current[currentIndex] = c;
                        Print(list, current, currentIndex + 1, k);
                    }
                }
            }
        }
    }
}
