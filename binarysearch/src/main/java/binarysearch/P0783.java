package binarysearch;

import java.util.HashSet;
import java.util.LinkedList;
import java.util.Objects;

/*
 * Problem: https://binarysearch.com/problems/Peak-Heights
 * Submission: https://binarysearch.com/problems/Peak-Heights/submissions/7305047
 */
public class P0783 {
  class Solution {
    public int[][] solve(int[][] matrix) {
      if (matrix.length == 0)
        return matrix;

      var n = matrix.length;
      var m = matrix[0].length;

      var queue = new LinkedList<Pair>();
      var visited = new HashSet<Pair>();

      for (int i = 0; i < n; i++) {
        for (int j = 0; j < m; j++) {
          if (matrix[i][j] == 0) {
            queue.offer(new Pair(i, j));
            visited.add(new Pair(i, j));
          }
        }
      }

      while (!queue.isEmpty()) {
        var el = queue.poll();

        var dx = new int[] {0,1,0,-1};
        var dy = new int[] {1,0,-1,0};

        for (int i = 0; i < 4; i++) {
          var px = el.x + dx[i];
          var py = el.y + dy[i];

          if (visited.contains(new Pair(px, py)))
            continue;

          if (px < 0 || py < 0 || px >= n || py >= m)
            continue;

          if (matrix[px][py] == 0)
            continue;

          matrix[px][py] = matrix[el.x][el.y] + 1;
          queue.offer(new Pair(px, py));
          visited.add(new Pair(px, py));
        }
      }

      return matrix;
    }

    private static class Pair {
      public int x;
      public int y;

      public Pair(int x, int y) {
        this.x = x;
        this.y = y;
      }

      @Override
      public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Pair pair = (Pair) o;
        return x == pair.x && y == pair.y;
      }

      @Override
      public int hashCode() {
        return Objects.hash(x, y);
      }
    }
  }
}