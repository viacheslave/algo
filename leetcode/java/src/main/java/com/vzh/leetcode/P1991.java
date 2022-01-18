package com.vzh.leetcode;

import java.util.HashSet;

/*
 * Problem: https://leetcode.com/problems/find-the-middle-index-in-array/
 * Submission: https://leetcode.com/submissions/detail/551032786/
 */
public class P1991 {
  class Solution {
    public int findMiddleIndex(int[] nums) {
      var prefixSum = new int[nums.length + 1];
      var suffixSum = new int[nums.length + 1];

      for (var i = 0; i < nums.length; i++) {
        prefixSum[i + 1] = nums[i] + prefixSum[i];
        suffixSum[nums.length - i - 1] = suffixSum[nums.length - i] + nums[nums.length - i - 1];
      }

      for (var i = 0; i < nums.length; i++) {
        if (prefixSum[i] == suffixSum[i + 1])
          return i;
      }

      return -1;
    }
  }
}