package binarysearch;

import java.util.ArrayList;

/*
 * Problem: https://binarysearch.com/problems/Largest-Sum-of-Non-Adjacent-Numbers-in-Circular-List
 * Submission: https://binarysearch.com/problems/Largest-Sum-of-Non-Adjacent-Numbers-in-Circular-List/submissions/7496341
 */
public class P0693 {
  class Solution {
    public int solve(int[] nums) {
      var length = nums.length;
      if (length == 0)
        return 0;

      if (length == 1)
        return Math.max(0, nums[0]);

      return Math.max(
        sum(nums, 0, length - 2),
        sum(nums, 1, length - 1)
      );
    }

    private int sum(int[] nums, int from, int to) {
      var dp = new int[nums.length];

      for (var i = from; i <= to; i++) {
        if (i == from) {
          dp[i] = nums[i];
          continue;
        }

        if (i == from + 1) {
          dp[i] = Math.max(nums[i - 1], nums[i]);
          continue;
        }

        dp[i] = Math.max(dp[i], nums[i]);
        dp[i] = Math.max(dp[i], dp[i - 2] + nums[i]);
        dp[i] = Math.max(dp[i], dp[i - 1]);
      }

      var ans = 0;
      for (var i = from; i <= to; i++) {
        ans = Math.max(ans, dp[i]);
      }
      return ans;
    }
  }
}