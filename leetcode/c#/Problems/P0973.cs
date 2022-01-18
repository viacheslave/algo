namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/k-closest-points-to-origin/
///    Submission: https://leetcode.com/submissions/detail/607343118/
/// </summary>
internal class P0973
{
  public class Solution
  {
    public int[][] KClosest(int[][] points, int K)
    {
      var distances = new List<(int, int, double)>();

      foreach (var point in points)
      {
        distances.Add((point[0], point[1], Math.Sqrt((point[0] * point[0]) + (point[1] * point[1]))));
      }

      return distances.OrderBy(item => item.Item3)
        .Take(K)
        .Select(item => new int[] { item.Item1, item.Item2 })
        .ToArray();
    }
  }
}
