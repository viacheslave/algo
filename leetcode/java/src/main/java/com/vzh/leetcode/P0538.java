package com.vzh.leetcode;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.TreeMap;

/*
 * Problem: https://binarysearch.com/problems/Bus-Stop
 * Submission: https://binarysearch.com/problems/Bus-Stop/submissions/7447397
 */
class P0538 {
  class Solution {
    public int solve(int[] nums) {
      var n = nums.length;
      var dp = new int[n];

      Arrays.fill(dp, 1);

      // longest non-increasing subsequence
      for (var i = 0; i < n; i++) {
        for (var j = 0; j < i; j++) {
          if (nums[i] <= nums[j]) {
            dp[i] = Math.max(dp[i], dp[j] + 1);
          }
        }
      }

      return Arrays.stream(dp).max().getAsInt();
    }
  }
}