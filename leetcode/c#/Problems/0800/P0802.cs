namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/find-eventual-safe-states/
///    Submission: https://leetcode.com/problems/find-eventual-safe-states/submissions/865732178/
/// </summary>
internal class P0802
{
  public class Solution
  {
    public IList<int> EventualSafeNodes(int[][] graph)
    {
      var adj = GetAdj(graph);

      var nodes = new int[graph.Length];

      for (int i = 0; i < nodes.Length; i++)
      {
        var stack = new Stack<int>();
        var visited = new HashSet<int>();

        DFS(i, adj, nodes, stack, visited);
      }

      return nodes.Select((n, i) => (n, i))
        .Where(d => d.n == 1)
        .Select(d => d.i)
        .ToList();
    }

    private void DFS(int node, Dictionary<int, HashSet<int>> adj, int[] nodes, Stack<int> stack, HashSet<int> visited)
    {
      if (visited.Contains(node))
      {
        // mark all stack as unsafe
        foreach (var item in stack)
        {
          nodes[item] = -1;
        }

        return;
      }

      if (adj[node].Count == 0)
      {
        nodes[node] = 1;
        return;
      }

      stack.Push(node);
      visited.Add(node);

      var safe = true;

      foreach (var child in adj[node])
      {
        if (nodes[child] == 0)
        {
          DFS(child, adj, nodes, stack, visited);
        }

        if (nodes[child] == -1)
        {
          nodes[node] = -1;
          return;
        }

        safe = safe && (nodes[child] == 1);
      }

      if (safe)
      {
        nodes[node] = 1;
      }

      stack.Pop();
    }

    private Dictionary<int, HashSet<int>> GetAdj(int[][] graph)
    {
      var ans = new Dictionary<int, HashSet<int>>();

      for (int i = 0; i < graph.Length; i++)
      {
        ans[i] = graph[i].ToHashSet();
      }

      return ans;
    }
  }

}
