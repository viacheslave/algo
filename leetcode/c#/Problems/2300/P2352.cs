namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/equal-row-and-column-pairs/
///    Submission: https://leetcode.com/submissions/detail/756977336/
/// </summary>
internal class P2352
{
  public class Solution
  {
    public int EqualPairs(int[][] grid)
    {
      var m = grid.Length;
      var n = grid[0].Length;

      var hashedRows = new List<int>();
      var hashedCols = new List<int>();

      for (int i = 0; i < m; i++)
      {
        var hash = 0;

        for (int j = 0; j < n; j++)
        {
          unchecked
          {
            hash = (hash * 397) ^ grid[i][j];
          }
        }

        hashedRows.Add(hash);
      }

      for (int j = 0; j < n; j++)
      {
        var hash = 0;

        for (int i = 0; i < m; i++)
        {
          unchecked
          {
            hash = (hash * 397) ^ grid[i][j];
          }
        }

        hashedCols.Add(hash);
      }

      var ans = 0;

      for (var i = 0; i < hashedRows.Count; i++)
      {
        var row = hashedRows[i];
        for (var j = 0; j < hashedCols.Count; j++)
        {
          var col = hashedCols[j];
          if (row == col)
          {
            if (Equal(grid, i, j))
            {
              ans++;
            }
          }
        }
      }

      return ans;
    }

    private bool Equal(int[][] grid, int r, int c)
    {
      for (var i = 0; i < grid.Length; i++)
      {
        if (grid[r][i] != grid[i][c])
          return false;
      }

      return true;
    }
  }
}
