package binarysearch;

import java.util.Arrays;

/*
 * Problem: https://binarysearch.com/problems/Non-Adjacent-Combination-Sum
 * Submission: https://binarysearch.com/problems/Non-Adjacent-Combination-Sum/submissions/7114187
 */
public class P0823 {
  class Solution {
    public boolean solve(int[] nums, int k) {
      // modification of 0-1 knapsack
      // DP bottom-up

      var dp = new boolean[nums.length + 1][k + 1];

      // take zero items
      // can build if sum k itself is zero
      for (var i = 0; i < k + 1; i++) {
        dp[0][i] = (i == 0);
      }

      // take first 1 item
      // can build if sum is zero or the only element equals to sum k
      for (var i = 0; i < k + 1; i++) {
        dp[1][i] = (i == 0) || nums[0] == i;
      }

      for (var i = 2; i < nums.length + 1; i++) {
        for (int j = 0; j < k + 1; j++) {
          if (k == 0) {
            // if sum k is zero - can build
            dp[i][j] = true;
          }
          else {
            // check non-negative sum
            // can build if either we take current element and see if can build on i - 2
            // or we don't take current element and see if can build on i - 1
            dp[i][j] = (j - nums[i - 1] >= 0 && dp[i - 2][j - nums[i - 1]])
              || dp[i - 1][j];
          }
        }
      }

      return dp[nums.length][k];
    }
  }
}