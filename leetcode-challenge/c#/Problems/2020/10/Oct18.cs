using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/october-leetcoding-challenge/561/week-3-october-15th-october-21st/3499/
  ///    https://leetcode.com/submissions/detail/410170737/?from=/explore/challenge/card/october-leetcoding-challenge/561/week-3-october-15th-october-21st/3499/
  /// </summary>
  internal class Oct18
  {
    class Solution
    {
      public int MaxProfit(int k, int[] prices)
      {
        if (prices.Length == 0)
          return 0;

        if (2 * k > prices.Length)
        {
          int res = 0;
          for (int i = 1; i < prices.Length; i++)
            res += Math.Max(0, prices[i] - prices[i - 1]);

          return res;
        }

        int[,] dp = new int[k + 1, prices.Length + 1];

        for (int transIndex = 0; transIndex < k; transIndex++)
          dp[transIndex, 0] = 0;

        for (int day = 0; day < prices.Length; day++)
          dp[0, day] = 0;

        for (var transIndex = 1; transIndex <= k; transIndex++)
        {
          for (int day = 1; day < prices.Length; day++)
          {
            var maxProfit = 0;

            for (int prevDay = 0; prevDay < day; prevDay++)
              maxProfit = Math.Max(maxProfit, prices[day] - prices[prevDay] + dp[transIndex - 1, prevDay]);

            dp[transIndex, day] = Math.Max(maxProfit, dp[transIndex, day - 1]);
          }
        }

        return dp[k, prices.Length - 1];
      }
    }
  }
}
