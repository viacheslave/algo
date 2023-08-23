namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/maximum-total-importance-of-roads/
///    Submission: https://leetcode.com/submissions/detail/712043605/
/// </summary>
internal class P2285
{
  public class Solution
  {
    public long MaximumImportance(int n, int[][] roads)
    {
      var adj = new int[n];

      // greedy
      // max connections = max value

      foreach (var road in roads)
      {
        adj[road[0]]++;
        adj[road[1]]++;
      }

      var ordered = adj.Select((x, i) => (x, i))
        .OrderBy(_ => _.x)
        .ToList();

      var map = new Dictionary<int, int>();

      for (var i = 0; i < ordered.Count; i++)
      {
        map[ordered[i].i] = i + 1;
      }

      var ans = 0L;

      foreach (var road in roads)
      {
        ans += (map[road[0]] + map[road[1]]);
      }

      return ans;
    }
  }

}
