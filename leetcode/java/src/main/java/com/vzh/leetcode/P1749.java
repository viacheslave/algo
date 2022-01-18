package com.vzh.leetcode;

import java.util.Arrays;

/*
 * Problem: https://leetcode.com/problems/maximum-absolute-sum-of-any-subarray/
 * Submission: https://leetcode.com/submissions/detail/573808586/
 */
public class P1749 {
  class Solution {
    public int maxAbsoluteSum(int[] nums) {
      return Math.max(Math.abs(maxSum(nums)), Math.abs(minSum(nums)));
    }

    private int maxSum(int[] nums) {
      var localMax = 0;
      var ans = Integer.MIN_VALUE;

      for (var i = 0; i < nums.length; i++) {
        localMax = Math.max(nums[i] + localMax, nums[i]);
        if (localMax > ans) {
          ans = localMax;
        }
      }

      return ans;
    }

    private int minSum(int[] nums) {
      var localMin = 0;
      var ans = Integer.MAX_VALUE;

      for (var i = 0; i < nums.length; i++) {
        localMin = Math.min(nums[i] + localMin, nums[i]);
        if (localMin < ans) {
          ans = localMin;
        }
      }

      return ans;
    }
  }
}