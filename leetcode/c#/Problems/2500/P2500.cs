namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/delete-greatest-value-in-each-row/
///    Submission: https://leetcode.com/problems/delete-greatest-value-in-each-row/submissions/862146056/
/// </summary>
internal class P2500
{
  public class Solution
  {
    public int DeleteGreatestValue(int[][] grid)
    {
      var ans = 0;
      var rows = grid.Select(f => f.OrderBy(e => e).ToList()).ToList();

      for (var i = 0; i < grid[0].Length; i++)
      {
        var max = int.MinValue;

        for (var j = 0; j < grid.Length; j++)
          max = Math.Max(max, rows[j][i]);

        ans += max;
      }

      return ans;
    }
  }
}
