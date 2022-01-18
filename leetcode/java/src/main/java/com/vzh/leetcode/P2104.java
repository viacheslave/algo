package com.vzh.leetcode;

import java.util.HashMap;
import java.util.HashSet;

/*
 * Problem: https://leetcode.com/problems/sum-of-subarray-ranges/
 * Submission: https://leetcode.com/submissions/detail/601851958/
 */
public class P2104 {
  class Solution {
    public long subArrayRanges(int[] nums) {
      var ans = 0L;

      for (int i = 0; i < nums.length; i++) {
        var min = nums[i];
        var max = nums[i];

        for (int j = i; j < nums.length; j++) {
          min = Math.min(min, nums[j]);
          max = Math.max(max, nums[j]);

          ans += max - min;
        }
      }

      return ans;
    }
  }
}