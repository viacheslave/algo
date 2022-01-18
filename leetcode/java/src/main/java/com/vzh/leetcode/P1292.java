package com.vzh.leetcode;

import java.util.ArrayList;
import java.util.List;

/**
 * Problem: https://leetcode.com/problems/maximum-side-length-of-a-square-with-sum-less-than-or-equal-to-threshold/
 * Submission: https://leetcode.com/submissions/detail/589671633/
 */
public class P1292 {
  class Solution {
    public int maxSideLength(int[][] mat, int threshold) {

      var rows = mat.length;
      var cols = mat[0].length;

      // prefix sums for quick square sum calculation
      var prefixSums = new int[rows + 1][cols + 1];
      for (var r = 0; r < rows; r++) {
        for (var c = 0; c < cols; c++) {
          if (r == 0) {
            prefixSums[r + 1][c + 1] = prefixSums[r + 1][c] + mat[r][c];
            continue;
          }

          if (c == 0) {
            prefixSums[r + 1][c + 1] = prefixSums[r][c + 1] + mat[r][c];
            continue;
          }

          prefixSums[r + 1][c + 1] = prefixSums[r + 1][c] + prefixSums[r][c + 1] - prefixSums[r][c] + mat[r][c];
        }
      }

      // Binary Search
      var left = 0;
      var right = Math.min(rows, cols);

      while (true) {
        if (right - left < 2) {
          if (lessOrEqual(right, prefixSums, threshold))
            return right;
          return left;
        }

        var mid = (left + right) >> 1;
        if (lessOrEqual(mid, prefixSums, threshold))
          left = mid;
        else
          right = mid;
      }
    }

    private boolean lessOrEqual(int side, int[][] prefixSums, int threshold) {
      var rows = prefixSums.length - 1;
      var cols = prefixSums[0].length - 1;

      for (var r = 0; r < rows - side + 1; r++) {
        for (var c = 0; c < cols - side + 1; c++) {
          var sum = prefixSums[r + side][c + side] - prefixSums[r][c + side] - prefixSums[r +side][c] + prefixSums[r][c];
          if (sum <= threshold)
            return true;
        }
      }

      return false;
    }
  }
}
