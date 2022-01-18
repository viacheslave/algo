package binarysearch;

/*
 * Problem: https://binarysearch.com/problems/First-Missing-Positive
 * Submission: https://binarysearch.com/problems/First-Missing-Positive/submissions/7315458
 */
public class P0007 {
  class Solution {
    public int solve(int[] nums) {
      var n = nums.length;
      for (int i = 0; i < n; i++) {
        // swap
        while (nums[i] > 0 && nums[i] <= n && nums[i] - 1 != i) {
          if (nums[nums[i] - 1] == nums[i])
            break;

          var temp = nums[nums[i] - 1];
          nums[nums[i] - 1] = nums[i];
          nums[i] = temp;
        }
      }

      for (int i = 0; i < n; i++) {
        if (nums[i] != i + 1)
          return i + 1;
      }

      return n + 1;
    }
  }
}