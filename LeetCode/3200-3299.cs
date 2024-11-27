using System;
using System.Collections.Generic;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LeetCode
{
    public static class _3200_3299
    {
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
