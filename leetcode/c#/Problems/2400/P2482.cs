namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/difference-between-ones-and-zeros-in-row-and-column/
///    Submission: https://leetcode.com/problems/difference-between-ones-and-zeros-in-row-and-column/submissions/850625367/
/// </summary>
internal class P2482
{
  public class Solution
  {
    public int[][] OnesMinusZeros(int[][] grid)
    {
      var m = grid.Length;
      var n = grid[0].Length;

      var onesRow = new int[m];
      var onesCol = new int[n];

      for (int i = 0; i < m; i++)
        for (int j = 0; j < n; j++)
          onesRow[i] += grid[i][j];

      for (int j = 0; j < n; j++)
        for (int i = 0; i < m; i++)
          onesCol[j] += grid[i][j];

      var ans = new int[m][];

      for (int i = 0; i < m; i++)
      {
        ans[i] = new int[n];
        for (int j = 0; j < n; j++)
        {
          ans[i][j] = onesRow[i] + onesCol[j] - (m - onesRow[i]) - (n - onesCol[j]);
        }
      }

      return ans;
    }
  }
}
