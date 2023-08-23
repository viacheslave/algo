namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/node-with-highest-edge-score/
///    Submission: https://leetcode.com/submissions/detail/773460730/
/// </summary>
internal class P2374
{
  public class Solution
  {
    public int EdgeScore(int[] edges)
    {
      var map = new Dictionary<int, long>();

      for (int i = 0; i < edges.Length; i++)
        map[edges[i]] = map.GetValueOrDefault(edges[i], 0) + i;

      return map
        .OrderByDescending(x => x.Value)
        .ThenBy(x => x.Key)
        .First()
        .Key;
    }
  }
}
