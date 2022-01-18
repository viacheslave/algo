using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/paint-house-ii/
  ///    Submission: https://leetcode.com/submissions/detail/451653211/
  ///    Walmart Labs  
  /// </summary>
  internal class P0265
  {
    public class Solution
    {
      public int MinCostII(int[][] costs)
      {
        if (costs.Length == 0)
          return 0;

        var k = costs[0].Length;

        var dp = new int[costs.Length, k];

        for (var i = 0; i < k; i++)
          dp[0, i] = costs[0][i];

        for (var house = 1; house < costs.Length; house++)
        {
          for (var color = 0; color < k; color++)
          {
            var min = int.MaxValue;

            for (var color_prev = 0; color_prev < k; color_prev++)
              if (color != color_prev)
                min = Math.Min(min, dp[house - 1, color_prev]);

            dp[house, color] = min + costs[house][color];
          }
        }

        var ans = int.MaxValue;

        for (var color = 0; color < k; color++)
          ans = Math.Min(ans, dp[costs.Length - 1, color]);

        return ans;
      }
    }
  }
}
