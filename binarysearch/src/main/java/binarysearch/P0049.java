package binarysearch;

import java.util.HashSet;
import java.util.LinkedList;
import java.util.Objects;
import java.util.Queue;

/*
 * Problem: https://binarysearch.com/problems/Farthest-Point-From-Water
 * Submission: https://binarysearch.com/problems/Farthest-Point-From-Water/submissions/7311937
 */
public class P0049 {
  class Solution {
    public int solve(int[][] matrix) {
      if (matrix.length == 0)
        return -1;

      var n = matrix.length;
      var m = matrix[0].length;

      var dx = new int[] { 0,1,0,-1};
      var dy = new int[] { 1,0,-1,0};

      var shore = new HashSet<Pair>();

      for (int i = 0; i < n; i++) {
        for (int j = 0; j < m; j++) {
          if (matrix[i][j] == 0) {

            var ones = 0;
            for (int k = 0; k < 4; k++) {
              var px = i + dx[k];
              var py = j + dy[k];

              if (px < 0 || py < 0 || px >= n || py >= m)
                continue;

              if (matrix[px][py] == 1)
                ones++;
            }

            if (ones > 0)
              shore.add(new Pair(i, j));
          }
        }
      }

      if (shore.size() == 0 || shore.size() == n * m)
        return -1;

      // bfs
      // multisource
      var queue = new LinkedList<QI>();
      var visited = new HashSet<Pair>();

      for (var e : shore) {
        queue.offer(new QI(e, 0));
        visited.add(e);
      }

      var ans = 0;

      while (!queue.isEmpty()) {
        var el = queue.poll();

        ans = Math.max(ans, el.distance);

        for (int k = 0; k < 4; k++) {
          var px = el.pair.x + dx[k];
          var py = el.pair.y + dy[k];

          if (px < 0 || py < 0 || px >= n || py >= m)
            continue;

          if (visited.contains(new Pair(px, py)))
            continue;

          if (matrix[px][py] != 1)
            continue;

          visited.add(new Pair(px, py));
          queue.offer(new QI(new Pair(px, py), el.distance + 1));
        }
      }

      return ans;
    }

    private static class QI {
      public Pair pair;
      public int distance;

      public QI(Pair pair, int distance) {
        this.pair = pair;
        this.distance = distance;
      }
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

      @Override
      public String toString() {
        return "Pair{" +
          "x=" + x +
          ", y=" + y +
          '}';
      }
    }
  }
}