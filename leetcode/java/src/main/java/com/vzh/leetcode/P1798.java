package com.vzh.leetcode;

import java.util.Arrays;

/*
 * Problem: https://leetcode.com/problems/maximum-number-of-consecutive-values-you-can-make/
 * Submission: https://leetcode.com/submissions/detail/573834671/
 */
public class P1798 {
  class Solution {
    public int getMaximumConsecutive(int[] coins) {
      Arrays.sort(coins);

      if (coins[0] != 1)
        return 1;

      var sum = 1;

      for (var i = 1; i < coins.length; i++) {
        var coin = coins[i];
        if (coin <= sum + 1) {
          sum = coin + sum;
          continue;
        }

        break;
      }

      return sum + 1;
    }
  }
}