package com.vzh.leetcode;

import java.util.ArrayList;
import java.util.Arrays;

/*
 * Problem: https://leetcode.com/problems/number-of-smooth-descent-periods-of-a-stock/
 * Submission: https://leetcode.com/submissions/detail/603982479/
 */
public class P2110 {
  class Solution {
    public long getDescentPeriods(int[] prices) {
      if (prices.length == 1)
        return 1;

      var ans = 0L;
      var period = 1L;

      for (int i = 1; i < prices.length; i++) {
        if (prices[i] == prices[i - 1] - 1) {
          period++;
        }
        else {
          ans += period * (period + 1) / 2;
          period = 1;
        }

        if (i == prices.length - 1) {
          ans += period * (period + 1) / 2;
        }
      }

      return ans;
    }
  }
}