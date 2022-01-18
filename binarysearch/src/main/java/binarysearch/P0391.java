package binarysearch;

import java.util.ArrayList;

/*
 * Problem: https://binarysearch.com/problems/String-Construction
 * Submission: https://binarysearch.com/problems/String-Construction/submissions/7088597
 */
public class P0391 {
  class Solution {
    public int solve(String[] strings, int a, int b) {
      var dp = new int[strings.length + 1][a + 1][b + 1];
      // 0 - subset of first n strings
      // 1 - left n As
      // 2 - left n Bs

      // no strings taken
      for (int j = 0; j <= a; j++) {
        for (int k = 0; k <= b; k++) {
          dp[0][j][k] = 0;
        }
      }

      for (int i = 1; i <= strings.length; i++) {
        var as = 0;
        var bs = 0;

        for (int j = 0; j < strings[i - 1].length(); j++) {
          if (strings[i - 1].charAt(j) == 'A') as++;
          if (strings[i - 1].charAt(j) == 'B') bs++;
        }

        for (int j = 0; j <= a; j++) {
          for (int k = 0; k <= b; k++) {
            var notTake = dp[i - 1][j][k];

            var take = Integer.MIN_VALUE;
            if (j - as >= 0 && k - bs >= 0) {
              // take prev with j - as As and k - bs Bs plus current string
              take = dp[i - 1][j - as][k - bs] + 1;
            }
            else {
              // not enough letters
              take = 0;
            }

            dp[i][j][k] = Math.max(take, notTake);
          }
        }
      }

      var ans = Integer.MIN_VALUE;
      for (int j = 0; j <= a; j++) {
        for (int k = 0; k <= b; k++) {
          ans = Math.max(ans, dp[strings.length][j][k]);
        }
      }

      return ans;
    }
  }
}