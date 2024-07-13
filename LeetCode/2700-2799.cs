using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class _2700_2799
    {
        /// <summary>
        /// 2706. Buy Two Chocolates
        /// </summary>
        public static int BuyChoco(int[] prices, int money)
        {
            System.Array.Sort(prices);

            var result = money - prices[0] - prices[1];

            if (result >= 0)
            {
                return result;
            }

            return money;
        }

        /// <summary>
        /// 2751. Robot Collisions
        /// </summary>
        public static IList<int> SurvivedRobotsHealths(int[] positions, int[] healths, string directions)
        {
            var robots = new (int, int, char, int)[positions.Length];
            for (int i = 0; i < positions.Length; i++)
            {
                robots[i] = (positions[i], healths[i], directions[i], i);
            }

            robots = robots.OrderBy(x => x.Item1).ToArray();
            var sur = new List<(int, int, char, int)>();
            var currentR = new Stack<(int, int, char, int)>();

            foreach (var robot in robots)
            {
                var curRobot = robot;
                var isBroken = false;

                if (curRobot.Item3 == 'R')
                {
                    currentR.Push(curRobot);
                    continue;
                }

                if (currentR.Count == 0) //  && curRobot.Item3 == 'L'
                {
                    sur.Add(curRobot);
                    continue;
                }

                while (currentR.Count > 0 && !isBroken)
                {
                    var curR = currentR.Pop();

                    if (curR.Item2 == curRobot.Item2)
                    {
                        isBroken = true;
                    }
                    else if (curR.Item2 < curRobot.Item2)
                    {
                        curRobot.Item2 -= 1;
                    }
                    else
                    {
                        curR.Item2 -= 1;
                        isBroken = true;
                        currentR.Push(curR);
                    }
                }

                if (!isBroken)
                {
                    sur.Add(curRobot);
                }
            }

            sur.AddRange(currentR);
            return sur.OrderBy(e => e.Item4).Select(e => e.Item2).ToList();
        }
    }
}
