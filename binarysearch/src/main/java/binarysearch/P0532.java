package binarysearch;

import java.util.*;

/*
 * Problem: https://binarysearch.com/problems/Color-Map
 * Submission: https://binarysearch.com/problems/Color-Map/submissions/6957600
 */
public class P0532 {
  class Solution {
    public int solve(int[][] matrix) {
      var visited = new HashSet<Point>();
      var islands = new HashMap<Integer, Integer>(); // color -> island count

      var rows = matrix.length;
      if (rows == 0)
        return 0;

      var cols = matrix[0].length;

      for (int i = 0; i < rows; i++) {
        for (int j = 0; j < cols; j++) {
          if (visited.contains(new Point(i, j)))
            continue;
          addIsland(i, j, matrix, visited, islands);
        }
      }

      var maxIslands = islands.entrySet().stream().max(Map.Entry.comparingByValue()).get().getValue();
      var totalIslands = islands.entrySet().stream().map(x -> x.getValue()).mapToInt(x -> x.intValue()).sum();

      return totalIslands - maxIslands;
    }

    private void addIsland(int sx, int sy, int[][] matrix, HashSet<Point> visited, HashMap<Integer, Integer> islands) {
      var color = matrix[sx][sy];
      islands.put(color, islands.getOrDefault(color, 0) + 1);

      var queue = new LinkedList<Point>();
      queue.add(new Point(sx, sy));

      var directions = new int[][] {
        new int[] {1,0},
        new int[] {-1,0},
        new int[] {0,1},
        new int[] {0,-1},
      };

      while (!queue.isEmpty()) {
        var el = queue.poll();
        if (visited.contains(el))
          continue;

        visited.add(el);

        for (var dir : directions) {
          var next = new Point(el.x + dir[0], el.y + dir[1]);
          if (next.x < 0 || next.y < 0 || next.x >= matrix.length || next.y >= matrix[0].length)
            continue;

          if (matrix[next.x][next.y] != color)
            continue;

          queue.add(next);
        }
      }
    }

    public class Point {
      public int x;
      public int y;

      public Point(int x, int y) {
        this.x = x;
        this.y = y;
      }

      @Override
      public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Point point = (Point) o;
        return x == point.x && y == point.y;
      }

      @Override
      public int hashCode() {
        return Objects.hash(x, y);
      }
    }
  }
}