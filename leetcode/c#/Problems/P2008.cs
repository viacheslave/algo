namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/maximum-earnings-from-taxi/
///    Submission: https://leetcode.com/submissions/detail/572119066/
/// </summary>
internal class P2008
{
  public class Solution
  {
    public long MaxTaxiEarnings(int n, int[][] rides)
    {
      var data = rides.Select(x =>
          (from: x[0], to: x[1], tip: x[2], profit: x[1] - x[0] + x[2]))
        .GroupBy(x => x.to)
        .ToDictionary(x => x.Key, x => x.ToList());

      var dp = new long[n + 1];

      for (var i = 1; i <= n; i++)
      {
        // if there's no ride end point
        // we set max to prev point
        if (!data.ContainsKey(i))
        {
          dp[i] = dp[i - 1];
          continue;
        }

        // iterate over all rides` end points
        // pick maximum
        long value = dp[i - 1];
        foreach (var item in data[i])
          value = Math.Max(value, dp[i - (item.to - item.from)] + item.profit);

        dp[i] = value;
      }

      return dp[n];
    }
  }
}
