package binarysearch;

/*
 * Problem: https://binarysearch.com/problems/Window-Limits
 * Submission: https://binarysearch.com/problems/Window-Limits/submissions/7598931
 */
public class P0955 {
  class Solution {
    public boolean solve(int[] nums, int window, int limit) {
      var maxs = getMaxs(nums, window);
      var mins = getMins(nums, window);

      for (var i = 0; i < nums.length - window + 1; i++) {
        if (maxs[i] - mins[i] > limit)
          return false;
      }

      return true;
    }

    private int[] getMaxs(int[] nums, int window) {
      if (window == 1)
        return nums;

      var n = nums.length;
      var left = new int[n];
      var right = new int[n];

      var current = Integer.MIN_VALUE;
      for (var i = 0; i < n; i++) {
        if (i % window == 0)
          current = Integer.MIN_VALUE;

        current = Math.max(current, nums[i]);
        left[i] = current;
      }

      current = Integer.MIN_VALUE;
      for (var i = n - 1; i >= 0; i--) {
        if ((i + 1) % window == 0)
          current = Integer.MIN_VALUE;

        current = Math.max(current, nums[i]);
        right[i] = current;
      }

      var ans = new int[n];
      for (int i = 0; i < n - window + 1; i++) {
        ans[i] = Math.max(right[i], left[i + window - 1]);
      }

      return ans;
    }

    private int[] getMins(int[] nums, int window) {
      if (window == 1)
        return nums;

      var n = nums.length;
      var left = new int[n];
      var right = new int[n];

      var current = Integer.MAX_VALUE;
      for (var i = 0; i < n; i++) {
        if (i % window == 0)
          current = Integer.MAX_VALUE;

        current = Math.min(current, nums[i]);
        left[i] = current;
      }

      current = Integer.MAX_VALUE;
      for (var i = n - 1; i >= 0; i--) {
        if ((i + 1) % window == 0)
          current = Integer.MAX_VALUE;

        current = Math.min(current, nums[i]);
        right[i] = current;
      }

      var ans = new int[n];
      for (int i = 0; i < n - window + 1; i++) {
        ans[i] = Math.min(right[i], left[i + window - 1]);
      }

      return ans;
    }
  }
}