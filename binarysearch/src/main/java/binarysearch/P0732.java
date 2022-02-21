package binarysearch;

/*
 * Problem: https://binarysearch.com/problems/Two-Dimensional-List-Iterator
 * Submission: https://binarysearch.com/problems/Two-Dimensional-List-Iterator/submissions/7602760
 */
public class P0732 {
  class TwoDimensionalIterator {
    private int row = 0;
    private int col = 0;

    private final int n;
    private final int[][] lists;

    public TwoDimensionalIterator(int[][] lists) {
      this.n = lists.length;
      this.lists = lists;

      while (row < n) {
        if (col < lists[row].length)
          break;
        row++;
      }
    }

    public int next() {
      if (!hasnext()) {
        return -1;
      }

      var value = lists[row][col];

      if (col == lists[row].length - 1) {
        row++;
        while (row < n && lists[row].length == 0)
          row++;

        col = 0;
      }
      else {
        col++;
      }

      return value;
    }

    public boolean hasnext() {
      if (row == n)
        return false;
      return true;
    }
  }
}