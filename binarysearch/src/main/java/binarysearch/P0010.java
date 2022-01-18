package binarysearch;

import java.util.Stack;

/*
 * Problem: https://binarysearch.com/problems/A-Flight-of-Stairs
 * Submission: https://binarysearch.com/problems/A-Flight-of-Stairs/submissions/6951363
 */
public class P0010 {
  class Solution {
    public int solve(int n) {
      var dp = new int[n + 1];
      dp[0] = 1;
      dp[1] = 1;

      var mod = (int) 1e9 + 7;

      for (int i = 2; i <= n; i++) {
        dp[i] = (dp[i - 1] + dp[i - 2]) % mod;
      }

      return dp[n];
    }
  }
}