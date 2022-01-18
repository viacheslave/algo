package binarysearch;

import java.util.Arrays;

/*
 * Problem: https://binarysearch.com/problems/Insertion-Index-in-Sorted-List
 * Submission: https://binarysearch.com/problems/Insertion-Index-in-Sorted-List/submissions/7176789
 */
public class P0034 {
  class Solution {
    public int solve(int[] nums, int target) {
      if (target >= nums[nums.length - 1])
        return nums.length;

      // binary search

      var left = 0;
      var right = nums.length - 1;

      while (true) {
        if (right - left <= 1) {
          if ((right - 1 < 0 || nums[right - 1] <= target) && target <= nums[right])
            return right;
          return left;
        }

        var mid = (left + right) >> 1;
        if (target >= nums[mid]) {
          left = mid;
        }
        else {
          right = mid;
        }
      }
    }
  }
}