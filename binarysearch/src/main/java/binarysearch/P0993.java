package binarysearch;

import java.util.*;

/*
 * Problem: https://binarysearch.com/problems/Shortest-Path-in-a-Graph
 * Submission: https://binarysearch.com/problems/Shortest-Path-in-a-Graph/submissions/7304366
 */
public class P0993 {
  class Solution {
    public int solve(int[][] edges, int start, int end) {

      var pq = new PriorityQueue<Node>(Comparator.comparingInt(x -> x.cost));
      var visited = new HashSet<Integer>();
      var distance = new HashMap<Integer, Integer>();
      var graph = new HashMap<Integer, List<Edge>>();

      for (var e : edges) {
        graph.putIfAbsent(e[0], new ArrayList<>());
        graph.get(e[0]).add(new Edge(e[0], e[1], e[2]));
      }

      pq.offer(new Node(start, 0));
      distance.put(start, 0);

      while (!pq.isEmpty()) {
        var el = pq.poll();
        visited.add(el.node);

        if (distance.containsKey(el.node) && el.cost > distance.get(el.node))
          continue;

        var edgeList = graph.getOrDefault(el.node, new ArrayList<>());
        for (var a : edgeList) {
          if (visited.contains(a.to))
            continue;

          var newDistance = distance.getOrDefault(a.from, Integer.MAX_VALUE) + a.cost;
          if (newDistance < distance.getOrDefault(a.to, Integer.MAX_VALUE)) {
            distance.put(a.to, newDistance);
            pq.offer(new Node(a.to, newDistance));
          }
        }

        if (el.node == end) {
          return distance.get(el.node);
        }
      }

      return distance.getOrDefault(end, -1);
    }

    private static class Node {
      public int node;
      public int cost;

      public Node(int node, int cost) {
        this.node = node;
        this.cost = cost;
      }
    }

    public static class Edge {
      public int from;
      public int to;
      public int cost;

      public Edge(int from, int to, int cost) {
        this.from = from;
        this.to = to;
        this.cost = cost;
      }
    }
  }
}