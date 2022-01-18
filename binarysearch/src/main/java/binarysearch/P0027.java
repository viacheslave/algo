package binarysearch;

/*
 * Problem: https://binarysearch.com/problems/Longest-Common-Subsequence
 * Submission: https://binarysearch.com/problems/Longest-Common-Subsequence/submissions/6814106
 */
public class P0027 {
  class Solution {
    public int solve(String a, String b) {
      var dp = new int[a.length() + 1][b.length() + 1];
      for (int i = 0; i < a.length() + 1; i++) {
        dp[i] = new int[b.length() + 1];
      }

      for (int i = 0; i < a.length(); i++) {
        for (int j = 0; j < b.length(); j++) {
          var res = 0;
          if (a.charAt(i) == b.charAt(j))
            res = dp[i][j] + 1;
          else
            res = Math.max(
              dp[i][j + 1],
              dp[i + 1][j]
            );

          dp[i + 1][j + 1] = res;
        }
      }

      return dp[a.length()][b.length()];
    }
  }
}