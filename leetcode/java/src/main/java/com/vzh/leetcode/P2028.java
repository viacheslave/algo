package com.vzh.leetcode;

import java.util.Arrays;

/*
 * Problem: https://leetcode.com/problems/find-missing-observations/
 * Submission: https://leetcode.com/submissions/detail/572641026/
 */
public class P2028 {
  class Solution {
    public int[] missingRolls(int[] rolls, int mean, int n) {
      var sum = (n + rolls.length) * mean - Arrays.stream(rolls).sum();
      var count = n;

      var ratio = 1. * sum / n;
      if (ratio < 1. || ratio > 6.)
        return new int[0];

      var arr = new int[n];

      for (var i = 0; i < n; i++) {
        for (var j = 1; j <= 6; j++) {
          if (count == 1) {
            arr[i] = sum;
            break;
          }

          var expSum = sum - j;
          var expRatio = 1. * expSum / (count - 1);

          if (expRatio >= 1. && expRatio <= 6.) {
            arr[i] = j;
            count--;
            sum -= j;
            break;
          }
        }
      }

      return arr;
    }
  }
}