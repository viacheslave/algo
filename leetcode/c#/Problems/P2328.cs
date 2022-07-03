namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/number-of-increasing-paths-in-a-grid/
///    Submission: https://leetcode.com/submissions/detail/737281604/
/// </summary>
internal class P2328
{
  public class Solution
  {
    public int CountPaths(int[][] grid)
    {
      var mod = (int)1e9 + 7;

      var cells = new List<(int x, int y, int value)>();
      var n = grid.Length;
      var m = grid[0].Length;

      for (int i = 0; i < n; i++)
      {
        for (int j = 0; j < m; j++)
        {
          cells.Add((i, j, grid[i][j]));
        }
      }

      cells = cells.OrderBy(x => x.value).ToList();

      // DP
      // Order cells by value
      // Calculate number of paths ending with dp[i,j] cell gradually
      // The ans is the sum of all dp[i,j]

      var dp = new int[n, m];
      var ans = 0;

      foreach (var cell in cells)
      {
        var c = 1;

        var neib = new int[4][]
        {
        new int[] { 0, 1 },
        new int[] { 0, -1 },
        new int[] { 1, 0 },
        new int[] { -1, 0 },
        };

        foreach (var nei in neib)
        {
          var point = (x: cell.x + nei[0], y: cell.y + nei[1]);
          if (point.x < 0 || point.y < 0 || point.x >= n || point.y >= m)
            continue;

          if (grid[point.x][point.y] >= cell.value)
            continue;

          c += dp[point.x, point.y];
          c %= mod;
        }

        dp[cell.x, cell.y] = c;

        ans += c;
        ans %= mod;
      }

      return ans;
    }
  }

}
