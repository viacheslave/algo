package binarysearch;

/*
 * Problem: https://binarysearch.com/problems/Max-Sum-Partitioning
 * Submission: https://binarysearch.com/problems/Max-Sum-Partitioning/submissions/6960192
 */
public class P0865 {
  class Solution {
    public int solve(int[] nums, int k) {
      var dp = new int[nums.length + 1];

      for (var i = 1; i <= nums.length; i++) {
        var value = Integer.MIN_VALUE;

        for (var j = 1; j <= k; j++) {
          if (i - j < 0)
            continue;

          var max = Integer.MIN_VALUE;
          for (var l = 1; l <= j; l++)
            if (i - l >= 0)
              max = Math.max(max, nums[i - l]);

          value = Math.max(value, dp[i - j] + max * j);
        }

        dp[i] = value;
      }

      return dp[nums.length];
    }
  }
}