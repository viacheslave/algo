namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/maximum-star-sum-of-a-graph/
///    Submission: https://leetcode.com/problems/maximum-star-sum-of-a-graph/submissions/859348810/
/// </summary>
internal class P2497
{
  public class Solution
  {
    public int MaxStarSum(int[] vals, int[][] edges, int k)
    {
      var list = GetAdjList(edges, vals.Length);

      var ans = int.MinValue;

      foreach (var kvp in list)
      {
        var sorted = kvp.Value
            .Select(f => vals[f])
            .OrderByDescending(c => c).ToList();

        ans = Math.Max(ans, vals[kvp.Key]);

        var sum = vals[kvp.Key];
        for (var i = 0; i < sorted.Count; i++)
        {
          if (i == k)
            break;

          sum += sorted[i];
          ans = Math.Max(ans, sum);
        }
      }

      return ans;
    }

    private static Dictionary<int, List<int>> GetAdjList(int[][] edges, int count)
    {
      var list = new Dictionary<int, List<int>>();

      for (var i = 0; i < count; i++)
      {
        list[i] = new List<int>();
      }

      foreach (var edge in edges)
      {
        list[edge[0]].Add(edge[1]);
        list[edge[1]].Add(edge[0]);
      }

      return list;
    }
  }
}
