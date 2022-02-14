package com.vzh.leetcode;

import java.util.Arrays;
import java.util.stream.Collectors;

/*
 * Problem: https://leetcode.com/problems/removing-minimum-number-of-magic-beans/
 * Submission: https://leetcode.com/submissions/detail/640497086/
 */
public class P2171 {
  class Solution {
    public long minimumRemoval(int[] beans) {
      Arrays.sort(beans);

      var n = beans.length;
      var prefixSums = new long[n];
      var suffixSum = new long[n];

      for (int i = 0; i < n; i++) {
        prefixSums[i] = i == 0 ? beans[0] : prefixSums[i - 1] + beans[i];
        suffixSum[n - 1 - i] = i == 0 ? beans[n - 1] : suffixSum[n - i] + beans[n - 1 - i];
      }

      // 1,4,5,6
      long ans = suffixSum[0] - (long)beans[0] * n;

      for (int i = 0; i < n; i++) {
        var left = prefixSums[i];
        var right = i == n - 1 ? 0 : suffixSum[i + 1] - (long)beans[i + 1] * (n - i - 1);

        ans = Math.min(ans, left + right);
      }

      return ans;
    }
  }
}