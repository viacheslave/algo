package com.vzh.leetcode;

import java.util.Arrays;

/*
 * Problem: https://leetcode.com/problems/smallest-index-with-equal-value/
 * Submission: https://leetcode.com/submissions/detail/583536518/
 */
public class P2057 {
  class Solution {
    public int smallestEqual(int[] nums) {
      for (int i = 0; i < nums.length; i++) {
        if (i % 10 == nums[i])
          return i;
      }

      return -1;
    }
  }
}