package binarysearch;

import java.util.Comparator;
import java.util.PriorityQueue;

/*
 * Problem: https://binarysearch.com/problems/Matrix-Search
 * Submission: https://binarysearch.com/problems/Matrix-Search/submissions/7335099
 */
public class P0159 {
  class Solution {
    public int solve(int[][] matrix, int k) {
      var index = new int[matrix.length];
      var cols = matrix[0].length;

      var pq = new PriorityQueue<QueueItem>(Comparator.comparingInt(x -> x.num));
      var in = -1;

      for (int i = 0; i < matrix.length; i++) {
        pq.offer(new QueueItem(matrix[i][0], i, 0));
      }

      while (!pq.isEmpty()) {
        var el = pq.poll();
        in++;

        if (in == k)
          return el.num;

        if (el.col + 1 < cols) {
          pq.offer(new QueueItem(matrix[el.row][el.col + 1], el.row, el.col + 1));
        }
      }

      return -1;
    }

    private static class QueueItem {
      public int num;
      public int row;
      public int col;

      public QueueItem(int num, int row, int col) {
        this.num = num;
        this.row = row;
        this.col = col;
      }
    }
  }
}