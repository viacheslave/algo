
package com.vzh.leetcode;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

/*
 * Problem: https://leetcode.com/problems/find-target-indices-after-sorting-array/
 * Submission: https://leetcode.com/submissions/detail/593892309/
 */
public class P2089 {
  class Solution {
    public List<Integer> targetIndices(int[] nums, int target) {
      Arrays.sort(nums);

      var ans = new ArrayList<Integer>();
      for (int i = 0; i < nums.length; i++) {
        if (nums[i] == target)
          ans.add(i);
      }

      return ans;
    }
  }
}