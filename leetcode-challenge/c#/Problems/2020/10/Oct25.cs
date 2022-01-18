using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/october-leetcoding-challenge/562/week-4-october-22nd-october-28th/3507/
  ///    https://leetcode.com/submissions/detail/412904088/?from=/explore/challenge/card/october-leetcoding-challenge/562/week-4-october-22nd-october-28th/3507/
  /// </summary>
  internal class Oct25
  {
    public class Solution
    {
      public bool WinnerSquareGame(int n)
      {
        var dp = new bool[n + 1];
        dp[1] = true;

        for (var i = 1; i <= n; ++i)
        {
          for (int j = 1; j * j <= i; ++j)
          {
            dp[i] = dp[i] | (!dp[i - j * j]);
          }
        }

        return dp[n];
      }
    }
  }
}
