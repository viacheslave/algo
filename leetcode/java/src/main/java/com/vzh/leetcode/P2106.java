package com.vzh.leetcode;

/*
 * Problem: https://leetcode.com/problems/maximum-fruits-harvested-after-at-most-k-steps/
 * Submission: https://leetcode.com/submissions/detail/601815229/
 */
public class P2106 {
  class Solution {
    public int maxTotalFruits(int[][] fruits, int startPos, int k) {
      var minPos = 0;
      var maxPos = 200_000;

      var pos = new int[maxPos + 1];
      for (var fruit : fruits) {
        pos[fruit[0]] = fruit[1];
      }

      var prefixSum = new int[pos.length + 1];
      for (var i = 0; i < pos.length; i++) {
        prefixSum[i + 1] = prefixSum[i] + pos[i];
      }

      var ans = Integer.MIN_VALUE;

      for (var i = 0; i + i <= k; i++) {
        // wasting left direction
        var left = startPos - i;
        var right = startPos + (k - 2 * i);

        left = Math.max(left, minPos);
        right = Math.min(right, maxPos);

        var sum = prefixSum[right + 1] - prefixSum[left];
        ans = Math.max(ans, sum);

        // wasting right direction
        right = startPos + i;
        left = startPos - (k - 2 * i);

        left = Math.max(left, minPos);
        right = Math.min(right, maxPos);

        sum = prefixSum[right + 1] - prefixSum[left];
        ans = Math.max(ans, sum);
      }

      return ans;
    }
  }
}