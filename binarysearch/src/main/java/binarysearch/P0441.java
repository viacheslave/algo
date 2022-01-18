package binarysearch;

import java.util.ArrayList;
import java.util.Comparator;

/*
 * Problem: https://binarysearch.com/problems/Bear-of-Wall-Street
 * Submission: https://binarysearch.com/problems/Bear-of-Wall-Street/submissions/7088323
 */
public class P0441 {
  class Solution {
    public int solve(int[] prices) {
      if (prices.length == 0)
        return 0;

      var dp = new int[prices.length][2];

      // first day
      dp[0][0] = 0;
      dp[0][1] = -prices[0];

      for (int i = 1; i < prices.length; i++) {
        // do nothing on ith day or sell
        dp[i][0] = Math.max(dp[i - 1][0], dp[i - 1][1] + prices[i]);

        if (i < 2) {
          // do nothing or buy
          // first two days are without restrictions
          dp[i][1] = Math.max(dp[i - 1][1], dp[i - 1][0] - prices[i]);
        }
        else {
          // do nothing or buy
          // cannot buy looking at the ith-1 day
          dp[i][1] = Math.max(dp[i - 1][1], dp[i - 2][0] - prices[i]);;
        }
      }

      return dp[prices.length - 1][0];
    }
  }
}