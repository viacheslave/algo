package com.vzh.leetcode;

import java.util.Arrays;
import java.util.HashSet;
import java.util.List;
import java.util.Stack;
import java.util.stream.Collectors;

/*
 * Problem: https://leetcode.com/problems/sum-of-subarray-minimums/
 * Submission: https://leetcode.com/submissions/detail/592138201/
 */
public class P0907 {
  class Solution {
    public int sumSubarrayMins(int[] arr) {
      var mod = (int)1e9 + 7;
      var dp = new int[arr.length];

      // monotonic stack, increasing
      var stack = new Stack<StackItem>();

      // DP
      // dp[i] is sum of subarray minimums up to index i
      dp[0] = arr[0];
      stack.add(new StackItem(0, arr[0]));

      for (var i = 1; i < arr.length; i++) {
        // if current value is less that peek of the stack
        // pop all that bigger
        // because minimum value expands to the left
        while (!stack.empty() && stack.peek().value > arr[i])
          stack.pop();

        if (stack.empty())
          dp[i] = arr[i] * (i + 1) % mod;
        else
          // take peek value
          dp[i] = arr[i] * (i - stack.peek().index) % mod + dp[stack.peek().index];

        stack.add(new StackItem(i, arr[i]));
      }

      var ans = 0;
      for (int i = 0; i < arr.length; i++) {
        ans += dp[i];
        ans %= mod;
      }

      return ans;
    }

    public class StackItem {
      public int index;
      public int value;

      public StackItem(int index, int value) {
        this.index = index;
        this.value = value;
      }
    }
  }
}