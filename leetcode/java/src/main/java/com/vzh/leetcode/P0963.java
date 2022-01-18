package com.vzh.leetcode;

import java.util.HashSet;
import java.util.Objects;
import java.util.TreeMap;

/*
 * Problem: https://leetcode.com/problems/minimum-area-rectangle-ii/
 * Submission: https://leetcode.com/submissions/detail/591053440/
 */
public class P0963 {
  class Solution {
    public double minAreaFreeRect(int[][] points) {
      var set = new HashSet<Point>();
      for (var point: points)
        set.add(new Point(point[0], point[1]));

      var ans = Double.MAX_VALUE;

      // brute force
      // every three points
      for (int i = 0; i < points.length - 2; i++) {
        for (int j = i + 1; j < points.length - 1; j++) {
          for (int k = j + 1; k < points.length; k++) {
            ans = Math.min(ans, process(set, points[i], points[j], points[k]));
          }
        }
      }

      if (ans == Double.MAX_VALUE)
        return 0;

      return ans;
    }

    private double process(HashSet<Point> set, int[] p1, int[] p2, int[] p3) {
      var ans = Double.MAX_VALUE;

      if (isRect(set, p1, p2, p3))
        ans = Math.min(ans, getArea(p1, p2, p3));

      if (isRect(set, p2, p1, p3))
        ans = Math.min(ans, getArea(p2, p1, p3));

      if (isRect(set, p3, p1, p2))
        ans = Math.min(ans, getArea(p3, p1, p2));

      return ans;
    }

    private boolean isRect(HashSet<Point> set, int[] corner, int[] p1, int[] p2) {
      // check if corner is 90 degr.
      var epsilon = Math.pow(10, -5);
      double tanp1 = 1d * (p1[1] - corner[1]) / (p1[0] - corner[0]);
      double tanp2 = 1d * (p2[1] - corner[1]) / (p2[0] - corner[0]);

      var ort1 = Double.isInfinite(tanp1) && tanp2 == 0;
      var ort2 = Double.isInfinite(tanp2) && tanp1 == 0;
      if (!ort1 && !ort2 && !(Math.abs(1d + tanp1 * tanp2) < epsilon))
        return false;

      // get fourth point
      var mid = new double[] { 1d * (p2[0] + p1[0]) / 2, 1d * (p2[1] + p1[1]) / 2 };

      var x = mid[0] - 1d * corner[0];
      var y = mid[1] - 1d * corner[1];

      var f = new Point(mid[0] + x, mid[1] + y );
      var cf = new Point(corner[0], corner[1]);

      return set.contains(f) && (!f.equals(cf));
    }

    private double getArea(int[] corner, int[] p1, int[] p2) {
      var l1 = Math.sqrt(Math.pow(p1[1] - corner[1], 2) + Math.pow(p1[0] - corner[0], 2));
      var l2 = Math.sqrt(Math.pow(p2[1] - corner[1], 2) + Math.pow(p2[0] - corner[0], 2));

      return l1 * l2;
    }

    public class Point {
      public double x;
      public double y;

      public Point(double x, double y) {
        this.x = x;
        this.y = y;
      }

      @Override
      public boolean equals(Object o) {
        var epsilon = Math.pow(10, -5);

        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Point point = (Point) o;
        return Math.abs(point.x - x) < epsilon && Math.abs(point.y - y) < epsilon;
      }

      @Override
      public int hashCode() {
        return Objects.hash(x, y);
      }
    }
  }
}