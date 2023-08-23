namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/count-unreachable-pairs-of-nodes-in-an-undirected-graph/
///    Submission: https://leetcode.com/submissions/detail/731135950/
/// </summary>
internal class P2316
{
  public class Solution
  {
    public long CountPairs(int n, int[][] edges)
    {
      // dfs to find the number of the islands
      // then calculate pair-wise count

      var ans = 0L;

      // adj list
      var adj = new Dictionary<int, List<int>>();

      foreach (var edge in edges)
      {
        if (!adj.ContainsKey(edge[0]))
          adj[edge[0]] = new List<int>();

        if (!adj.ContainsKey(edge[1]))
          adj[edge[1]] = new List<int>();

        adj[edge[0]].Add(edge[1]);
        adj[edge[1]].Add(edge[0]);
      }

      var visited = new int[n];
      var islands = new List<int>();

      foreach (var i in adj.Keys)
      {
        if (visited[i] == 1)
        {
          continue;
        }

        var dfs = DFS(adj, visited, i);

        islands.Add(dfs);
      }

      for (var i = 0; i < islands.Count - 1; i++)
      {
        for (var j = i + 1; j < islands.Count; j++)
        {
          ans += 1L * islands[i] * islands[j];
        }
      }

      // add islands with a single node

      var singleNodes = n - adj.Count;

      // inter-connections
      if (singleNodes > 1)
      {
        ans += 1L * singleNodes * (singleNodes - 1) / 2;
      }

      // single node - to islands
      ans += 1L * singleNodes * islands.Sum();

      return ans;
    }

    private int DFS(Dictionary<int, List<int>> adj, int[] visited, int node)
    {
      if (visited[node] == 1)
        return 0;

      visited[node] = 1;

      var res = 1;

      foreach (var a in adj.GetValueOrDefault(node, new List<int>()))
      {
        res += DFS(adj, visited, a);
      }

      return res;
    }
  }
}
