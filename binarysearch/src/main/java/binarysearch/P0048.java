package binarysearch;

import java.util.HashSet;
import java.util.LinkedList;
import java.util.Objects;
import java.util.Queue;

/*
 * Problem: https://binarysearch.com/problems/Sinking-Islands
 * Submission: https://binarysearch.com/problems/Sinking-Islands/submissions/7312106
 */
public class P0048 {
  class Solution {
    public int[][] solve(int[][] board) {
      var n = board.length;
      var m = board[0].length;

      var visited = new HashSet<Pair>();
      var borders = new HashSet<Pair>();

      for (int i = 0; i < n; i++) {
        for (int j = 0; j < m; j++) {
          if (board[i][j] == 0)
            continue;

          visited.add(new Pair(i, j));
          dfs(board, visited, borders, i, j, n, m);

          if (borders.isEmpty()) {
            // mark all water

            for (var e : visited) {
              board[e.x][e.y] = 0;
            }
          }

          borders.clear();
          visited.clear();
        }
      }

      return board;
    }

    private void dfs(int[][] board, HashSet<Pair> visited, HashSet<Pair> borders, int i, int j, int n, int m) {
      var dx = new int[] {0,1,0,-1};
      var dy = new int[] {1,0,-1,0};

      for (int k = 0; k < 4; k++) {
        var px = i + dx[k];
        var py = j + dy[k];

        if (visited.contains(new Pair(px, py)))
          continue;

        if (px < 0 || py < 0 || px >= n || py >= m) {
          borders.add(new Pair(px, py));
          continue;
        }

        if (board[px][py] == 0)
          continue;

        visited.add(new Pair(px, py));
        dfs(board, visited, borders, px, py, n, m);
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