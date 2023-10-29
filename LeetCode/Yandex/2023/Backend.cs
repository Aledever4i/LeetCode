using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Yandex._2023
{
    public class Backend
    {
        //static void Main(string[] args)
        //{
        //    ArtCritic();
        //}

        private static void ArtCritic()
        {
            var parameters = Console.ReadLine().Split(" ");
            var param1 = parameters[0];
            var param2 = parameters[1];

            var critic = Console.ReadLine().Split(" ").Select(val => int.Parse(val)).Where(val => val > 0).ToArray();
            double result = 0;
            var count = critic.Length;

            var multiLen = int.Parse(param1) + int.Parse(param2);
            var multiple = new int[multiLen];

            for (int i = 0; i < count; i++)
            {
                var element = critic[i];
                result += Math.Pow(element, 2);
                result += element * multiple[i];

                for (int y = i + 1; y < count && y < i + 1 + element; y++)
                {
                    multiple[y]++;
                }
            }

            Console.WriteLine(result);
        }

        private static void Hokky()
        {
            var somestring = Console.ReadLine();
            var result = somestring;

            var len = somestring.Length;
            if (len == 9)
            {
                Console.WriteLine("YandexCup");
                return;
            }

            var dictYandex = new Dictionary<int, int>();
            var dictCup = new Dictionary<int, int>();
            char Y, a, n, d, e, x, C, u, p;

            Y = somestring[0];
            a = somestring[1];
            n = somestring[2];
            d = somestring[3];
            e = somestring[4];
            x = somestring[5];

            var sum = (Y == 'Y' ? 1 : 0) + (a == 'a' ? 1 : 0) + (n == 'n' ? 1 : 0) + (d == 'd' ? 1 : 0) + (e == 'e' ? 1 : 0) + (x == 'x' ? 1 : 0);
            dictYandex.Add(0, sum);

            C = somestring[6];
            u = somestring[7];
            p = somestring[8];

            sum = (C == 'C' ? 1 : 0) + (u == 'u' ? 1 : 0) + (p == 'p' ? 1 : 0);
            dictCup.Add(6, sum);

            for (int i = 1; i <= somestring.Length - 9; i++)
            {
                var lastChar = somestring[i + 5];

                Y = a;
                a = n;
                n = d;
                d = e;
                e = x;
                x = lastChar;

                sum = (Y == 'Y' ? 1 : 0) + (a == 'a' ? 1 : 0) + (n == 'n' ? 1 : 0) + (d == 'd' ? 1 : 0) + (e == 'e' ? 1 : 0) + (x == 'x' ? 1 : 0);
                dictYandex.Add(i, sum);
            }

            for (int i = 7; i <= somestring.Length - 3; i++)
            {
                var lastChar = somestring[i + 2];

                C = u;
                u = p;
                p = lastChar;

                sum = (C == 'C' ? 1 : 0) + (u == 'u' ? 1 : 0) + (p == 'p' ? 1 : 0);
                dictCup.Add(i, sum);
            }

            var dictYandexValues = dictYandex.OrderByDescending(value => value.Value).OrderBy(val => val.Key).Where(value => value.Value >= 1);
            var dictCupValues = dictCup.OrderByDescending(value => value.Value).OrderBy(val => val.Key).Where(value => value.Value >= 1);
            var minChange = int.MaxValue;
            var yIndex = 0;
            var cIndex = 0;

            var dictYandexValuesCount = dictYandexValues.Count();

            for (int i = 0; i < dictYandexValuesCount; i++)
            {
                var valueYandex = dictYandexValues.ElementAt(i);

                if (valueYandex.Key + 8 < len)
                {
                    var cup = dictCupValues.Where(val => val.Key > valueYandex.Key + 5).FirstOrDefault();
                    var changeCount = 0;

                    if (cup.Equals(default(KeyValuePair<int, int>)))
                    {
                        changeCount = 6 - valueYandex.Value + 3;
                    }
                    else
                    {
                        changeCount = 6 - valueYandex.Value + 3 - cup.Value;
                    }

                    if (minChange > changeCount)
                    {
                        minChange = changeCount;
                        yIndex = valueYandex.Key;
                        cIndex = cup.Key;
                    }

                    if (minChange == 0)
                    {
                        break;
                    }
                }
            }

            result = result.Remove(yIndex, 6).Insert(yIndex, "Yandex");
            result = result.Remove(cIndex, 3).Insert(cIndex, "Cup");
            Console.WriteLine(result);
        }

        private static void Market()
        {
            var lines = int.Parse(Console.ReadLine());

            var priorityQueueForSell = new PriorityQueue<(int, int, int), int>();
            var priorityQueueForBuy = new PriorityQueue<(int, int, int), int>();
            var history = new Dictionary<int, string>();
            var historyId = 1;

            string type = "";
            string action = "";
            int price = 0;
            int count = 0;

            for (int i = 0; i < lines; i++)
            {
                var command = Console.ReadLine().Split(" ");
                type = command[0];

                if (type == "ADD")
                {
                    action = command[1];
                    price = int.Parse(command[2]);
                    count = int.Parse(command[3]);

                    if (action == "BUY")
                    {
                        while (priorityQueueForSell.Count > 0 && priorityQueueForSell.Peek().Item1 <= price && count > 0)
                        {
                            var element = priorityQueueForSell.Dequeue();
                            var amount = element.Item2 - count;

                            if (amount > 0)
                            {
                                historyId++;
                                priorityQueueForSell.Enqueue((element.Item1, amount, historyId), int.MaxValue - price);
                            }
                            else if (amount == 0)
                            {
                            }
                            else
                            {
                                count = Math.Abs(amount);
                            }
                        }

                        if (count > 0)
                        {
                            historyId++;
                            priorityQueueForBuy.Enqueue((price, count, historyId), price);
                        }
                    }
                    else
                    {
                        while (priorityQueueForBuy.Count > 0 && priorityQueueForBuy.Peek().Item1 >= price && count > 0)
                        {
                            var element = priorityQueueForBuy.Dequeue();
                            var amount = element.Item2 - count;

                            //if (amount > 0)
                            //{
                            //    priorityQueueForSell.Enqueue((element.Item1, amount), int.MaxValue - price);
                            //    history.Add(historyId, "");
                            //    historyId++;
                            //}
                            //else if (amount == 0)
                            //{
                            //    history.Add(historyId, "");
                            //    historyId++;
                            //}
                            //else
                            //{
                            //    history.Add(historyId, "");
                            //    historyId++;
                            //    count = Math.Abs(amount);
                            //}
                        }

                        if (count > 0)
                        {
                            historyId++;
                            priorityQueueForSell.Enqueue((price, count, historyId), -price);
                        }
                    }
                }
                else
                {
                    action = "";
                    price = 0;
                    count = 0;

                    if (action == "GET")
                    {
                        foreach (var e in priorityQueueForSell.UnorderedItems.OrderByDescending(v => v.Element.Item1).OrderByDescending(v => v.Element.Item3))
                        {
                            Console.WriteLine($"{e.Element.Item3} SELL {e.Element.Item1} {e.Element.Item2}");
                        }

                        foreach (var e in priorityQueueForBuy.UnorderedItems.OrderBy(v => v.Element.Item1).OrderBy(v => v.Element.Item3))
                        {
                            Console.WriteLine($"{e.Element.Item3} BUY {e.Element.Item1} {e.Element.Item2}");
                        }
                    }
                    else if (action == "SHOW_OPERATIONS")
                    {

                    }
                    else if (action == "DELETE")
                    {
                        var foundId = int.Parse(command[1]);

                        if (priorityQueueForSell.UnorderedItems.Where(item => item.Element.Item3 == foundId).Any())
                        {
                            var tempList = new List<(int, int, int)>();

                            while (priorityQueueForSell.Count > 0)
                            {
                                var item = priorityQueueForSell.Dequeue();

                                if (item.Item3 == foundId)
                                {
                                    break;
                                }

                                tempList.Add(item);
                            }

                            foreach (var e in tempList)
                            {
                                priorityQueueForSell.Enqueue(e, -e.Item1);
                            }

                            Console.WriteLine("DELETED");
                        }
                        else if (priorityQueueForBuy.UnorderedItems.Where(item => item.Element.Item3 == foundId).Any())
                        {
                            var tempList = new List<(int, int, int)>();

                            while (priorityQueueForBuy.Count > 0)
                            {
                                var item = priorityQueueForBuy.Dequeue();

                                if (item.Item3 == foundId)
                                {
                                    break;
                                }

                                tempList.Add(item);
                            }

                            foreach (var e in tempList)
                            {
                                priorityQueueForBuy.Enqueue(e, e.Item1);
                            }

                            Console.WriteLine("DELETED");
                        }
                        else
                        {
                            Console.WriteLine("NOT FOUND");
                        }
                    }
                }
            }       
        }
    }
}