package binarysearch;

import java.util.LinkedList;

/*
 * Problem: https://binarysearch.com/problems/Matrix-Nearest-Zero
 * Submission: https://binarysearch.com/problems/Matrix-Nearest-Zero/submissions/7414850
 */
public class P0623 {
  class Solution {
    public int[][] solve(int[][] matrix) {
      var n = matrix.length;
      if (n == 0)
        return matrix;

      var m = matrix[0].length;

      // bfs
      var visited = new int[n][m];
      var queue = new LinkedList<QueueElement>();

      for (int i = 0; i < n; i++) {
        for (int j = 0; j < m; j++) {
          if (matrix[i][j] == 0) {
            queue.offer(new QueueElement(i, j, 0));
            visited[i][j] = 1;
          }
        }
      }

      var dx = new int[] {0,1,0,-1};
      var dy = new int[] {1,0,-1,0};

      while (!queue.isEmpty()) {
        var el = queue.poll();
        matrix[el.i][el.j] = el.length;

        for (var i = 0; i < 4; i++) {
          var px = el.i + dx[i];
          var py = el.j + dy[i];

          if (px < 0 || py < 0 || px >= n || py >= m)
            continue;

          if (visited[px][py] == 1)
            continue;

          if (matrix[px][py] != 0) {
            queue.offer(new QueueElement(px, py, el.length + 1));
            visited[px][py] = 1;
          }
        }
      }

      return matrix;
    }

    private static class QueueElement {
      public int i;
      public int j;
      public int length;

      public QueueElement(int i, int j, int length) {
        this.i = i;
        this.j = j;
        this.length = length;
      }
    }
  }
}