package binarysearch;

import java.util.Stack;

/*
 * Problem: https://binarysearch.com/problems/Edit-Distance
 * Submission: https://binarysearch.com/problems/Edit-Distance/submissions/7113519
 */
public class P0113 {
  class Solution {
    public int solve(String a, String b) {
      var dp = new int[a.length() + 1][b.length() + 1];

      for (var s1 = 0; s1 <= a.length(); s1++) {
        for (var s2 = 0; s2 <= b.length(); s2++) {
          if (s1 == 0 && s2 == 0)
            continue;

          if (s1 == 0) {
            dp[s1][s2] = s2;
            continue;
          }

          if (s2 == 0) {
            dp[s1][s2] = s1;
            continue;
          }

          var c = a.charAt(s1 - 1) == b.charAt(s2 - 1) ? 0 : 1;

          dp[s1][s2] =
            Math.min(dp[s1 - 1][s2 - 1] + c,
              Math.min(dp[s1 - 1][s2] + 1, dp[s1][s2 - 1] + 1));
        }
      }

      return dp[a.length()][b.length()];
    }
  }
}