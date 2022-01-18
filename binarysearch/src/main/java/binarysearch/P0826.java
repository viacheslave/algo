package binarysearch;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.stream.Collectors;

/*
 * Problem: https://binarysearch.com/problems/First-to-Count-to-Target
 * Submission: https://binarysearch.com/problems/First-to-Count-to-Target/submissions/7081479
 */
public class P0826 {
  class Solution {
    public boolean solve(int k, int target) {
      // dp == 1 - you'll win if you appear on ith place
      // dp == 0 - you'll lose

      var dp = new int[target];

      // last place - you win
      dp[target - 1] = 1;

      for (var i = target - k - 1 - 1; i >= 0; i--) {
        // go backwards

        var allWins = 0;
        for (var j = i + 1; j < i + 1 + k; j++) {
          allWins += dp[j];
        }

        // check if next k positions are all zeros - you win at ith place
        // because your opponent doesn't secure a win (all zeros) for all k.

        // otherwise, if there's at least a single one - you lose
        // because your opponent plays optimally and can reach a one.
        dp[i] = allWins == 0 ? 1 : 0;
      }

      // check first k places
      for (int i = 0; i < k; i++) {
        if (dp[i] == 1)
          return true;
      }

      return false;
    }
  }
}