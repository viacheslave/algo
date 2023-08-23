namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/paint-house-iii/
///    Submission: https://leetcode.com/problems/paint-house-iii/submissions/868161760/
/// </summary>
internal class P1473
{
  public class Solution
  {
    public int MinCost(int[] houses, int[][] cost, int m, int n, int target)
    {
      // dp
      // neighborhoods, index, color
      var dp = new int[m + 1, m + 1, n + 1];

      // init
      for (var i = 0; i < m + 1; i++)
        for (var j = 0; j < m; j++)
          for (var k = 0; k < n + 1; k++)
            dp[i, j, k] = int.MaxValue;

      for (int i = 1; i <= n; i++)
        dp[1, 0, i] = houses[0] == 0 ? cost[0][i - 1] : 0;

      var pcolors = (-1, -1);
      var ncolors = (-1, -1);

      for (var index = 1; index < m; index++)
      {
        // limit colors range 
        // pcolors is one if prev house is already painted
        // ncolors is one if current house is already painted

        pcolors = houses[index - 1] == 0
          ? (1, n)
          : (houses[index - 1], houses[index - 1]);

        ncolors = houses[index] == 0
          ? (1, n)
          : (houses[index], houses[index]);

        for (var ncolor = ncolors.Item1; ncolor <= ncolors.Item2; ncolor++)
        {
          // paint house[index] with color
          // iterate over dp[index-1]

          for (var pneighb = 1; pneighb <= index; pneighb++)
          {
            for (var pcolor = pcolors.Item1; pcolor <= pcolors.Item2; pcolor++)
            {
              var nneighb = pneighb + (ncolor != pcolor ? 1 : 0);

              // irrelevant
              if (nneighb > target)
                continue;

              // wrong path
              if (dp[pneighb, index - 1, pcolor] == int.MaxValue)
                continue;

              var paintCost = (ncolor == houses[index]) ? 0 : cost[index][ncolor - 1];

              dp[nneighb, index, ncolor] = Math.Min(
                dp[nneighb, index, ncolor],
                dp[pneighb, index - 1, pcolor] + paintCost);
            }
          }
        }
      }

      // check target
      var ans = int.MaxValue;

      for (int color = 1; color <= n; color++)
        ans = Math.Min(ans, dp[target, m - 1, color]);

      return (ans == int.MaxValue) ? -1 : ans;
    }
  }
}
