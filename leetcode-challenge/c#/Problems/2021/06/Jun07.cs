using System;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/june-leetcoding-challenge-2021/603/week-1-june-1st-june-7th/3770/
  /// 
  /// </summary>
  internal class Jun07
  {
    public class Solution
    {
      public int MinCostClimbingStairs(int[] cost)
      {
        var dp = new int[cost.Length + 1];

        dp[0] = 0;
        dp[1] = cost[cost.Length - 1];

        for (var i = 2; i <= cost.Length; i++)
        {
          dp[i] = Math.Min(
              cost[cost.Length - i] + dp[i - 1],
              cost[cost.Length - i] + dp[i - 2]
          );
        }

        return Math.Min(dp[cost.Length - 1], dp[cost.Length]);
      }
    }
  }
}
