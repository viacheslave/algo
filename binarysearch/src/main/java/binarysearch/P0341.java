package binarysearch;

import java.util.*;

/*
 * Problem: https://binarysearch.com/problems/The-Meeting-Place
 * Submission: https://binarysearch.com/problems/The-Meeting-Place/submissions/7158400
 */
public class P0341 {
  class Solution {
    public int solve(int[][] matrix) {

      var persons = new ArrayList<Point>();

      // starting positions
      for (int i = 0; i < matrix.length; i++) {
        for (int j = 0; j < matrix[0].length; j++) {
          if (matrix[i][j] == 2) {
            persons.add(new Point(i ,j));
          }
        }
      }

      var globalPoints = new HashMap<Point, Integer>();

      // bfs
      // for each person

      for (var i = 0; i < persons.size(); i++) {
        var visited = new HashSet<Point>();

        var queue = new LinkedList<PointDistance>();
        queue.add(new PointDistance(persons.get(i), 0));
        visited.add(persons.get(i));

        while (!queue.isEmpty()) {
          var el = queue.poll();
          globalPoints.put(el.point, globalPoints.getOrDefault(el.point, 0) + el.distance);

          var dx = new int[] { 1 ,0, -1, 0};
          var dy = new int[] { 0, 1, 0, -1};

          for (var j = 0; j < 4; j++) {
            var p = new Point(el.point.x + dx[j], el.point.y + dy[j]);
            if (visited.contains(p))
              continue;

            if (p.x < 0 || p.y < 0 || p.x >= matrix.length || p.y >= matrix[0].length)
              continue;

            if (matrix[p.x][p.y] == 1)
              continue;

            visited.add(p);
            queue.add(new PointDistance(p, el.distance + 1));
          }
        }
      }

      var min = globalPoints.entrySet().stream()
        .map(Map.Entry::getValue)
        .min(Comparator.naturalOrder());

      return min.get();
    }

    static class Point {
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
      public String toString() {
        return "Point{" +
          "x=" + x +
          ", y=" + y +
          '}';
      }
    }

    static class PointDistance {
      public Point point;
      public int distance;

      public PointDistance(Point point, int distance) {
        this.point = point;
        this.distance = distance;
      }

      @Override
      public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        PointDistance that = (PointDistance) o;
        return distance == that.distance && Objects.equals(point, that.point);
      }

      @Override
      public int hashCode() {
        return Objects.hash(point, distance);
      }
    }
  }
}