using System.Numerics;

namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/paths-in-matrix-whose-sum-is-divisible-by-k/
///    Submission: https://leetcode.com/problems/paths-in-matrix-whose-sum-is-divisible-by-k/submissions/818537341/
/// </summary>
internal class P2435
{
  public class Solution
  {
    public int NumberOfPaths(int[][] grid, int k)
    {
      // bottom-up DP
      var m = grid.Length;
      var n = grid[0].Length;
      var mod = (int)1e9 + 7;

      var dp = new int[m, n, k];
      dp[0, 0, grid[0][0] % k] = 1;

      for (int i = 0; i < m; i++)
      {
        for (int j = 0; j < n; j++)
        {
          // left
          if (j > 0)
          {
            for (int l = 0; l < k; l++)
            {
              dp[i, j, (l + grid[i][j]) % k] += dp[i, j - 1, l];
              dp[i, j, (l + grid[i][j]) % k] %= mod;
            }
          }

          // top
          if (i > 0)
          {
            for (int l = 0; l < k; l++)
            {
              dp[i, j, (l + grid[i][j]) % k] += dp[i - 1, j, l];
              dp[i, j, (l + grid[i][j]) % k] %= mod;
            }
          }
        }
      }

      return dp[m - 1, n - 1, 0];
    }
  }
}
