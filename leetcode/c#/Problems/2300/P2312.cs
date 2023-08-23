namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/selling-pieces-of-wood/
///    Submission: https://leetcode.com/submissions/detail/726034020/
/// </summary>
internal class P2312
{
  public class Solution
  {
    public long SellingWood(int m, int n, int[][] prices)
    {
      var pricesMap = prices.ToDictionary(x => (x[0], x[1]), x => x[2]);

      // DP
      // recursive + memo
      var memo = new Dictionary<(int h, int w), long>();
      var ans = Calculate(m, n, pricesMap, memo);

      return ans;
    }

    private long Calculate(int m, int n,
                           Dictionary<(int, int), int> prices, Dictionary<(int h, int w), long> memo)
    {
      if (memo.ContainsKey((m, n)))
      {
        return memo[(m, n)];
      }

      var ans = 0L;

      // walk thru all horizontal cuts
      for (var i = 1; i < m; i++)
      {
        ans = Math.Max(ans,
          Calculate(i, n, prices, memo) + Calculate(m - i, n, prices, memo));
      }

      // walk thru all vertical cuts
      for (var i = 1; i < n; i++)
      {
        ans = Math.Max(ans,
          Calculate(m, i, prices, memo) + Calculate(m, n - i, prices, memo));
      }

      // check exact piece size
      if (prices.ContainsKey((m, n)))
      {
        ans = Math.Max(ans, prices[(m, n)]);
      }

      memo[(m, n)] = ans;
      return ans;
    }
  }
}
