package binarysearch;

import java.util.Arrays;

/*
 * Problem: https://binarysearch.com/problems/Equal-Partitions
 * Submission: https://binarysearch.com/problems/Equal-Partitions/submissions/7503649
 */
public class P0605 {
  class Solution {
    public boolean solve(int[] nums) {
      var sum = Arrays.stream(nums).sum();
      if (sum % 2 == 1)
        return false;

      sum /= 2;

      // bottom-up DP
      var dp = new int[sum + 1];
      dp[0] = 1;

      for (int i = 0; i < nums.length; i++) {
        var el = nums[i];
        for (int j = sum; j >= 0; j--) {
          if (dp[j] == 1 && j + el <= sum) {
            dp[j + el] = 1;
          }
        }
        dp[el] = 1;
      }

      return dp[sum] == 1;
    }
  }
}