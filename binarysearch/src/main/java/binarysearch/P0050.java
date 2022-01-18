package binarysearch;

import java.util.Arrays;

/*
 * Problem: https://binarysearch.com/problems/Longest-Increasing-Subsequence
 * Submission: https://binarysearch.com/problems/Longest-Increasing-Subsequence/submissions/7295512
 */
public class P0050 {
  class Solution {
    public int solve(int[] nums) {
      if (nums.length == 0)
        return 0;

      var dp = new int[nums.length];
      dp[0] = 1;

      for (int i = 1; i < nums.length; i++) {
        for (int j = 0; j < i; j++) {
          var value = nums[i] > nums[j]
            ? dp[j] + 1
            : 1;

          dp[i] = Math.max(dp[i], value);
        }
      }

      return Arrays.stream(dp).max().getAsInt();
    }
  }
}