package binarysearch;

import java.util.Arrays;

/*
 * Problem: https://binarysearch.com/problems/Conway's-Game-of-Life
 * Submission: https://binarysearch.com/problems/Conway's-Game-of-Life/submissions/6716596
 */
public class P0179 {
  class Solution {
    public int[][] solve(int[][] matrix) {
      var next = new int[matrix.length][];

      for (int i = 0; i < matrix.length; i++) {
        next[i] = new int[matrix[i].length];

        for (int j = 0; j < matrix[i].length; j++) {
          var num = getNCount(matrix, i, j);

          if (matrix[i][j] == 1) {
            if (num < 2) next[i][j] = 0;
            else if (num > 3) next[i][j] = 0;
            else next[i][j] = 1;
          } else {
            if (num == 3)
              next[i][j] = 1;
          }
        }
      }

      for (int i = 0; i < matrix.length; i++)
        for (int j = 0; j < matrix[i].length; j++)
          matrix[i][j] = next[i][j];

      return matrix;
    }

    private int getNCount(int[][] board, int i, int j) {
      var neibs = Arrays.asList(
        new Pair(i - 1, j - 1),
        new Pair(i - 1, j),
        new Pair(i - 1, j + 1),
        new Pair(i,     j + 1),
        new Pair(i + 1, j + 1),
        new Pair(i + 1, j),
        new Pair(i + 1, j - 1),
        new Pair(i, j - 1)
      );

      return (int)neibs.stream()
        .filter(v -> isValid(board, v))
        .count();
    }

    private boolean isValid(int[][] board, Pair v) {
      return v.item1 >= 0
        && v.item2 >= 0
        && v.item1 < board.length
        && v.item2 < board[0].length
        && board[v.item1][v.item2] == 1;
    }

    class Pair {
      public int item1;
      public int item2;

      public Pair(int item1, int item2) {
        this.item1 = item1;
        this.item2 = item2;
      }
    }
  }
}