package binarysearch;

import java.util.Arrays;

/*
 * Problem: https://binarysearch.com/problems/Stepping-Numbers
 * Submission: https://binarysearch.com/problems/Stepping-Numbers/submissions/7093616
 */
public class P0490 {
  class Solution {
    public int solve(int n) {
      int mod = (int)1e9+7;
      if (n == 0) return 0;
      if (n == 1) return 10;

      var dp = new int[n][10];

      for (int i = 1; i <= 9; i++) {
        dp[0][i] = 1;
      }

      for (int i = 1; i < n; i++) {
        for (int j = 0; j <= 9; j++) {
          if (j == 0) {
            dp[i][j] = dp[i - 1][1];
            continue;
          }
          if (j == 9) {
            dp[i][j] = dp[i - 1][8];
            continue;
          }
          dp[i][j] += dp[i - 1][j - 1];
          dp[i][j] %= mod;

          dp[i][j] += dp[i - 1][j + 1];
          dp[i][j] %= mod;
        }
      }

      var ans = 0;
      for (int i = 0; i <= 9; i++) {
        ans += dp[n - 1][i];
        ans %= mod;
      }

      return ans;
    }
  }
}