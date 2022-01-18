using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///   https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/589/week-3-march-15th-march-21st/3674/
  ///   
  /// </summary>
  internal class Mar16
  {
    public class Solution
    {
      public int MaxProfit(int[] prices, int fee)
      {
        int n = prices.Length;

        if (n == 0)
          return 0;

        int[,] dp = new int[n, 2];

        for (int i = 0; i < n; i++)
          dp[i, 0] = dp[i, 1] = (int)-1e5;

        dp[0, 0] = 0;
        dp[0, 1] = -prices[0];

        for (int d = 1; d < n; d++)
        {
          dp[d, 0] = Math.Max(dp[d - 1, 0], dp[d - 1, 1] + prices[d] - fee);
          dp[d, 1] = Math.Max(dp[d - 1, 1], dp[d - 1, 0] - prices[d]);
        }

        int res = dp[n - 1, 0];
        return res;
      }
    }
  }
}
