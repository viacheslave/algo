package binarysearch;

/*
 * Problem: https://binarysearch.com/problems/Minimum-Dropping-Path-Sum-With-Column-Distance-Constraint
 * Submission: https://binarysearch.com/problems/Minimum-Dropping-Path-Sum-With-Column-Distance-Constraint/submissions/7094084
 */
public class P0908 {
  class Solution {
    public int solve(int[][] matrix) {
      var rows = matrix.length;
      var cols = matrix[0].length;

      var dp = new int[rows][cols];
      System.arraycopy(matrix[0], 0, dp[0], 0, cols);

      for (int i = 1; i < rows; i++) {
        for (int j = 0; j < cols; j++) {
          if (j == 0) {
            dp[i][j] = Math.min(dp[i - 1][j], dp[i - 1][j + 1]);
          }
          else if (j == cols - 1) {
            dp[i][j] = Math.min(dp[i - 1][j], dp[i - 1][j - 1]);
          }
          else {
            dp[i][j] = Math.min(dp[i - 1][j], Math.min(dp[i - 1][j - 1], dp[i - 1][j + 1]));
          }

          dp[i][j] += matrix[i][j];
        }
      }

      var ans = Integer.MAX_VALUE;
      for (int i = 0; i < cols; i++) {
        ans = Math.min(ans, dp[rows - 1][i]);
      }

      return ans;
    }
  }
}