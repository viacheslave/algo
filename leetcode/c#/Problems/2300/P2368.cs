namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/reachable-nodes-with-restrictions/
///    Submission: https://leetcode.com/submissions/detail/773267838/
/// </summary>
internal class P2368
{
  public class Solution
  {
    public int ReachableNodes(int n, int[][] edges, int[] restricted)
    {
      var visited = new HashSet<int>();
      var rest = restricted.ToHashSet();

      var adj = new Dictionary<int, List<int>>();
      foreach (var edge in edges)
      {
        if (!adj.ContainsKey(edge[0])) adj[edge[0]] = new List<int>();
        if (!adj.ContainsKey(edge[1])) adj[edge[1]] = new List<int>();

        adj[edge[0]].Add(edge[1]);
        adj[edge[1]].Add(edge[0]);
      }

      var stack = new Stack<int>();
      stack.Push(0);

      while (stack.Count > 0)
      {
        var node = stack.Pop();
        visited.Add(node);

        foreach (var a in adj[node])
        {
          if (visited.Contains(a))
            continue;

          if (rest.Contains(a))
            continue;

          stack.Push(a);
        }
      }

      return visited.Count;
    }
  }
}
