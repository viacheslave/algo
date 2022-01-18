package binarysearch;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.stream.Collectors;

/*
 * Problem: https://binarysearch.com/problems/Increasing-Digits
 * Submission: https://binarysearch.com/problems/Increasing-Digits/submissions/7100781
 */
public class P0472 {
  class Solution {
    public int solve(int n) {
      var dp = new int[n][9];

      for (int i = 0; i < 9; i++) {
        dp[0][i] = 1;
      }

      for (int i = 1; i < n; i++) {
        for (int j = 0; j < 9; j++) {
          for (int k = 0; k < j; k++) {
            dp[i][j] += dp[i - 1][k];
          }
        }
      }

      var ans = 0;
      for (int i = 0; i < 9; i++) {
        ans += dp[n - 1][i];
      }

      return ans;
    }
  }
}