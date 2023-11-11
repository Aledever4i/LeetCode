using LeetCode.Contest;
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
            //var result = new Graph2642(4, new int[27][] {
            //    new int[] {11,6,84715 },
            //    new int[] { 7,9,764823},
            //    new int[] { 6,0,315591},
            //    new int[] { 1,4,909432},
            //    new int[] { 6,5,514907},
            //    new int[] { 9,6,105610},
            //    new int[] {3,10,471042 },
            //    new int[] {7,10,348752 },
            //    new int[] {5,11,715628 },
            //    new int[] { 6,1,973999},
            //    new int[] { 8,7,593929},
            //    new int[] {7,6,64688 },
            //    new int[] { 6,4,741734},
            //    new int[] { 10,1,894247},
            //    new int[] { 9,7,81181},
            //    new int[] { 2,11,75418},
            //    new int[] {12,2,85431 },
            //    new int[] { 7,2,260306},
            //    new int[] {11,9,640614 },
            //    new int[] {2,3,648804 },
            //    new int[] { 4,12,568023},
            //    new int[] { 0,8,730096},
            //    new int[] {9,11,633474 },
            //    new int[] {3,6,390214 },
            //    new int[] { 1,10,117955},
            //    new int[] {9,8,222602 },
            //    new int[] { 10,7,689294}
            //});

            //result.AddEdge(new int[] { 1, 2, 36450 });
            //result.AddEdge(new int[] { 8, 0, 709628 });
            //result.AddEdge(new int[] { 2, 4, 30185 });
            //result.AddEdge(new int[] { 12, 1, 21696 });
            //result.AddEdge(new int[] { 1, 8, 2553 });
            //result.AddEdge(new int[] { 4, 6, 2182 });
            //result.AddEdge(new int[] { 7, 5, 206 });
            //result.AddEdge(new int[] { 5, 7, 140 });
            //result.AddEdge(new int[] { 12, 6, 365184 });
            //result.AddEdge(new int[] { 3, 2, 5 });
            //result.AddEdge(new int[] { 0, 11, 5 });
            //result.AddEdge(new int[] { 1, 7, 5 });

            var result = new Graph2642(1, new int[0][] { });
            var a = result.ShortestPath(0, 0);
            Console.WriteLine(a);



            //var a = result.ShortestPath(3, 2);
            //a = result.ShortestPath(0, 3);
            //var a = result.ShortestPath(11, 11);
            Console.WriteLine(a); 
            
            a = result.ShortestPath(7, 4);
            Console.WriteLine(a);

            a = result.ShortestPath(0, 12);
            Console.WriteLine(a);

            //a = result.ShortestPath(11, 11);
            //Console.WriteLine(a);

            //a = result.ShortestPath(11, 11);
            //Console.WriteLine(a);
        }
    }
}

//[[]],[[]],[0,8],[],[7,4],[0,12],[[3,9,858944]],[[0,9,4]],[3,5],[4,5],[12,9],[9,8],[3,5],[[12,9,629052]],[3,8],[[4,0,545201]],[11,8],[4,11],[9,6],[[12,7,4]],[7,10],[2,5],[6,11],[12,2],[9,7],[[4,3,879736]],[1,3],[1,0],[4,6]]