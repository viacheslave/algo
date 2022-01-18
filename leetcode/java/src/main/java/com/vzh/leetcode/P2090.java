
package com.vzh.leetcode;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

/*
 * Problem: https://leetcode.com/problems/k-radius-subarray-averages/
 * Submission: https://leetcode.com/submissions/detail/593887060/
 */
public class P2090 {
  class Solution {
    public int[] getAverages(int[] nums, int k) {
      var pr = new long[nums.length + 1];

      for (int i = 0; i < nums.length; i++) {
        pr[i + 1] = pr[i] + nums[i];
      }

      var ans = new int[nums.length];
      Arrays.fill(ans, -1);

      for (int i = 0; i < nums.length; i++) {
        var left = i - k;
        var right = i + k;

        if (left >= 0 && right < nums.length) {
          ans[i] = (int)((pr[right + 1] - pr[left]) / (right - left + 1));
        }
      }

      return ans;
    }
  }
}