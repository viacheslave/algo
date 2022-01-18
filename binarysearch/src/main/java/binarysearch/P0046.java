package binarysearch;

import java.util.*;

/*
 * Problem: https://binarysearch.com/problems/Shortest-Bridge
 * Submission: https://binarysearch.com/problems/Shortest-Bridge/submissions/7310170
 */
public class P0046 {
  class Solution {
    public int solve(int[][] matrix) {
      // find islands

      var island1 = new HashSet<Pair>();
      var island2 = new HashSet<Pair>();

      var n = matrix.length;
      var m = matrix[0].length;
      var visited = new int[n][m];

      for (int i = 0; i < n; i++) {
        for (int j = 0; j < m; j++) {
          if (matrix[i][j] == 0) {
            continue;
          }

          if (visited[i][j] == 1) {
            continue;
          }

          // dfs
          var island = island1.size() == 0 ? island1 : island2;
          dfs(matrix, i, j, n, m, visited, island);
        }
      }

      // find waterfront
      var island = island1;
      var shore = new HashSet<Pair>();
      var dx = new int[] {0,1,0,-1};
      var dy = new int[] {1,0,-1,0};

      for (var p : island) {
        var s = 0;
        for (int i = 0; i < dx.length; i++) {
          var px = p.x + dx[i];
          var py = p.y + dy[i];

          if (px < 0 || py < 0 || px >= n || py >= m)
            continue;

          if (matrix[px][py] == 0)
            s++;
        }

        if (s > 0) {
          shore.add(p);
        }
      }

      // bfs from all shore points
      var queue = new LinkedList<QP>();
      visited = new int[n][m];

      for (var s: shore) {
        visited[s.x][s.y] = 1;
        queue.offer(new QP(s, 0));
      }

      while (!queue.isEmpty()) {
        var el = queue.poll();

        if (island2.contains(el.pair))
          return el.length - 1;

        for (int i = 0; i < dx.length; i++) {
          var px = el.pair.x + dx[i];
          var py = el.pair.y + dy[i];

          if (px < 0 || py < 0 || px >= n || py >= m)
            continue;

          if (island1.contains(new Pair(px, py)) || visited[px][py] == 1)
            continue;

          visited[px][py] = 1;
          queue.offer(new QP(new Pair(px, py), el.length + 1));
        }
      }

      return -1;
    }

    private void dfs(int[][] matrix, int i, int j, int n, int m, int[][] visited, HashSet<Pair> island) {
      if (visited[i][j] == 1)
        return;

      visited[i][j] = 1;
      island.add(new Pair(i, j));

      var dx = new int[] {0,1,0,-1};
      var dy = new int[] {1,0,-1,0};

      for (int k = 0; k < dx.length; k++) {
        var px = i + dx[k];
        var py = j + dy[k];

        if (px < 0 || py < 0 || px >= n || py >= m)
          continue;

        if (matrix[px][py] == 0)
          continue;

        if (visited[px][py] == 1)
          continue;

        dfs(matrix, px, py , n, m, visited, island);
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

    private static class QP {
      public Pair pair;
      public int length;

      public QP (Pair pair, int length) {
        this.pair = pair;
        this.length = length;
      }
    }
  }
}