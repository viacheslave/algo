package binarysearch;

import java.util.Arrays;

/*
 * Problem: https://binarysearch.com/problems/Number-of-Operations-to-Decrement-Target-to-Zero
 * Submission: https://binarysearch.com/problems/Number-of-Operations-to-Decrement-Target-to-Zero/submissions/7587797
 */
public class P0843 {
  class Solution {
    public int solve(int[] nums, int target) {
      if (nums.length == 0) {
        return target == 0 ? 0 : -1;
      }

      var length = -1;
      var sum = nums[0];
      target = Arrays.stream(nums).sum() - target;

      if (target == 0) {
        return nums.length;
      }

      var left = 0;
      var right = 0;

      // sliding window
      while (right < nums.length) {
        while (sum > target && left < right) {
          sum -= nums[left];
          left++;
        }

        if (sum == target) {
          length = Math.max(length, right - left + 1);
        }

        right++;
        if (right < nums.length) {
          sum += nums[right];
        }
      }

      if (length == -1)
        return length;
      return nums.length - length;
    }
  }
}