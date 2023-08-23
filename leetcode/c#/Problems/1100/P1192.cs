namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/critical-connections-in-a-network/
///    Submission: https://leetcode.com/submissions/detail/702048630/
/// </summary>
internal class P1192
{
  public class Solution
  {
    public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections)
    {
      var visited = new bool[n];
      var tin = new int[n];
      var low = new int[n];

      Array.Fill(tin, -1);
      Array.Fill(low, -1);

      var adj = new Dictionary<int, List<int>>();
      foreach (var connection in connections)
      {
        var from = connection[0];
        var to = connection[1];

        if (!adj.ContainsKey(from)) adj[from] = new List<int>();
        if (!adj.ContainsKey(to)) adj[to] = new List<int>();

        adj[from].Add(to);
        adj[to].Add(from);
      }

      // Tarjan bridges algo

      var ans = new List<IList<int>>();

      for (int i = 0; i < n; ++i)
      {
        if (!visited[i])
        {
          dfs(i, -1, adj, visited, tin, low, 0, ans);
        }
      }

      return ans;
    }

    private void dfs(int v, int p, Dictionary<int, List<int>> connections, bool[] visited, int[] tin, int[] low, int timer, List<IList<int>> ans)
    {
      visited[v] = true;

      tin[v] = low[v] = timer;

      foreach (var to in connections[v])
      {
        if (to == p) continue;

        if (visited[to])
        {
          low[v] = Math.Min(low[v], tin[to]);
        }
        else
        {
          dfs(to, v, connections, visited, tin, low, timer + 1, ans);
          low[v] = Math.Min(low[v], low[to]);

          if (low[to] > tin[v])
          {
            ans.Add(new List<int> { v, to });
          }
        }
      }
    }
  }
}
