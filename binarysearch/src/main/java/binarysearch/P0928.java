package binarysearch;

import java.util.ArrayList;

/*
 * Problem: https://binarysearch.com/problems/Tic-Tac-Toe
 * Submission: https://binarysearch.com/problems/Tic-Tac-Toe/submissions/7353513
 */
public class P0928 {
  class TicTacToe {
    private final int n;

    private final int[] rows;
    private final int[] cols;
    private int diagonal;
    private int diagonalReversed;

    public TicTacToe(int n) {
      this.n = n;
      this.rows = new int[n];
      this.cols = new int[n];
    }

    public int move(int r, int c, boolean me) {
      var i = me ? 1 : -1;
      rows[r] += i;
      cols[c] += i;

      if (r == c)
        diagonal += i;

      if (r + c == n - 1)
        diagonalReversed += i;

      if (
        Math.abs(rows[r]) == n ||
          Math.abs(cols[c]) == n ||
          Math.abs(diagonal) == n ||
          Math.abs(diagonalReversed) == n
      ) {
        return i;
      }

      return 0;
    }
  }
}