package binarysearch;

/*
 * Problem: https://binarysearch.com/problems/Zipped-String
 * Submission: https://binarysearch.com/problems/Zipped-String/submissions/6978869
 */
public class P0054 {
  class Solution {
    public boolean solve(String a, String b, String c) {
      var dp = new boolean[a.length() + 1][b.length() + 1];
      dp[0][0] = true;

      for (int i = 0; i < a.length(); i++) {
        dp[i + 1][0] = dp[i][0] && i < c.length() && a.charAt(i) == c.charAt(i);
      }

      for (int j = 0; j < b.length(); j++) {
        dp[0][j + 1] = dp[0][j] && j < c.length() &&b.charAt(j) == c.charAt(j);
      }

      for (int i = 0; i < a.length(); i++) {
        for (int j = 0; j < b.length(); j++) {

          if (i + j + 1 >= c.length()) {
            dp[i + 1][j + 1] = false;
            continue;
          }

          var ch = c.charAt(i + j + 1);
          dp[i + 1][j + 1] =
            dp[i][j + 1] && a.charAt(i) == ch || dp[i + 1][j] && b.charAt(j) == ch;
        }
      }

      return dp[a.length()][b.length()];
    }
  }
}