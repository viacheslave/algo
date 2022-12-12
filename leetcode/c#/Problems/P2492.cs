namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimum-score-of-a-path-between-two-cities/
///    Submission: https://leetcode.com/problems/minimum-score-of-a-path-between-two-cities/submissions/854379819/
/// </summary>
internal class P2492
{
  public class Solution
  {
    public int MinScore(int n, int[][] roads)
    {
      var adj = GetAdjList(roads, 1, n);

      var visited = new HashSet<int>();
      visited.Add(n);

      var min = int.MaxValue;

      var stack = new Stack<int>();
      stack.Push(1);

      // DFS, stack
      while (stack.TryPop(out var node))
      {
        if (visited.Contains(node))
          continue;

        visited.Add(node);

        foreach (var (next, cost) in adj[node])
        {
          min = Math.Min(min, cost);

          if (!visited.Contains(next))
          {
            stack.Push(next);
          }
        }
      }

      return min;
    }

    private Dictionary<int, List<(int next, int cost)>> GetAdjList(int[][] edges, int from, int to)
    {
      var adj = new Dictionary<int, List<(int, int)>>();

      for (int i = from; i <= to; i++)
        adj[i] = new List<(int, int)>();

      foreach (var edge in edges)
      {
        adj[edge[0]].Add((edge[1], edge[2]));
        adj[edge[1]].Add((edge[0], edge[2]));
      }

      return adj;
    }
  }
}
