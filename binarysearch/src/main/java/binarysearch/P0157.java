package binarysearch;

import java.util.ArrayList;
import java.util.Comparator;
import java.util.HashSet;
import java.util.LinkedList;

/*
 * Problem: https://binarysearch.com/problems/Diagonal-Sort
 * Submission: https://binarysearch.com/problems/Diagonal-Sort/submissions/7406266
 */
public class P0157 {
  class Solution {
    public int[][] solve(int[][] matrix) {
      if (matrix.length == 0)
        return matrix;

      if (matrix[0].length == 0)
        return matrix;

      var n = matrix.length;
      var m = matrix[0].length;

      // along the rows
      for (var i = 0; i < n; i++) {
        var arr = new ArrayList<Integer>();

        var k = i;
        for (var j = 0; j < m; j++) {
          if (k < n) {
            arr.add(matrix[k][j]);
            k++;
          }
        }

        arr.sort(Comparator.naturalOrder());

        k = i;
        for (var j = 0; j < m; j++) {
          if (k < n) {
            matrix[k][j] = arr.get(j);
            k++;
          }
        }
      }

      // along the cols
      for (var j = 0; j < m; j++) {
        var arr = new ArrayList<Integer>();

        var k = j;
        for (var i = 0; i < n; i++) {
          if (k < m) {
            arr.add(matrix[i][k]);
            k++;
          }
        }

        arr.sort(Comparator.naturalOrder());

        k = j;
        for (var i = 0; i < n; i++) {
          if (k < m) {
            matrix[i][k] = arr.get(i);
            k++;
          }
        }
      }

      return matrix;
    }
  }
}