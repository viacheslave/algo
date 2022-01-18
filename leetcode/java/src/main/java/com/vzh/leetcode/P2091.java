
package com.vzh.leetcode;

import java.util.Arrays;

/*
 * Problem: https://leetcode.com/problems/removing-minimum-and-maximum-from-array/
 * Submission: https://leetcode.com/submissions/detail/593891917/
 */
public class P2091 {
  class Solution {
    public int minimumDeletions(int[] nums) {
      var minIndex = -1;
      var maxIndex = 1;

      int minValue = Integer.MAX_VALUE, maxValue = Integer.MIN_VALUE;

      for (int i = 0; i < nums.length; i++) {
        if (nums[i] < minValue) {
          minValue = nums[i];
          minIndex = i;
        }

        if (nums[i] > maxValue) {
          maxValue = nums[i];
          maxIndex = i;
        }
      }

      var ordered = new int[] {minIndex, maxIndex};
      Arrays.sort(ordered);

      var ans = Math.min(
        (ordered[0] + 1) + (nums.length - ordered[1]),
        Math.min(
          (ordered[1] - ordered[0]) + (ordered[0] + 1),
          (ordered[1] - ordered[0]) + nums.length - ordered[1]
        ));

      return ans;
    }
  }
}