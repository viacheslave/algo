namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimum-lines-to-represent-a-line-chart/
///    Submission: https://leetcode.com/submissions/detail/705311762/
/// </summary>
internal class P2280
{
  public class Solution
  {
    public int MinimumLines(int[][] stockPrices)
    {
      if (stockPrices.Length == 1)
        return 0;

      stockPrices = stockPrices.OrderBy(x => x[0]).ToArray();

      var tans = new decimal[stockPrices.Length - 1];

      for (var i = 1; i < stockPrices.Length; i++)
      {
        var p2 = stockPrices[i];
        var p1 = stockPrices[i - 1];

        tans[i - 1] = 1m * (p2[1] - p1[1]) / (1m * (p2[0] - p1[0]));
      }

      var ans = 1;

      for (var i = 1; i < tans.Length; i++)
      {
        var t1 = tans[i - 1];
        var t2 = tans[i];

        if (t1 != t2)
        {
          ans++;
        }
      }

      return ans;
    }
  }

}
