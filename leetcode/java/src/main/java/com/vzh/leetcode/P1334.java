package com.vzh.leetcode;

import java.util.*;

/*
 * Problem: https://leetcode.com/problems/find-the-city-with-the-smallest-number-of-neighbors-at-a-threshold-distance/
 * Submission: https://leetcode.com/submissions/detail/611603451/
 */
class P1334 {
  class Solution {
    public int findTheCity(int n, int[][] edges, int distanceThreshold) {
      var adjList = new HashMap<Integer, List<Edge>>();

      for (var edge : edges) {
        adjList.putIfAbsent(edge[0], new ArrayList<>());
        adjList.putIfAbsent(edge[1], new ArrayList<>());

        adjList.get(edge[0]).add(new Edge(edge[0], edge[1], edge[2]));
        adjList.get(edge[1]).add(new Edge(edge[1], edge[0], edge[2]));
      }

      var cities = new long[n];
      Arrays.fill(cities, 0);

      // calculate shortest paths for every node
      for (var node : adjList.keySet()) {

        // dijkstra
        var distance = new int[n];
        Arrays.fill(distance, Integer.MAX_VALUE);

        var visited = new boolean[n];

        var pq = new PriorityQueue<Node>();
        pq.offer(new Node(node, 0));

        while (!pq.isEmpty()) {
          var el = pq.poll();
          visited[el.id] = true;

          for (var nd : adjList.get(el.id)) {
            if (visited[nd.to])
              continue;

            if (el.distance + nd.distance < distance[nd.to]) {
              distance[nd.to] = el.distance + nd.distance;
              pq.offer(new Node(nd.to, distance[nd.to]));
            }
          }
        }

        var less = Arrays.stream(distance).filter(x -> x <= distanceThreshold).count();
        cities[node] = less;
      }

      var ans = -1;
      var minDistance = Arrays.stream(cities).min().getAsLong();

      for (int i = 0; i < cities.length; i++) {
        if (cities[i] == minDistance)
          ans = i;
      }

      return ans;
    }

    static class Edge {
      public int from;
      public int to;
      public int distance;

      public Edge(int from, int to, int distance) {
        this.from = from;
        this.to = to;
        this.distance = distance;
      }
    }

    static class Node implements Comparable<Node> {
      public int id;
      public int distance;

      public Node(int id, int distance) {
        this.id = id;
        this.distance = distance;
      }

      @Override
      public int compareTo(Node o) {
        return this.distance - o.distance;
      }
    }
  }
}