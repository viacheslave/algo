using System;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/june-leetcoding-challenge-2021/604/week-2-june-8th-june-14th/3775/
  /// 
  /// </summary>
  internal class Jun11
  {
    public class Solution
    {
      public int StoneGameVII(int[] stones)
      {
        // DP is difference
        var dp = new int[stones.Length, stones.Length];
        var dpcalc = new bool[stones.Length, stones.Length];

        var prefix = new int[stones.Length + 1];

        for (var i = 0; i < stones.Length; i++)
          prefix[i + 1] = prefix[i] + stones[i];

        DP(0, stones.Length - 1, dp, dpcalc, prefix, stones);
        return dp[0, stones.Length - 1];
      }

      private int DP(int left, int right, int[,] dp, bool[,] dpcalc, int[] prefix, int[] stones)
      {
        if (dpcalc[left, right])
          return dp[left, right];

        if (right - left == 0)
          return 0;

        // every player tries to mazimize its score
        // which is sum of remainging stones minus DP of other player's best move
        var value = Math.Max(
          prefix[right + 1 - 1] - prefix[left] - DP(left, right - 1, dp, dpcalc, prefix, stones),
          prefix[right + 1] - prefix[left + 1] - DP(left + 1, right, dp, dpcalc, prefix, stones)
        );

        dpcalc[left, right] = true;
        dp[left, right] = value;

        return value;
      }
    }
  }
}
