package binarysearch;

/*
 * Problem: https://binarysearch.com/problems/Largest-Sum-of-Non-Adjacent-Numbers
 * Submission: https://binarysearch.com/problems/Largest-Sum-of-Non-Adjacent-Numbers/submissions/7108129
 */
public class P0009 {
  class Solution {
    public int solve(int[] nums) {
      if (nums.length == 0)
        return 0;

      if (nums.length == 1)
        return nums[0];

      var dp = new int[nums.length];

      dp[0] = Math.max(0, nums[0]);
      dp[1] = Math.max(0, Math.max(nums[1], dp[0]));

      for (int i = 2; i < nums.length; i++) {
        dp[i] = Math.max(dp[i - 2] + nums[i], dp[i - 1]);
      }

      return Math.max(0, dp[nums.length - 1]);
    }
  }
}