package com.vzh.leetcode;

import java.util.Arrays;
import java.util.stream.Collectors;

/*
 * Problem: https://leetcode.com/problems/delete-and-earn/
 * Submission: https://leetcode.com/submissions/detail/590521624/
 */
public class P0740 {
  class Solution {
    public int deleteAndEarn(int[] nums) {
      if (nums.length == 1)
        return nums[0];

      // hash set to reduce operations
      var set = Arrays.stream(nums).boxed().collect(Collectors.groupingBy(x -> x, Collectors.counting()));
      var arr = set.keySet().stream().sorted().mapToInt(x -> x).toArray();

      var dp = new long[arr.length][2];

      for (int i = 0; i < arr.length; i++) {
        if (i == 0) {
          dp[i][0] = 0;
          dp[i][1] = arr[i] * set.get(arr[i]);
          continue;
        }

        // if we don't take arr[i]
        // we accept max value from prev arr[i-1] take/not take
        dp[i][0] = Math.max(dp[i - 1][0], dp[i - 1][1]);

        if (arr[i] - arr[i - 1] == 1) {
          // if we take it
          // we are not allowed to take prev
          dp[i][1] = dp[i - 1][0] + arr[i] * set.get(arr[i]);
        }
        else {
          dp[i][1] = Math.max(dp[i - 1][0], dp[i - 1][1]) + arr[i] * set.get(arr[i]);
        }
      }

      return (int)Math.max(dp[arr.length - 1][0], dp[arr.length - 1][1]);
    }
  }
}