package binarysearch;

/*
 * Problem: https://binarysearch.com/problems/Decode-Message
 * Submission: https://binarysearch.com/problems/Decode-Message/submissions/7113473
 */
public class P0008 {
  class Solution {
    public int solve(String message) {
      var dp = new int[message.length()];
      dp[0] = 1;

      for (var i = 1; i < message.length(); i++) {
        var cr = message.charAt(i);
        var pr = message.charAt(i - 1);

        if (cr != '0')
          dp[i] = dp[i - 1];

        if (pr == '1' || (pr == '2' && Integer.parseInt(String.valueOf(cr)) <= 6)) {
          if (i - 2 < 0)
            dp[i] += 1;
          else
            dp[i] += dp[i - 2];
        }
      }

      return dp[message.length() - 1];
    }
  }
}