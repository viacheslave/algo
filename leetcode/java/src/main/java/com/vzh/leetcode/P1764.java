package com.vzh.leetcode;

import java.util.HashSet;

/*
 * Problem: https://leetcode.com/problems/form-array-by-concatenating-subarrays-of-another-array/
 * Submission: https://leetcode.com/submissions/detail/611620323/
 */
public class P1764 {
  class Solution {
    public boolean canChoose(int[][] groups, int[] nums) {
      var groupIndex = 0;
      var group = groups[groupIndex];
      var groupLength = group.length;

      // greedy
      for (var i = 0; i < nums.length; ) {
        var matchIndex = 0;
        var numIndex = i;

        while (numIndex < nums.length && matchIndex < groupLength && group[matchIndex] == nums[numIndex]) {
          matchIndex++;
          numIndex++;
        }

        if (matchIndex == groupLength) {
          i = i + groupLength;

          groupIndex++;
          if (groupIndex == groups.length)
            break;

          group = groups[groupIndex];
          groupLength = group.length;
          continue;
        }

        i += 1;
      }

      return groupIndex == groups.length;
    }
  }
}