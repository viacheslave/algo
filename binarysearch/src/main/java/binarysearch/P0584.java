package binarysearch;

import java.util.*;

/*
 * Problem: https://binarysearch.com/problems/Ambigram-Detection
 * Submission: https://binarysearch.com/problems/Ambigram-Detection/submissions/6666339
 */
public class P0584 {
  class Solution {
    public int solve(int[][] matrix) {
      var ans = 0;
      var rows = matrix.length;
      var cols = matrix[0].length;

      var gv = new HashSet<Point>();
      var islandMasks = new HashSet<String>();

      for (int i = 0; i < rows; i++) {
        for (int j = 0; j < cols; j++) {
          if (matrix[i][j] == 0)
            continue;

          if (gv.contains(new Point(i , j)))
            continue;

          // BFS
          var island = new TreeSet<Point>();

          var q = new LinkedList<Point>();
          q.add(new Point(i ,j));

          while (!q.isEmpty()) {
            var el = q.poll();
            if (gv.contains(el))
              continue;

            gv.add(el);
            island.add(el);

            var sides = List.of(
              new Point(el.x + 1, el.y),
              new Point(el.x - 1, el.y),
              new Point(el.x, el.y + 1),
              new Point(el.x, el.y - 1)
            );

            for (var side : sides) {
              if (side.x < 0 || side.x >= rows || side.y < 0 || side.y >= cols)
                continue;

              if (matrix[side.x][side.y] == 0)
                continue;

              q.add(side);
            }
          }

          var mask = new StringBuilder();
          var diff = new ArrayList<>(island);

          for (var k = 1; k < diff.size(); k++) {
            var d = new Point(diff.get(k).x - diff.get(k - 1).x, diff.get(k).y - diff.get(k - 1).y);
            mask.append(d);
          }

          islandMasks.add(mask.toString());
        }
      }

      return islandMasks.size();
    }

    class Point implements Comparable<Point> {
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


      @Override
      public int compareTo(Point o) {
        if (this.y == o.y)
          return this.x - o.x;

        return this.y - o.y;
      }

      @Override
      public String toString() {
        return "Point{" +
          "x=" + x +
          ", y=" + y +
          '}';
      }
    }
  }
}