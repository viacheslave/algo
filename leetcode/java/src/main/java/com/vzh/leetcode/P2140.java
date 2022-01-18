package com.vzh.leetcode;

import java.util.Arrays;

/*
 * Problem: https://leetcode.com/problems/solving-questions-with-brainpower/
 * Submission: https://leetcode.com/submissions/detail/621225075/
 */
class P2140 {
  class Solution {
    public long mostPoints(int[][] questions) {
      var n = questions.length;
      var dp = new long[n];

      for (var i = n - 1; i >= 0; i--) {
        var q = questions[i];

        if (i == n - 1) {
          dp[n - 1] = q[0];
          continue;
        }

        dp[i] = Math.max(
          dp[i + 1],
          q[0] + (i + q[1] + 1 < n ? dp[i + q[1] + 1] : 0)
        );
      }

      return dp[0];
    }
  }
}