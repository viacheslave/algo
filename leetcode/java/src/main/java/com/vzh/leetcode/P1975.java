package com.vzh.leetcode;

import java.util.*;

/*
 * Problem: https://leetcode.com/problems/maximum-matrix-sum/
 * Submission: https://leetcode.com/submissions/detail/543474992/
 */
public class P1975 {
  class Solution {
    public long maxMatrixSum(int[][] matrix) {
      var rank = matrix.length;

      var hasZeroes = false;
      long sum = 0;

      for (var r = 0; r < matrix.length; ++r) {
        for (var c = 0; c < matrix.length; ++c) {
          if (matrix[r][c] == 0)
            hasZeroes = true;
          sum += Math.abs(matrix[r][c]);
        }
      }

      // observation: if the matrix has any zeros we can convert it to all-non-negative
      if (hasZeroes)
        return sum;

      // if row can be converted to all-non-negative - set zero
      // otherwise - set min non-negative value from all matrix values
      var minRowEls = new int[rank];

      for (var r = 0; r < matrix.length; ++r) {
        var negCount = 0;
        var negMin = Integer.MAX_VALUE;

        for (var c = 0; c < matrix.length; ++c) {
          if (matrix[r][c] < 0) {
            negCount++;
          }
          negMin = Math.min(negMin, matrix[r][c]);
        }

        if (negCount % 2 == 0) {
          minRowEls[r] = 0;
        } else {
          var maxRowNeg = Integer.MAX_VALUE;
          for (var rr = 0; rr < matrix.length; ++rr) {
            for (var c = 0; c < matrix.length; ++c) {
              maxRowNeg = Math.min(maxRowNeg, Math.abs(matrix[rr][c]));
            }
          }
          minRowEls[r] = maxRowNeg;
        }
      }

      var rowNegCount = Arrays.stream(minRowEls).filter(x -> x > 0).count();
      if (rowNegCount % 2 == 0)
        return sum;

      var maxRowNeg = Arrays.stream(minRowEls).filter(x -> x > 0).max();
      return sum - 2 * maxRowNeg.getAsInt();
    }
  }
}