package com.vzh.leetcode;

import java.util.*;

/*
 * Problem: https://leetcode.com/problems/number-of-ways-to-arrive-at-destination/
 * Submission: https://leetcode.com/submissions/detail/543096159/
 */
public class P1976 {
  class Solution {
    public int countPaths(int n, int[][] roads) {
      if (n == 1)
        return 1;

      var map = new HashMap<Integer, ArrayList<int[]>>();

      for (var road : roads) {
        map.putIfAbsent(road[0], new ArrayList<>());
        map.putIfAbsent(road[1], new ArrayList<>());

        map.merge(road[0], new ArrayList<>(Arrays.asList(new int[]{road[1], road[2]})), (ints, ints2) -> {
          ints.add(ints2.get(0));
          return ints;
        });

        map.merge(road[1], new ArrayList<>(Arrays.asList(new int[]{road[0], road[2]})), (ints, ints2) -> {
          ints.add(ints2.get(0));
          return ints;
        });
      }

      var visited = new int[n];

      var distance = new long[n];
      for (var i = 0; i < n; ++i)
        distance[i] = Long.MAX_VALUE;

      distance[0] = 0;
      visited[0] = 1;

      var pq = new PriorityQueue<PQItem>(new Comparator<PQItem>() {
        @Override
        public int compare(PQItem o1, PQItem o2) {
          if (o1.distance < o2.distance)
            return -1;
          if (o1.distance > o2.distance)
            return 1;
          return 0;
        }
      });

      for (var d : map.get(0)) {
        distance[d[0]] = d[1];
        pq.add(new PQItem(d[1], d[0]));
      }

      while (pq.size() > 0) {
        var el = pq.poll();

        if (visited[el.to] == 1)
          continue;

        visited[el.to] = 1;

        for (var next : map.get(el.to)) {
          var dist = distance[el.to] + next[1];
          if (dist < distance[next[0]]) {
            distance[next[0]] = dist;
            pq.add(new PQItem(distance[next[0]], next[0]));
          }
        }
      }

      //var minDistance = distance[n - 1];

      var egdes = new ArrayList<int[]>();
      visited = new int[n];

      var q = new LinkedList<Integer>();
      q.add(n - 1);

      while (q.size() > 0) {
        var el = q.poll();
        if (visited[el] == 1)
          continue;

        visited[el] = 1;
        for (var next : map.get(el)) {
          var to = next[0];
          var d = next[1];
          if (distance[to] + d == distance[el]) {
            egdes.add(new int[]{to, el, d});
            q.add(to);
          }
        }
      }

      var edgeMap = new HashMap<Integer, ArrayList<Integer>>();
      for (var edge : egdes) {
        edgeMap.putIfAbsent(edge[0], new ArrayList<>());
        edgeMap.merge(edge[0], new ArrayList<>(Arrays.asList(edge[1])), (integers, integers2) -> {
          integers.add(integers2.get(0));
          return integers;
        });
      }

      var inDegrees = new int[n];
      for (var edge : egdes) {
        inDegrees[edge[1]]++;
      }

      var topoSorted = new ArrayList<Integer>();
      q.clear();
      for (var inDegree : inDegrees) {
        if (inDegree == 0)
          q.add(inDegree);
      }

      while (q.size() > 0) {
        var el = q.poll();
        topoSorted.add(el);

        if (!edgeMap.containsKey(el))
          continue;

        for (var e : edgeMap.get(el)) {
          inDegrees[e]--;
          if (inDegrees[e] == 0)
            q.add(e);
        }
      }

      var ans = new int[n];
      ans[0] = 1;

      for (var edge : edgeMap.entrySet()) {
        for (var to : edge.getValue()) {
          ans[to] += ans[edge.getKey()];
          ans[to] %= 1_000_000_007;
        }
      }

      return ans[n - 1];
    }

    class PQItem {
      public long distance;
      public int to;

      public PQItem(long distance, int to) {
        this.distance = distance;
        this.to = to;
      }
    }
  }
}