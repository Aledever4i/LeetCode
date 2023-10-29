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
            var lines = int.Parse(Console.ReadLine());

            var priorityQueueForSell = new PriorityQueue<(decimal, int, int), decimal>();
            var priorityQueueForBuy = new PriorityQueue<(decimal, int, int), decimal>();
            var history = new List<string>();
            var historyId = 0;

            string type = "";
            string action = "";
            decimal price = 0;
            int count = 0;

            for (int i = 0; i < lines + 1; i++)
            {
                var command = Console.ReadLine().Split(" ");
                type = command[0];

                if (type == "ADD")
                {
                    action = command[1];
                    price = Convert.ToDecimal(command[2], new CultureInfo("en-US"));
                    count = int.Parse(command[3]);

                    if (action == "BUY")
                    {
                        historyId++;
                        Console.WriteLine(historyId);

                        while (priorityQueueForSell.Count > 0 && priorityQueueForSell.Peek().Item1 <= price && count > 0)
                        {
                            var element = priorityQueueForSell.Dequeue();
                            var amount = element.Item2 - count;

                            if (amount > 0)
                            {
                                priorityQueueForSell.Enqueue((element.Item1, amount, element.Item3), -price);
                                history.Add($"{historyId} {element.Item3} {element.Item1.ToString().Replace(',', '.')} {count}");
                                count = 0;
                            }
                            else if (amount == 0)
                            {
                                history.Add($"{historyId} {element.Item3} {element.Item1.ToString().Replace(',', '.')} {count}");
                                count = 0;
                            }
                            else
                            {
                                count = Math.Abs(amount);
                                history.Add($"{historyId} {element.Item3} {element.Item1.ToString().Replace(',', '.')} {element.Item2}");
                            }
                        }

                        if (count > 0)
                        {
                            priorityQueueForBuy.Enqueue((price, count, historyId), price);
                        }
                    }
                    else
                    {
                        historyId++;
                        Console.WriteLine(historyId);

                        while (priorityQueueForBuy.Count > 0 && priorityQueueForBuy.Peek().Item1 >= price && count > 0)
                        {
                            var element = priorityQueueForBuy.Dequeue();
                            var amount = element.Item2 - count;

                            if (amount > 0)
                            {
                                priorityQueueForSell.Enqueue((element.Item1, amount, element.Item3), -price);
                                history.Add($"{historyId} {element.Item3} {element.Item1.ToString().Replace(',', '.')} {count}");
                                count = 0;
                            }
                            else if (amount == 0)
                            {
                                history.Add($"{historyId} {element.Item3} {element.Item1.ToString().Replace(',', '.')} {count}");
                                count = 0;
                            }
                            else
                            {
                                count = Math.Abs(amount);
                                history.Add($"{historyId} {element.Item3} {element.Item1.ToString().Replace(',', '.')} {element.Item2}");
                            }
                        }

                        if (count > 0)
                        {
                            priorityQueueForSell.Enqueue((price, count, historyId), -price);
                        }
                    }
                }
                else
                {
                    action = "";
                    price = 0;
                    count = 0;

                    if (type == "GET")
                    {
                        foreach (var e in priorityQueueForSell.UnorderedItems.OrderByDescending(v => v.Element.Item1).OrderByDescending(v => v.Element.Item3))
                        {
                            Console.WriteLine($"{e.Element.Item3} SELL {e.Element.Item1.ToString().Replace(',', '.')} {e.Element.Item2}");
                        }

                        foreach (var e in priorityQueueForBuy.UnorderedItems.OrderBy(v => v.Element.Item1).OrderBy(v => v.Element.Item3))
                        {
                            Console.WriteLine($"{e.Element.Item3} BUY {e.Element.Item1.ToString().Replace(',', '.')} {e.Element.Item2}");
                        }
                    }
                    else if (type == "SHOW_OPERATIONS")
                    {
                        var cc = int.Parse(command[1]);

                        for (int hh = history.Count - 1; hh > history.Count - 1 - cc && hh >= 0; hh--)
                        {
                            Console.WriteLine(history.ElementAt(hh));
                        }
                    }
                    else if (type == "DELETE")
                    {
                        var foundId = int.Parse(command[1]);

                        if (priorityQueueForSell.UnorderedItems.Where(item => item.Element.Item3 == foundId).Any())
                        {
                            var tempList = new List<(decimal, int, int)>();

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
                            var tempList = new List<(decimal, int, int)>();

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