namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/largest-local-values-in-a-matrix/
///    Submission: https://leetcode.com/submissions/detail/773308177/
/// </summary>
internal class P2373
{
  public class Solution
  {
    public int[][] LargestLocal(int[][] grid)
    {
      var n = grid.Length;

      var ans = new int[n - 2][];

      for (var i = 0; i < n - 2; i++)
      {
        ans[i] = new int[n - 2];

        for (var j = 0; j < n - 2; j++)
        {
          var col0 = Math.Max(grid[i][j], Math.Max(grid[i + 1][j], grid[i + 2][j]));
          var col1 = Math.Max(grid[i][j + 1], Math.Max(grid[i + 1][j + 1], grid[i + 2][j + 1]));
          var col2 = Math.Max(grid[i][j + 2], Math.Max(grid[i + 1][j + 2], grid[i + 2][j + 2]));

          var max = Math.Max(col0, Math.Max(col1, col2));

          ans[i][j] = max;
        }
      }

      return ans;
    }
  }
}
