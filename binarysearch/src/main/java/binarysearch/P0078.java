package binarysearch;

import java.util.Arrays;
import java.util.HashSet;

/*
 * Problem: https://binarysearch.com/problems/Zero-Matrix
 * Submission: https://binarysearch.com/problems/Zero-Matrix/submissions/7357058
 */
public class P0078 {
  class Solution {
    public int[][] solve(int[][] matrix) {
      var rows = new HashSet<Integer>();
      var cols = new HashSet<Integer>();

      for (int i = 0; i < matrix.length; i++) {
        for (int j = 0; j < matrix[0].length; j++) {
          if (matrix[i][j] == 0) {
            rows.add(i);
            cols.add(j);
          }
        }
      }

      // fill row
      for (var i : rows) {
        for (int j = 0; j < matrix[0].length; j++) {
          matrix[i][j] = 0;
        }
      }

      // fill col
      for (var j : cols) {
        for (int i = 0; i < matrix.length; i++) {
          matrix[i][j] = 0;
        }
      }

      return matrix;
    }
  }
}