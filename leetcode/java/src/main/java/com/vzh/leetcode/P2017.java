package com.vzh.leetcode;

import java.util.Arrays;
import java.util.HashMap;
import java.util.HashSet;

/*
 * Problem: https://leetcode.com/problems/grid-game/
 * Submission: https://leetcode.com/submissions/detail/569966051/
 */
public class P2017 {
  class Solution {
    public long gridGame(int[][] grid) {
      var length = grid[0].length;
      var prefixTop = new long[length + 1];
      var prefixBottom = new long[length + 1];
      long sumTop = 0;

      for (var i = 0; i < length; i++) {
        prefixTop[i + 1] = prefixTop[i] + grid[0][i];
        prefixBottom[i + 1] = prefixBottom[i] + grid[1][i];
        sumTop += grid[0][i];
      }

      var max = new long[length];
      for (var i = 0; i < length; i++) {
        max[i] = Math.max(prefixBottom[i], sumTop - prefixTop[i + 1]);
      }

      return Arrays.stream(max).min().getAsLong();
    }
  }
}