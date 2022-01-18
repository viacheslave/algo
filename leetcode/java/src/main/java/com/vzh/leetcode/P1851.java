package com.vzh.leetcode;

import java.util.*;

/**
 * Problem: https://leetcode.com/problems/minimum-interval-to-include-each-query/
 * Submission: https://leetcode.com/submissions/detail/590033727/
 */
public class P1851 {
  class Solution {
    public int[] minInterval(int[][] intervals, int[] queries) {
      // the idea is based on building a sorted array of points from each interval start/end points
      // at each such points some new intervals arrive, some leave
      // thus we will calculate minsize for each [point, nextpoint), using a treeset.

      var points = new ArrayList<Point>();
      var size = new int[intervals.length];

      for (int i = 0, intervalsLength = intervals.length; i < intervalsLength; i++) {
        int[] interval = intervals[i];
        points.add(new Point(i ,interval[0], 1));
        points.add(new Point(i,interval[1] + 1, 0));

        size[i] = interval[1] - interval[0] + 1;
      }

      points.sort((a,b) -> {
        if (a.value == b.value)
          return a.kind - b.kind;
        return a.value - b.value;
      });

      var pointsMap = new TreeMap<Integer, List<Point>>();
      for (int i = 0; i < points.size(); i++) {
        pointsMap.putIfAbsent(points.get(i).value, new ArrayList<>());
        pointsMap.get(points.get(i).value).add(points.get(i));
      }

      var set = new TreeSet<Interval>();
      var minSizeMap = new TreeMap<Integer, Integer>();

      for (var entry : pointsMap.entrySet()) {
        for (var item : entry.getValue()) {
          if (item.kind == 1)
            set.add(new Interval(size[item.id], item.id));
          else
            set.remove(new Interval(size[item.id], item.id));
        }

        if (set.size() > 0) {
          minSizeMap.put(entry.getKey(), set.first().size);
        }
        else {
          minSizeMap.put(entry.getKey(), -1);
        }
      }

      var ans = new int[queries.length];

      for (var i = 0; i < queries.length; i++) {
        var fl = minSizeMap.floorEntry(queries[i]);
        var ce = minSizeMap.ceilingEntry(queries[i]);

        if (fl == null)
          ans[i] = -1;
        else if (ce == null)
          ans[i] = -1;
        else
          ans[i] = fl.getValue();
      }

      return ans;
    }

    public class Interval implements Comparable<Interval> {
      public int size;
      public int id;

      public Interval(int size, int id) {
        this.size = size;
        this.id = id;
      }

      @Override
      public String toString() {
        return "Interval{" +
          "size=" + size +
          ", id=" + id +
          '}';
      }

      @Override
      public int compareTo(Interval o) {
        if (this.size == o.size)
          return this.id - o.id;

        return this.size - o.size;
      }

      @Override
      public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Interval interval = (Interval) o;
        return size == interval.size && id == interval.id;
      }

      @Override
      public int hashCode() {
        return Objects.hash(size, id);
      }
    }

    public class Point implements Comparable<Point> {
      public int id;
      public int value;
      public int kind;

      public Point(int id, int value, int kind) {
        this.id = id;
        this.value = value;
        this.kind = kind;
      }

      @Override
      public int compareTo(Point o) {
        if (this.value == o.value) {
          if (this.kind == o.kind) {
            return this.id - o.id;
          }
          return this.kind - o.kind;
        }
        return this.value - o.value;
      }

      @Override
      public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Point point = (Point) o;
        return id == point.id && value == point.value && kind == point.kind;
      }

      @Override
      public int hashCode() {
        return Objects.hash(id, value, kind);
      }

      @Override
      public String toString() {
        return "Point{" +
          "id=" + id +
          ", value=" + value +
          ", kind=" + kind +
          '}';
      }
    }
  }
}
