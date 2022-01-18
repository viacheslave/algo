package com.vzh.leetcode;

import java.util.HashMap;
import java.util.HashSet;

/**
 * Problem: https://leetcode.com/problems/number-of-operations-to-make-network-connected/
 * Submission: https://leetcode.com/submissions/detail/589685597/
 */
public class P1319 {
  class Solution {
    public int makeConnected(int n, int[][] connections) {
      // Union-find
      var uf = new UnionFind(n);

      for (var conn : connections)
        uf.Union(conn[0], conn[1]);

      // find clusters
      var clusters = new HashMap<Integer, HashSet<Integer>>();

      for (int i = 0; i < n; i++) {
        var root = uf.Find(i);

        clusters.putIfAbsent(root, new HashSet<>());
        clusters.get(root).add(i);
      }

      if (clusters.size() == 1)
        return 0;

      // we need the number of clusters - 1 cables
      var needCables = clusters.size() - 1;

      var excessiveCables = 0;
      var connected = new HashMap<Integer, Integer>();

      for (var cluster : clusters.entrySet()) {
        connected.putIfAbsent(cluster.getKey(), 0);
      }

      // for each cluster
      // calculate how many connections there are
      // n - 1 is enough
      for (var conn : connections) {
        for (var cluster : clusters.entrySet()) {
          var items = cluster.getValue();
          if (items.contains(conn[0]) && items.contains(conn[1])) {
            connected.put(cluster.getKey(), connected.get(cluster.getKey()) + 1);
            break;
          }
        }
      }

      // all other are excessive
      for (var cluster : clusters.entrySet()) {
        excessiveCables += connected.get(cluster.getKey()) - (cluster.getValue().size() - 1);
      }

      if (excessiveCables < needCables)
        return -1;

      return needCables;
    }

    private class UnionFind {
      private final int[] parent;
      private final int[] rank;

      public UnionFind(int n) {
        parent = new int[n];
        rank = new int[n];

        for (int i = 0; i < n; i++) {
          parent[i] = i;
          rank[i] = 0;
        }
      }

      public int Find(int p) {
        while (p != parent[p]) {
          parent[p] = parent[parent[p]];
          p = parent[p];
        }

        return p;
      }

      public void Union(int p, int q) {
        int rootP = Find(p);
        int rootQ = Find(q);

        if (rootP == rootQ)
          return;

        if (rank[rootP] < rank[rootQ]) {
          parent[rootP] = rootQ;
        }
        else if (rank[rootP] > rank[rootQ]) {
          parent[rootQ] = rootP;
        }
        else {
          parent[rootQ] = rootP;
          rank[rootP]++;
        }
      }
    }
  }
}
