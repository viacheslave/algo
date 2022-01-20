package binarysearch;

import java.util.ArrayList;
import java.util.Arrays;

/*
 * Problem: https://binarysearch.com/problems/Perfect-Squares
 * Submission: https://binarysearch.com/problems/Perfect-Squares/submissions/7332092
 */
public class P0094 {
  class Solution {
    public int solve(int n) {
      var squares = new ArrayList<Integer>();

      for (var i = 1; i * i <= n; i++) {
        squares.add(i * i);
      }

      var ans = 0;

      var dp = new int[n + 1];
      Arrays.fill(dp, Integer.MAX_VALUE);
      dp[0] = 0;

      // 0-1 knapsack dp
      // O(n * sqrt(n))
      for (var sum = 0; sum <= n; sum++) {
        for (Integer sq : squares) {
          if (sum - sq >= 0) {
            dp[sum] = Math.min(dp[sum], dp[sum - sq] + 1);
          }
        }
      }

      ans = dp[n];
      return ans;
    }
  }
}