using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class _3300_3399
    {
        /// <summary>
        /// 3304. Find the K-th Character in String Game I
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public static char KthCharacter(int k)
        {
            var s = "abbcbccdbccdcddebccdcddecddedeefbccdcddecddedeefcddedeefdeefeffgbccdcddecddedeefcddedeefdeefeffgcddedeefdeefeffgdeefeffgeffgfgghbccdcddecddedeefcddedeefdeefeffgcddedeefdeefeffgdeefeffgeffgfgghcddedeefdeefeffgdeefeffgeffgfgghdeefeffgeffgfggheffgfgghfgghghhibccdcddecddedeefcddedeefdeefeffgcddedeefdeefeffgdeefeffgeffgfgghcddedeefdeefeffgdeefeffgeffgfgghdeefeffgeffgfggheffgfgghfgghghhicddedeefdeefeffgdeefeffgeffgfgghdeefeffgeffgfggheffgfgghfgghghhideefeffgeffgfggheffgfgghfgghghhieffgfgghfgghghhifgghghhighhihiij"; //generate();

            return s[k-1];

            char nextChar(char a)
            {
                if (a == 'z')
                {
                    return 'a';
                }

                return (char)((int)a + 1);
            }

            string generate()
            {
                var result = new List<char>() { 'a' };

                while (result.Count <= 500)
                {
                    var temp = new List<char>();

                    foreach (var c in result)
                    {
                        temp.Add(nextChar(c));
                    }

                    result.AddRange(temp);
                }

                return string.Join("", result);
            }
        }


        /// <summary>
        /// 3305. Count of Substrings Containing Every Vowel and K Consonants I
        /// </summary>
        public static int CountOfSubstrings(string word, int k)
        {
            var dict = new Dictionary<char, int>
            {
                { 'a', 0 },
                { 'e', 0 },
                { 'i', 0 },
                { 'o', 0 },
                { 'u', 0 }
            };

            var other = 0;
            var multi = 1;
            var start = 0;
            var end = 0;
            var result = 0;

            while (start < word.Length - 4)
            {
                while ((dict['a'] == 0 || dict['e'] == 0 || dict['i'] == 0 || dict['o'] == 0 || dict['u'] == 0) || other < k)
                {
                    if (end == word.Length)
                    {
                        break;
                    }

                    if (dict.ContainsKey(word[end]))
                    {
                        dict[word[end]]++;
                    }
                    else
                    {
                        other++;
                    }
                    end++;
                }

                while (other > k)
                {
                    if (dict.ContainsKey(word[start]))
                    {
                        dict[word[start]]--;
                    }
                    else
                    {
                        other--;
                    }
                    start++;
                    multi = 1;
                }

                while (other == k && dict['a'] > 0 && dict['e'] > 0 && dict['i'] > 0 && dict['o'] > 0 && dict['u'] > 0)
                {
                    while (end < word.Length && dict.ContainsKey(word[end]))
                    {
                        dict[word[end]]++;
                        multi++;
                        end++;
                    }

                    result += multi;

                    while (start < word.Length && dict.ContainsKey(word[start]))
                    {
                        dict[word[start]]--;

                        if (dict[word[start]] > 0)
                        {
                            if (word[start] == word[end - 1])
                            {
                                result += 1;
                            }
                            else
                            {
                                result += multi;
                            }

                            start++;
                        }
                        else
                        {

                            start++;
                            break;
                        }
                    }

                    if (start < word.Length && !dict.ContainsKey(word[start]))
                    {
                        multi = 1;
                        other--;
                        start++;
                    }
                }

                if ((dict['a'] == 0 || dict['e'] == 0 || dict['i'] == 0 || dict['o'] == 0 || dict['u'] == 0) && end >= word.Length)
                {
                    return result;
                }

                if (dict['a'] > 0 && dict['e'] > 0 && dict['i'] > 0 && dict['o'] > 0 && dict['u'] > 0 && other < k && end >= word.Length)
                {
                    return result;
                }
            }

            return result;
        }
    }
}
