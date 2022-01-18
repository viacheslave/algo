package com.vzh.leetcode;

import java.util.Arrays;

/*
 * Problem: https://leetcode.com/problems/minimized-maximum-of-products-distributed-to-any-store/
 * Submission: https://leetcode.com/submissions/detail/583445106/
 */
public class P2064 {
  class Solution {
    public int minimizedMaximum(int n, int[] quantities) {
      var min = 1;
      var max = Arrays.stream(quantities).max().getAsInt();

      while (true) {
        if (max - min < 2) {
          if (canDistribute(min, n, quantities))
            return min;
          return max;
        }

        var mid = (max + min) / 2;
        if (canDistribute(mid, n, quantities))
          max = mid;
        else
          min = mid;
      }
    }

    private boolean canDistribute(int val, int n, int[] quantities) {
      var taken = 0;

      for (var q : quantities) {
        var div = q / val;
        var mod = q % val;

        var stores = div + (mod == 0 ? 0 : 1);
        taken += stores;
      }

      return taken <= n;
    }
  }
}