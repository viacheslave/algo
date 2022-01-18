package binarysearch;

import java.util.Arrays;
import java.util.stream.Collectors;

/*
 * Problem: https://binarysearch.com/problems/Longest-Fibonacci-Subsequence
 * Submission: https://binarysearch.com/problems/Longest-Fibonacci-Subsequence/submissions/6646236
 */
public class P0907 {
  class Solution {
    public int solve(int[][] matrix) {
      var rows = matrix.length;
      var cols = matrix[0].length;

      var dp = new int[rows][cols];
      System.arraycopy(matrix[0], 0, dp[0], 0, cols);

      for (int i = 1; i < rows; i++) {
        var minLeft = new int[cols];
        var minRight = new int[cols];

        // calculate prefix minimums at each row
        minLeft[0] = dp[i - 1][0];
        minRight[cols - 1] = dp[i - 1][cols - 1];

        for (int j = 1; j < cols - 1; j++) {
          minLeft[j] = Math.min(minLeft[j - 1], dp[i - 1][j]);
          minRight[cols - 1 - j] = Math.min(minRight[cols - j], dp[i - 1][cols - 1 - j]);
        }

        for (int j = 0; j < cols; j++) {
          if (j == 0) {
            dp[i][j] = minRight[j + 1];
          }
          else if (j == cols - 1) {
            dp[i][j] = minLeft[j - 1];
          }
          else {
            dp[i][j] = Math.min(minLeft[j - 1], minRight[j + 1]);
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