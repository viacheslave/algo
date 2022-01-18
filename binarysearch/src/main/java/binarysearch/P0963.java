package binarysearch;

import java.util.Arrays;

/*
 * Problem: https://binarysearch.com/problems/Sort-List-by-Reversing-Once
 * Submission: https://binarysearch.com/problems/Sort-List-by-Reversing-Once/submissions/7132960
 */
public class P0963 {
  class Solution {
    public boolean solve(int[] nums) {
      if (nums.length == 0)
        return true;

      var sorted = Arrays.copyOf(nums, nums.length);
      Arrays.sort(sorted);

      var left = 0;
      var right = nums.length - 1;

      while (left < nums.length && nums[left] == sorted[left]) {
        left++;
      }

      while (right >= 0 && nums[right] == sorted[right]) {
        right--;
      }

      if (left >= right)
        return true;

      for (var i = left + 1; i <= right; i++) {
        if (nums[i - 1] < nums[i])
          return false;
      }

      return true;
    }
  }
}