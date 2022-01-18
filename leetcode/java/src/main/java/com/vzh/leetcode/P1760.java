package com.vzh.leetcode;

import java.util.Arrays;

/*
 * Problem: https://leetcode.com/problems/minimum-limit-of-balls-in-a-bag/
 * Submission: https://leetcode.com/submissions/detail/583450545/
 */
public class P1760 {
  class Solution {
    public int minimumSize(int[] nums, int maxOperations) {
      var min = 1;
      var max = Arrays.stream(nums).max().getAsInt();

      while (true) {
        if (max - min < 2) {
          if (penaltyFor(min, maxOperations, nums))
            return min;
          return max;
        }

        var mid = (max + min) / 2;
        if (penaltyFor(mid, maxOperations, nums))
          max = mid;
        else
          min = mid;
      }
    }

    private boolean penaltyFor(int min, int maxOperations, int[] nums) {
      var ops = 0;

      for (var num : nums) {
        var div = num / min;
        var mod = num % min;
        var res = (mod == 0) ? (div - 1) : div;
        ops += res;
      }

      return ops <= maxOperations;
    }
  }
}