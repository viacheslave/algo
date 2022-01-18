package com.vzh.leetcode;

/*
 * Problem: https://leetcode.com/problems/count-number-of-pairs-with-absolute-difference-k/
 * Submission: https://leetcode.com/submissions/detail/557456373/
 */
public class P2006 {
  class Solution {
    public int countKDifference(int[] nums, int k) {
      var ans = 0;
      // brute force
      for (int i = 0; i < nums.length - 1; i++) {
        for (int j = i + 1; j < nums.length; j++) {
          if (Math.abs(nums[i] - nums[j]) == k)
            ans++;
        }
      }
      return ans;
    }
  }
}