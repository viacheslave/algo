using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/paint-house/
  ///    Submission: https://leetcode.com/submissions/detail/451647614/
  ///    Google  
  /// </summary>
  internal class P0256
  {
    public class Solution
    {
      public int MinCost(int[][] costs)
      {
        if (costs.Length == 0)
          return 0;

        var dp = new int[costs.Length, 3];
        dp[0, 0] = costs[0][0];
        dp[0, 1] = costs[0][1];
        dp[0, 2] = costs[0][2];

        for (var house = 1; house < costs.Length; house++)
        {
          for (var color = 0; color < 3; color++)
          {
            var min = int.MaxValue;

            for (var color_prev = 0; color_prev < 3; color_prev++)
              if (color != color_prev)
                min = Math.Min(min, dp[house - 1, color_prev]);

            dp[house, color] = min + costs[house][color];
          }
        }

        var ans = int.MaxValue;

        for (var color = 0; color < 3; color++)
          ans = Math.Min(ans, dp[costs.Length - 1, color]);

        return ans;
      }
    }
  }
}
