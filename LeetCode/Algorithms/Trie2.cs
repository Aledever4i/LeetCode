using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Algorithms.Trie2
{
    public class Trie2
    {
        private static readonly int ALPHABET_SIZE = 26;
        private readonly TrieNode2 root = new();
        public long countPrefixSuffixPairs;

        public void AddWord(string word)
        {
            TrieNode2 current = root;
            int prefix = 0;
            int suffix = word.Length - 1;

            while (prefix < word.Length && suffix >= 0)
            {
                int hashPrefixSuffix = GetHashForPrefixSuffixPair(word[prefix], word[suffix]);
                current.branches.TryAdd(hashPrefixSuffix, new TrieNode2());
                current = current.branches[hashPrefixSuffix];
                countPrefixSuffixPairs += current.frequency;
                ++prefix;
                --suffix;
            }
            ++current.frequency;
        }

        private int GetHashForPrefixSuffixPair(char prefix, char suffix)
        {
            return (prefix - 'a') * ALPHABET_SIZE + (suffix - 'a');
        }
    }

    public class TrieNode2
    {
        public int frequency = 0;
        public Dictionary<int, TrieNode2> branches = [];
    }
}
