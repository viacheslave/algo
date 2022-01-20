package binarysearch;

import java.util.Arrays;
import java.util.TreeSet;
import java.util.stream.Collectors;

/*
 * Problem: https://binarysearch.com/problems/Sudoku-Validator
 * Submission: https://binarysearch.com/problems/Sudoku-Validator/submissions/7324552
 */
public class P0120 {
  class Solution {
    public boolean solve(int[][] matrix) {

      for (var i = 0; i < matrix.length; i++) {
        var set = new TreeSet<>(Arrays.stream(matrix[i]).boxed().collect(Collectors.toList()));
        if (set.size() != matrix.length || set.first() != 1 || set.last() != matrix.length)
          return false;
      }

      for (var j = 0; j < matrix.length; j++) {
        var set = new TreeSet<Integer>();
        for (int i = 0; i < matrix.length; i++) {
          set.add(matrix[i][j]);
        }

        if (set.size() != matrix.length || set.first() != 1 || set.last() != matrix.length)
          return false;
      }

      for (var i = 0; i < matrix.length; i++){
        for (var j = 0; i < matrix.length; i++) {
          if (!validBox(matrix, i, j))
            return false;
        }
      }

      return true;
    }

    private boolean validBox(int[][] matrix, int px, int py) {
      var set = new TreeSet<Integer>();

      for (int i = 0; i < 3; i++) {
        for (int j = 0; j < 3; j++) {
          set.add(matrix[i][j]);
        }
      }

      return !(set.size() != matrix.length || set.first() != 1 || set.last() != matrix.length);
    }
  }
}