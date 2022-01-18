package binarysearch;

import java.util.HashMap;

/*
 * Problem: https://binarysearch.com/problems/Dice-Throw
 * Submission: https://binarysearch.com/problems/Dice-Throw/submissions/7304515
 */
public class P0227 {
  class Solution {
    public int solve(int n, int faces, int total) {
      var dp = new int[n + 1][total + 1];
      for (int i = 0; i < n + 1; i++) {
        for (int j = 0; j < total + 1; j++) {
          dp[i][j] = Integer.MIN_VALUE;
        }
      }

      recursive(dp, n, faces, total);
      return dp[n][total] == Integer.MIN_VALUE ? 0 : dp[n][total];
    }

    private int recursive(int[][] dp, int n, int faces, int total) {
      if (n == 1) {
        if (total <= faces) {
          return 1;
        }
        else {
          return 0;
        }
      }

      var mod = (int)1e9 + 7;

      if (dp[n][total] != Integer.MIN_VALUE) {
        return dp[n][total];
      }

      var value = 0;
      for (var i = 1; i <= faces; i++) {
        if (total - i > 0) {
          value += recursive(dp, n - 1, faces, total - i);
          value %= mod;
        }
      }

      dp[n][total] = value;
      return value;
    }
  }
}