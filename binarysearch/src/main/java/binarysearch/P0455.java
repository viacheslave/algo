package binarysearch;

/*
 * Problem: https://binarysearch.com/problems/Distance-Pair
 * Submission: https://binarysearch.com/problems/Distance-Pair/submissions/6909877
 */
public class P0455 {
  class Solution {
    public int solve(int[] nums) {
      var ai = new int[nums.length];
      var aj = new int[nums.length];

      for (int i = 0; i < nums.length; i++) {
        ai[i] = nums[i] + i;
        aj[i] = nums[i] - i;
      }

      var max = new int[nums.length];
      max[0] = nums[0];
      for (int i = 1; i < nums.length; i++) {
        max[i] = Math.max(max[i - 1], ai[i]);
      }

      var ans = Integer.MIN_VALUE;

      for (int i = nums.length - 1; i > 0; i--) {
        ans = Math.max(ans, aj[i] + max[i - 1]);
      }

      return ans;
    }
  }
}