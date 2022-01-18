package com.vzh.leetcode;

import java.util.Arrays;

/*
 * Problem: https://leetcode.com/problems/convert-1d-array-into-2d-array/
 * Submission: https://leetcode.com/submissions/detail/583456121/
 */
public class P2022 {
  class Solution {
    public int[][] construct2DArray(int[] original, int m, int n) {
      if (n * m != original.length)
        return new int[0][0];

      var ans = new int[m][n];

      for (var r = 0; r < m; r++) {
        for (var c = 0; c < n; c++) {
          var index = r * n + c;
          ans[r][c] = original[index];
        }
      }

      return ans;
    }
  }
}