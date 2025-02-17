﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    public static class _3200_3299
    {
        /// <summary>
        /// 3222. Find the Winning Player in Coin Game
        /// </summary>
        public static string WinningPlayer(int x, int y)
        {
            var winner = "Bob";

            while (x >= 1 && y >= 4)
            {
                winner = (winner == "Bob") ? "Alice" : "Bob";
                x--;
                y -= 4;
            }

            return winner;
        }

        /// <summary>
        /// 3223. Minimum Length of String After Operations
        /// </summary>
        public static int MinimumLength(string s)
        {
            var array = new int[26];
            foreach (var c in s)
            {
                array[c - 'a']++;
            }

            return array.Where(x => x > 0).Sum(x => x % 2 == 0 ? 2 : 1);
        }

        /// <summary>
        /// 3243. Shortest Distance After Road Addition Queries I
        /// </summary>
        public static int[] ShortestDistanceAfterQueries(int n, int[][] queries)
        {
            List<int> answer = [];
            List<List<int>> adjList = [];

            for (int i = 0; i < n; i++)
            {
                adjList.Add([]);
            }

            for (int i = 0; i < n - 1; i++)
            {
                adjList[i].Add(i + 1);
            }

            foreach (var road in queries)
            {
                int u = road[0];
                int v = road[1];
                adjList[u].Add(v);
                answer.Add(bfs(n, adjList));
            }

            return [.. answer];

            int bfs(int n, List<List<int>> adjList)
            {
                bool[] visited = new bool[n];
                Queue<int> nodeQueue = [];
                nodeQueue.Enqueue(0);
                visited[0] = true;

                int currentLayerNodeCount = 1;
                int nextLayerNodeCount = 0;
                int layersExplored = 0;

                while (nodeQueue.Count > 0)
                {
                    for (int i = 0; i < currentLayerNodeCount; i++)
                    {
                        int currentNode = nodeQueue.Dequeue();

                        if (currentNode == n - 1)
                        {
                            return layersExplored;
                        }

                        foreach (var neighbor in adjList[currentNode])
                        {
                            if (visited[neighbor]) continue;

                            nodeQueue.Enqueue(neighbor);
                            nextLayerNodeCount++;
                            visited[neighbor] = true;
                        }
                    }

                    currentLayerNodeCount = nextLayerNodeCount;
                    nextLayerNodeCount = 0;
                    layersExplored++;
                }

                return -1;
            }
        }

        /// <summary>
        /// 3243. Shortest Distance After Road Addition Queries I
        /// </summary>
        public static int[] ShortestDistanceAfterQueries2(int n, int[][] queries)
        {
            int[] dp = new int[n];
            for (int i = 0; i < n; i++)
            {
                dp[i] = -1;
            }
            List<List<int>> adjList = [];

            for (int i = 0; i < n; i++)
            {
                adjList.Add([]);
            }
            for (int i = 0; i < n - 1; i++)
            {
                adjList[i].Add(i + 1);
            }

            List<int> answer = [];
            foreach (int[] road in queries)
            {
                int u = road[0];
                int v = road[1];

                adjList[u].Add(v);

                answer.Add(findMinDistance(adjList, n, 0, dp));

                for (int i = 0; i < n; i++)
                {
                    dp[i] = -1;
                }
            }

            int[] result = new int[answer.Count];
            for (int i = 0; i < answer.Count; i++)
            {
                result[i] = answer[i];
            }

            return result;

            int findMinDistance(List<List<int>> adjList, int n, int currentNode, int[] dp)
            {
                if (currentNode == n - 1) return 0;

                if (dp[currentNode] != -1) return dp[currentNode];

                int minDistance = n;

                foreach (int neighbor in adjList[currentNode])
                {
                    minDistance = Math.Min(minDistance, findMinDistance(adjList, n, neighbor, dp) + 1);
                }

                return dp[currentNode] = minDistance;
            }
        }

        /// <summary>
        /// 3255. Find the Power of K-Size Subarrays II
        /// </summary>
        public static int[] ResultsArray2(int[] nums, int k)
        {
            if (k == 1)
            {
                return nums;
            }

            var result = new int[nums.Length - k + 1];

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] - 1 == nums[i - 1])
                {
                    if (i - k + 1 >= 0 && result[i - k + 1] != -1)
                    {
                        result[i - k + 1] = nums[i];
                    }
                }
                else
                {
                    var iter = 1;
                    while (iter < k)
                    {
                        if (i - iter < nums.Length - k + 1 && i - iter >= 0)
                        {
                            result[i - iter] = -1;
                        }
                        iter++;

                        if (iter < k && i - iter >= 0 && i - iter < result.Length && result[i - iter] == -1)
                        {
                            break;
                        }
                    }
                }
            }

            return result;
        }
    }
}
