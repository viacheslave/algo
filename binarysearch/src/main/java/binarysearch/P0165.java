package binarysearch;

import java.util.Stack;

/*
 * Problem: https://binarysearch.com/problems/Matrix-Search-Sequel
 * Submission: https://binarysearch.com/problems/Matrix-Search-Sequel/submissions/7389559
 */
public class P0165 {
  class Solution {
    public boolean solve(int[][] matrix, int target) {
      var n = matrix.length;
      if (n == 0)
        return false;

      var m = matrix[0].length;

      var row = 0; // first row
      var col = m - 1; // last col

      int item;

      while (row >= 0 && col >= 0 && row < n && col < m) {
        item = matrix[row][col];
        if (item == target)
          return true;

        if (item < target) row++;
        else col--;
      }

      return false;
    }
  }
}