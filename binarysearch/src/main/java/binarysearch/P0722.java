package binarysearch;

/*
 * Problem: https://binarysearch.com/problems/Consecutive-Wins
 * Submission: https://binarysearch.com/problems/Consecutive-Wins/submissions/7089989
 */
public class P0722 {
  class Solution {
    public int solve(int n, int k) {
      var mod = (int)1e9 + 7;
      var dp = new int[n + 1][k + 1];
      // 0 - current position
      // 1 - number of consecutive wins ending on current position

      for (int i = 1; i <= n; i++) {
        if (i == 1) {
          dp[1][0] = 1;
          if (k > 0) dp[1][1] = 1;
          continue;
        }

        for (int j = 0; j <= Math.min(i, k); j++) {
          dp[i][0] += dp[i - 1][j];
          dp[i][0] %= mod;
        }

        for (int j = 1; j <= Math.min(i, k); j++) {
          dp[i][j] = dp[i - 1][j - 1];
        }
      }

      var ans = 0;
      for (int i = 0; i <= k; i++) {
        ans += dp[n][i];
        ans %= mod;
      }

      return ans;
    }
  }
}