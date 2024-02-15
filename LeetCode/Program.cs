using LeetCode.Contest;
using LeetCode.PinaevSon;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new WordDictionary();
            a.AddWord("a");
            a.AddWord("a");
            a.Search(".");
            a.Search("a");
            a.Search("aa");
            a.Search("a");
            a.Search(".a");
            a.Search("a.");


            Console.WriteLine(a);


            //a = result.ShortestPath(11, 11);

            //a = result.ShortestPath(11, 11);
            //Console.WriteLine(a);
        }
    }
}