package com.vzh.leetcode;

import java.util.Arrays;
import java.util.Comparator;
import java.util.HashMap;
import java.util.TreeMap;

/**
 * Problem: https://leetcode.com/problems/largest-combination-with-bitwise-and-greater-than-zero/
 * Submission: https://leetcode.com/submissions/detail/699933123/
 */
public class P2275 {
  class Solution {
    public int largestCombination(int[] candidates) {
      var ans = 0;

      for (var i = 24; i >= 0; i--) {
        var mask = 1 << i;
        var count = 0;

        for (var candidate : candidates) {
          if ((candidate & mask) == mask) {
            count++;
          }
        }

        ans = Math.max(ans, count);
      }

      return ans;
    }
  }
}
