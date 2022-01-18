package com.vzh.leetcode;

import java.util.Arrays;

/*
 * Problem: https://leetcode.com/problems/maximum-difference-between-increasing-elements/
 * Submission: https://leetcode.com/submissions/detail/583453222/
 */
public class P2016 {
  class Solution {
    public int maximumDifference(int[] nums) {
      var ans = -1;
      for (var i = 0; i < nums.length - 1; i++) {
        for (var j = i + 1; j < nums.length; j++) {
          if (nums[i] < nums[j]) {
            ans = Math.max(nums[j] - nums[i], ans);
          }
        }
      }

      return ans;
    }
  }
}