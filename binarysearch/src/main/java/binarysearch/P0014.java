package binarysearch;

import java.util.*;
import java.util.stream.Collectors;

/*
 * Problem: https://binarysearch.com/problems/Sliding-Window-Max
 * Submission: https://binarysearch.com/problems/Sliding-Window-Max/submissions/7541817
 */
public class P0014 {
  class Solution {
    public int[] solve(int[] nums, int k) {
      var n = nums.length;

      // fill left and right arrays
      var left = new int[n];
      var right = new int[n];

      var max = Integer.MIN_VALUE;
      for (int i = 0; i < n; i++) {
        if (i % k == 0)
          max = Integer.MIN_VALUE;
        max = Math.max(max, nums[i]);
        left[i] = max;
      }

      max = Integer.MIN_VALUE;
      for (int i = n - 1; i >= 0; i--) {
        if ((i + 1) % k == 0)
          max = Integer.MIN_VALUE;
        max = Math.max(max, nums[i]);
        right[i] = max;
      }

      // compare left and right
      var ans = new int[n - k + 1];
      for (int i = 0; i < n - k + 1; i++) {
        ans[i] = Math.max(left[i + k - 1], right[i]);
      }

      return ans;
    }
  }
}