package binarysearch;

import java.util.HashMap;

/*
 * Problem: https://binarysearch.com/problems/Collecting-Coins
 * Submission: https://binarysearch.com/problems/Collecting-Coins/submissions/7315008
 */
public class P0013 {
  class Solution {
    public int solve(int[][] matrix) {
      if (matrix.length == 0)
        return 0;

      var n = matrix.length;
      var m = matrix[0].length;

      var dp = new int[n][m];

      for (int i = 0; i < n; i++) {
        for (int j = 0; j < m; j++) {
          dp[i][j] = Integer.MIN_VALUE;
        }
      }

      // recursive
      rec(matrix, n - 1, m - 1, dp);

      return dp[n - 1][m - 1];
    }

    private int rec(int[][] matrix, int i, int j, int[][] dp) {
      if (i < 0 || j < 0)
        return 0;

      if (dp[i][j] != Integer.MIN_VALUE)
        return dp[i][j];

      var value = matrix[i][j] +  Math.max(
        rec(matrix, i-1, j, dp),
        rec(matrix, i, j-1, dp));

      dp[i][j] = value;
      return value;
    }
  }
}