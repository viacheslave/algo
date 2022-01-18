package binarysearch;

import java.util.HashSet;
import java.util.LinkedList;
import java.util.Objects;
import java.util.Stack;

/*
 * Problem: https://binarysearch.com/problems/Escape-Maze
 * Submission: https://binarysearch.com/problems/Escape-Maze/submissions/7161551
 */
public class P0276 {
  class Solution {
    public int solve(int[][] matrix) {

      var rows = matrix.length;
      var cols = matrix[0].length;

      if (matrix[0][0] == 1)
        return -1;

      var visited = new HashSet<Point>();
      var queue = new LinkedList<Point>();

      queue.add(new Point(0, 0, 0));

      var dx = new int[] {0,1,0,-1};
      var dy = new int[] {1,0,-1,0};

      while (!queue.isEmpty()) {
        var el = queue.poll();

        if (el.x == rows - 1 && el.y == cols - 1)
          return el.steps + 1;

        for (var i = 0; i < 4; i++) {
          var point = new Point(el.x  + dx[i], el.y + dy[i], el.steps + 1);

          if (visited.contains(point))
            continue;

          if (point.x < 0 || point.y < 0 || point.x >= rows || point.y >= cols)
            continue;

          if (matrix[point.x][point.y] == 1)
            continue;

          visited.add(point);
          queue.add(point);
        }
      }

      return -1;
    }

    static class Point {
      public int x;
      public int y;
      public int steps;

      public Point(int x, int y, int steps) {
        this.x = x;
        this.y = y;
        this.steps = steps;
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