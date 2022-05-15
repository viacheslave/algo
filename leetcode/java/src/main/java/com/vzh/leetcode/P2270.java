package com.vzh.leetcode;

import java.util.Arrays;

/**
 * Problem: https://leetcode.com/problems/number-of-ways-to-split-array/
 * Submission: https://leetcode.com/submissions/detail/699902811/
 */
public class P2270 {
  class Solution {
    public int waysToSplitArray(int[] nums) {
      var sum = Arrays.stream(nums).boxed().map(Long::new)
        .reduce(0L, Long::sum);

      var left = 0L + nums[0];
      var ans = 0;

      for (var i = 1; i < nums.length; i++) {
        if (left >= sum - left) {
          ans++;
        }
        left += nums[i];
      }

      return ans;
    }
  }
}
