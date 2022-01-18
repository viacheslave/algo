package binarysearch;

/*
 * Problem: https://binarysearch.com/problems/Broker-of-Wall-Street
 * Submission: https://binarysearch.com/problems/Broker-of-Wall-Street/submissions/7088378
 */
public class P0457 {
  class Solution {
    public int solve(int[] prices,int fee) {
      if (prices.length == 0)
        return 0;

      var dp = new int[prices.length][2];

      // first day
      dp[0][0] = 0;
      dp[0][1] = -prices[0];

      for (int i = 1; i < prices.length; i++) {
        // do nothing on ith day or sell with fee
        dp[i][0] = Math.max(dp[i - 1][0], dp[i - 1][1] + prices[i] - fee);

        // do nothing on ith day or buy
        dp[i][1] = Math.max(dp[i - 1][1], dp[i - 1][0] - prices[i]);
      }

      return dp[prices.length - 1][0];
    }
  }
}