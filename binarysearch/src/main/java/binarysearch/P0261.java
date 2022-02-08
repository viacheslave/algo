package binarysearch;

import binarysearch.templates.Tree;

import java.util.Arrays;

/*
 * Problem: https://binarysearch.com/problems/Sublist-Sum
 * Submission: https://binarysearch.com/problems/Sublist-Sum/submissions/7498560
 */
public class P0261 {
  class Solution {
    public boolean solve(int[] nums) {
      if (nums.length == 0)
        return false;

      var sum  = Arrays.stream(nums).sum();

      // Kadane's

      var max = 0;
      var current = max;

      for (var i = 0; i < nums.length; i++) {
        current = Math.max(current + nums[i], nums[i]);
        max = Math.max(current, max);
      }

      return (max > sum);
    }
  }
}