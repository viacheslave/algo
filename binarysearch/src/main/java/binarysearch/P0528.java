package binarysearch;

import java.util.*;

/*
 * Problem: https://binarysearch.com/problems/Group-Points
 * Submission: https://binarysearch.com/problems/Group-Points/submissions/7175884
 */
public class P0528 {
  class Solution {
    public int solve(int[][] points, int k) {
      // build a graph
      var adjList = new HashMap<Integer, List<Integer>>();

      for (int i = 0; i < points.length; i++) {
        adjList.putIfAbsent(i, new ArrayList<>());
      }

      for (int i = 0; i < points.length - 1; i++) {
        for (int j = 1; j < points.length; j++) {
          var dist = Math.sqrt(
            Math.pow(points[i][0] - points[j][0], 2) +
              Math.pow(points[i][1] - points[j][1], 2)
          );

          if (dist <= k) {
            adjList.get(i).add(j);
            adjList.get(j).add(i);
          }
        }
      }

      // dfs to count isolated components
      var visited = new boolean[points.length];
      var ans = 0;

      for (int i = 0; i < points.length; i++) {
        if (visited[i])
          continue;

        var stack = new Stack<Integer>();
        stack.add(i);

        while (!stack.empty()) {
          var el = stack.pop();
          if (visited[el])
            continue;

          visited[el] = true;
          for (var e : adjList.get(el))
            stack.push(e);
        }

        ans++;
      }

      return ans;
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
    }
  }
}