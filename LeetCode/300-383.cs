using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class _300_383
    {
        /// <summary>
        /// 383. Ransom Note. Tags: Hash Table, String, Counting
        /// </summary>
        /// <param name="ransomNote"></param>
        /// <param name="magazine"></param>
        /// <returns></returns>
        public static bool CanConstruct(string ransomNote, string magazine)
        {
            var ransomList = ransomNote.ToCharArray().ToList();

            foreach (char i in magazine)
            {
                ransomList.Remove(i);
            }

            return !ransomList.Any();
        }
    }
}
