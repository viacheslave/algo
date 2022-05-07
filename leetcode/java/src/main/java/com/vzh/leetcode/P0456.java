package com.vzh.leetcode;

import java.util.HashMap;
import java.util.TreeMap;
import java.util.TreeSet;

/**
 * Problem: https://leetcode.com/problems/132-pattern/
 * Submission: https://leetcode.com/submissions/detail/694990863/
 */
public class P0456 {
  class Solution {
    public boolean find132pattern(int[] nums) {
      if (nums.length < 3)
        return false;

      // calculate left min possible
      var left = new int[nums.length];
      var runningMin = Integer.MAX_VALUE;

      for (var i = 0; i < nums.length; i++) {
        if (i == 0)
          continue;

        runningMin = Math.min(runningMin, nums[i - 1]);
        left[i] = runningMin;
      }

      // calculate right side
      var set = new TreeSet<Integer>();

      for (var i = nums.length - 1; i > 0; i--) {
        if (i == nums.length - 1) {
          set.add(nums[i]);
          continue;
        }

        if (left[i] >= nums[i])
          continue;

        var ceiling = set.ceiling(left[i] + 1);
        var floor = set.floor(nums[i] - 1);

        if (ceiling != null && floor != null && ceiling <= floor)
          return true;

        set.add(nums[i]);
      }

      return false;
    }
  }
}
