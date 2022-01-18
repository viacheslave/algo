package binarysearch;

/*
 * Problem: https://binarysearch.com/problems/Knight-Remains
 * Submission: https://binarysearch.com/problems/Knight-Remains/submissions/7108416
 */
public class P0359 {
  class Solution {
    public int solve(int n, int x, int y, int k) {
      var dp = new float[n][n];
      dp[x][y] = 1;

      float ans = 0;

      for (int i = 0; i < k; i++) {
        var dp_next = new float[n][n];

        for (int j = 0; j < n; j++) {
          for (int l = 0; l < n; l++) {
            if (dp[j][l] == 0)
              continue;

            var ways_x = new int[] {-2,-2,-1,-1,+1,+1,+2,+2};
            var ways_y = new int[] {-1,+1,-2,+2,-2,+2,-1,+1};

            for (int m = 0; m < 8; m++) {
              if (j + ways_x[m] >= 0 && l + ways_y[m] >= 0 && j + ways_x[m] < n && l + ways_y[m] < n) {
                // on the board
                // sum all probabilities for current cell, from other cells
                dp_next[j + ways_x[m]][l + ways_y[m]] += dp[j][l] * 0.125;
              }
              else {
                // off the board, sum to ans
                ans += dp[j][l] * 0.125;
              }
            }
          }
        }

        dp = dp_next;
      }

      return 100 - (int)Math.ceil(ans * 100);
    }
  }
}