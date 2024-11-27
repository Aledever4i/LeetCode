using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Algorithms
{
    public static class DijkstraAlgorithm
    {
        public static void FindShortestPath(
            Dictionary<string, Dictionary<string, int>> graph,
            Dictionary<string, int> costs,
            Dictionary<string, string?> parents
        )
        {
            var visited = new HashSet<string>();
            var lowestCostUnvisitedNode = FindLowestCostUnvisitedNode(costs, visited);
            while (lowestCostUnvisitedNode != null)
            {
                var cost = costs[lowestCostUnvisitedNode];
                var neighbors = graph[lowestCostUnvisitedNode];

                foreach (var neighbor in neighbors)
                {
                    var newCost = cost + neighbor.Value;
                    if (newCost < costs[neighbor.Key])
                    {
                        costs[neighbor.Key] = newCost;
                        parents[neighbor.Key] = lowestCostUnvisitedNode;
                    }
                }

                visited.Add(lowestCostUnvisitedNode);
                lowestCostUnvisitedNode = FindLowestCostUnvisitedNode(costs, visited);
            }
        }

        private static string FindLowestCostUnvisitedNode(Dictionary<string, int> costs, HashSet<string> visited)
        {
            var cost = costs
                .Where(node => !visited.Contains(node.Key))
                .OrderBy(node => node.Value)
                .FirstOrDefault();

            return cost.Key;
        }

        public static string ConstructFinalRoute(Dictionary<string, string?> parents)
        {
            var route = new List<string>();
            var currentNode = "Finish";

            while (currentNode != null)
            {
                route.Add(currentNode);
                currentNode = parents.GetValueOrDefault(currentNode);
            }

            route.Reverse();
            return string.Join("=>", route);
        }
    }
}
