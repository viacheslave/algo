package com.vzh.leetcode;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.TreeSet;
import java.util.stream.Collectors;

/*
 * Problem: https://leetcode.com/problems/closest-room/
 * Submission: https://leetcode.com/submissions/detail/586630386/
 */
public class P1847 {
  class Solution {
    public int[] closestRoom(int[][] rooms, int[][] queries) {
      var rms = Arrays.stream(rooms)
        .map(x -> new Room(x[0], x[1]))
        .sorted((x1, x2) -> x1.size - x2.size)
        .collect(Collectors.toList());

      List<Query> qrs = new ArrayList<Query>();
      for (int i = 0; i < queries.length; i++) {
        var query = new Query(i, queries[i][0], queries[i][1]);
        qrs.add(query);
      }

      qrs = qrs.stream()
        .sorted((x1, x2) -> x1.minSize - x2.minSize)
        .collect(Collectors.toList());

      var rmadded = rms.size();
      var treeSet = new TreeSet<Integer>();

      var ans = new int[qrs.size()];

      for (var i = qrs.size() - 1; i >= 0; i--) {
        var query = qrs.get(i);

        // binary search for start room
        // all rooms to the right are eligible
        var left = 0;
        var right = rooms.length - 1;
        var rmindex = -1;

        while (true) {
          if (right - left < 2) {
            var r = rms.get(left);
            if (r.size >= query.minSize) {
              rmindex = left;
              break;
            }

            r = rms.get(right);
            if (r.size >= query.minSize) {
              rmindex = right;
              break;
            }

            rmindex = -1;
            break;
          }

          var mid = (left + right) >> 1;
          var room = rms.get(mid);
          if (room.size < query.minSize)
            left = mid;
          else
            right = mid;
        }

        if (rmindex == -1) {
          ans[query.id] = -1;
          continue;
        }

        // add missing rooms to sorted set
        if (rmindex < rmadded) {
          for (var j = rmadded - 1; j >= rmindex; j--) {
            var room = rms.get(j);
            treeSet.add(room.id);
            rmadded = j;
          }
        }

        // search in set
        if (treeSet.contains(query.preferred)) {
          ans[query.id] = query.preferred;
        }
        else {
          var ceil = treeSet.ceiling(query.preferred);
          var floor = treeSet.floor(query.preferred);

          if (floor == null) {
            ans[query.id] = ceil;
          }
          else if (ceil == null) {
            ans[query.id] = floor;
          }
          else {
            var absfloor = Math.abs(query.preferred - floor);
            var absceil = Math.abs(query.preferred - ceil);

            if (absfloor == absceil)
              ans[query.id] = floor;
            else if (absfloor < absceil)
              ans[query.id] = floor;
            else
              ans[query.id] = ceil;
          }
        }
      }

      return ans;
    }

    public class Room {
      public int id;
      public int size;

      public Room(int id, int size) {
        this.id = id;
        this.size = size;
      }
    }

    public class Query {
      public int id;
      public int preferred;
      public int minSize;

      public Query(int id, int preferred, int minSize) {
        this.id = id;
        this.preferred = preferred;
        this.minSize = minSize;
      }

      @Override
      public String toString() {
        return "Query{" +
          "id=" + id +
          ", preferred=" + preferred +
          ", minSize=" + minSize +
          '}';
      }
    }
  }
}